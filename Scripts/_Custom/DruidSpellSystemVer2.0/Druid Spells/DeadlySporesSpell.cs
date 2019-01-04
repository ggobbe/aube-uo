using System;
using System.Collections;
using Server;
using Server.Mobiles;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Multis;
using Server.Misc;
using Server.Regions;
using Server.Gumps;
using Server.Spells.Druid;


namespace Server.Spells.Druid
{
    public class DeadlySporesSpell : DruidicSpell
    {
        private static SpellInfo m_Info = new SpellInfo(
            "Deadly Spores", "Telwa Nox",
            //SpellCircle.Sixth,
            230,
            9041,
            Reagent.FenMoss,
            Reagent.Pumice
             );
        public override string SpellDescription
        {
            get
            {
                return "The enemy is afflicted by poisonous spores.";
            }
        }
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(2); } }
        public override SpellCircle Circle { get { return SpellCircle.Sixth; } }
        public override double RequiredSkill { get { return 65.0; } }
        public override int RequiredMana { get { return 20; } }

        public DeadlySporesSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
        {
        }

        public override void OnCast()
        {

            Caster.Target = new InternalTarget(this);
        }

        public override bool DelayedDamage { get { return false; } }

        public void Target(Mobile m)
        {
            if (!Caster.CanSee(m))
            {
                Caster.SendLocalizedMessage(500237); // Target can not be seen.
            }
            else if (Caster.CanBeHarmful(m) && CheckSequence())
            {
                Mobile attacker = Caster, defender = m;

                SpellHelper.Turn(Caster, m);

                SpellHelper.CheckReflect((int)this.Circle, Caster, ref m);

                PlayerMobile c = Caster as PlayerMobile;

                if (m.Spell != null)
                    m.Spell.OnCasterHurt();

                m.Paralyzed = false;

                if (CheckResisted(m))
                {
                    m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
                }

                InternalTimer t = new InternalTimer(this, attacker, defender, m);
                t.Start();
            }

            FinishSequence();
        }

        private class InternalTimer : Timer
        {
            private Spell m_Spell;
            private Mobile m_Target;
            private Mobile m_Attacker, m_Defender;

            public InternalTimer(Spell spell, Mobile attacker, Mobile defender, Mobile target)
                : base(TimeSpan.FromSeconds(Core.AOS ? 3.0 : 2.5))
            {
                m_Spell = spell;
                m_Attacker = attacker;
                m_Defender = defender;
                m_Target = target;

                Priority = TimerPriority.FiftyMS;
            }

            protected override void OnTick()
            {
                if (m_Attacker.HarmfulCheck(m_Defender))
                {


                    m_Target.Animate(32, 5, 1, true, false, 0);

                    m_Target.FixedParticles(0x113A, 5, 30, 5052, EffectLayer.LeftFoot);
                    m_Target.PlaySound(0x208);
                    m_Target.Animate(32, 5, 1, true, false, 0);

                    m_Target.ApplyPoison(m_Target, Poison.Lethal);
                }
            }
        }

        private class InternalTarget : Target
        {
            private DeadlySporesSpell m_Owner;

            public InternalTarget(DeadlySporesSpell owner)
                : base(12, false, TargetFlags.Harmful)
            {
                m_Owner = owner;
            }

            protected override void OnTarget(Mobile from, object o)
            {
                if (o is Mobile)
                    m_Owner.Target((Mobile)o);
            }

            protected override void OnTargetFinish(Mobile from)
            {
                m_Owner.FinishSequence();
            }
        }
    }
}
