using System;
using Server.Targeting;

namespace Server.Spells.Cleric
{
    public class SmiteSpell : ClericSpell
    {
        public override int SpellLevel
        {
            get { return 8; }
        }

        private static SpellInfo m_Info = new SpellInfo(
            "Smite", "Ferio",
            212,
            9041
        );

        public override int RequiredTithing
        {
            get { return 60; }
        }

        public override double RequiredSkill
        {
            get { return 80.0; }
        }

        public override string SpellDescription
        {
            get { return "The caster calls to the heavens to send a deadly bolt of lightning to strike down his opponent."; }
        }

        public SmiteSpell(Mobile caster, Item scroll) : base(caster, scroll, m_Info)
        {
        }

        public override void OnCast()
        {
            Caster.Target = new InternalTarget(this);
        }

        public void Target(Mobile m)
        {
            if (!Caster.CanSee(m))
            {
                Caster.SendLocalizedMessage(500237); // Target can not be seen.
            }
            else if (CheckHSequence(m))
            {
                m.BoltEffect(0x480);

                SpellHelper.Turn(Caster, m);

                double damage = Caster.Skills[SkillName.SpiritSpeak].Value * DivineFocusSpell.GetScalar(Caster);

                if (Core.AOS)
                {
                    SpellHelper.Damage(TimeSpan.Zero, m, Caster, damage, 0, 0, 0, 0, 100);
                }
                else
                {
                    SpellHelper.Damage(TimeSpan.Zero, m, Caster, damage);
                }
            }

            FinishSequence();
        }


        private class InternalTarget : Target
        {
            private SmiteSpell m_Owner;

            public InternalTarget(SmiteSpell owner) : base(12, false, TargetFlags.Harmful)
            {
                m_Owner = owner;
            }

            protected override void OnTarget(Mobile from, object o)
            {
                if (o is Mobile)
                {
                    m_Owner.Target((Mobile) o);
                }
            }

            protected override void OnTargetFinish(Mobile from)
            {
                m_Owner.FinishSequence();
            }
        }
    }
}
