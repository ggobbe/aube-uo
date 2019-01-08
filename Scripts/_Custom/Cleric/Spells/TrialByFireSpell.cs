using System;
using Server.Aube;

namespace Server.Spells.Cleric
{
    public class TrialByFireSpell : ClericSpell
    {
        public override int SpellLevel
        {
            get { return 3; }
        }

        private static SpellInfo m_Info = new SpellInfo(
            "Trial by Fire", "Temptatio Exsuscito",
            212,
            9041
        );

        public override int RequiredTithing
        {
            get { return 25; }
        }

        public override double RequiredSkill
        {
            get { return 45.0; }
        }

        public override string SpellDescription
        {
            get { return "The caster is surrounded by a divine flame that damages the caster's enemy when hit by a weapon."; }
        }

        public static void Initialize()
        {
            PlayerEvent.OnWeaponHit += InternalCallback;
        }

        public TrialByFireSpell(Mobile caster, Item scroll) : base(caster, scroll, m_Info)
        {
        }

        public override bool CheckCast()
        {
            if (!base.CheckCast())
                return false;

            if (!Caster.CanBeginAction(typeof(TrialByFireSpell)))
            {
                Caster.SendLocalizedMessage(501775); // This spell is already in effect
                return false;
            }

            return true;
        }

        public override void OnCast()
        {
            if (CheckSequence())
            {
                Caster.SendMessage("Your body is covered by holy flames.");
                Caster.BeginAction(typeof(TrialByFireSpell));

                Caster.FixedParticles(0x3709, 10, 30, 5052, 0x480, 0, EffectLayer.LeftFoot);
                Caster.PlaySound(0x208);

                DateTime Expire = DateTime.Now + TimeSpan.FromMinutes(Caster.Skills[SkillName.Magery].Value / 10.0);
                new InternalTimer(Caster, Expire).Start();

            }

            FinishSequence();
        }

        private static void InternalCallback(OnWeaponHitEventArgs e)
        {
            if (!e.Defender.CanBeginAction(typeof(TrialByFireSpell)) && Utility.RandomBool())
            {
                e.Defender.DoHarmful(e.Attacker);

                double scale = 1.0;

                scale += e.Defender.Skills[SkillName.Inscribe].Value * 0.001;

                if (e.Defender.Player)
                {
                    scale += e.Defender.Int * 0.001;
                    scale += AosAttributes.GetValue(e.Defender, AosAttribute.SpellDamage) * 0.01;
                }

                int baseDamage = 6 + (int) (e.Defender.Skills[SkillName.EvalInt].Value / 5.0);

                double firedmg = Utility.RandomMinMax(baseDamage, baseDamage + 3);

                firedmg *= scale;

                SpellHelper.Damage(TimeSpan.Zero, e.Attacker, e.Defender, firedmg, 0, 100, 0, 0, 0);

                e.Attacker.FixedParticles(0x3709, 10, 30, 5052, 0x480, 0, EffectLayer.LeftFoot);
                e.Attacker.PlaySound(0x208);
            }
        }

        private class InternalTimer : Timer
        {
            private Mobile Source;
            private DateTime Expire;

            public InternalTimer(Mobile from, DateTime end) : base(TimeSpan.Zero, TimeSpan.FromSeconds(0.1))
            {
                Source = from;
                Expire = end;
            }

            protected override void OnTick()
            {
                if (DateTime.Now >= Expire || !Source.CheckAlive())
                {
                    Source.EndAction(typeof(TrialByFireSpell));
                    Stop();
                    Source.SendMessage("The holy fire around you fades.");
                }
            }
        }
    }
}
