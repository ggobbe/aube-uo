using System;
using System.Collections;

namespace Server.Spells.Cleric
{
    public class DivineFocusSpell : ClericSpell
    {
        public override int SpellLevel
        {
            get { return 1; }
        }

        private static SpellInfo m_Info = new SpellInfo(
            "Divine Focus", "Divinium Cogitatus",
            212,
            9041
        );

        public override int RequiredTithing
        {
            get { return 15; }
        }

        public override double RequiredSkill
        {
            get { return 35.0; }
        }

        public override string SpellDescription
        {
            get { return "The caster's mind focuses on his divine faith increasing the effect of his prayers.  However, the caster becomes mentally fatigued much faster."; }
        }

        private static Hashtable m_Table = new Hashtable();

        public DivineFocusSpell(Mobile caster, Item scroll) : base(caster, scroll, m_Info)
        {
        }

        public static double GetScalar(Mobile m)
        {
            double val = 1.0;

            if (!m.CanBeginAction(typeof(DivineFocusSpell)))
                val = 1.5;

            return val;
        }

        public override bool CheckCast()
        {
            if (!base.CheckCast())
            {
                return false;
            }

            if (!Caster.CanBeginAction(typeof(DivineFocusSpell)))
            {
                Caster.SendMessage("This spell is already in effect");
                return false;
            }

            return true;
        }

        public override void OnCast()
        {
            if (!Caster.CanBeginAction(typeof(DivineFocusSpell)))
            {
                Caster.SendMessage("This spell is already in effect");
                return;
            }

            if (CheckSequence())
            {
                Caster.BeginAction(typeof(DivineFocusSpell));

                Timer t = new InternalTimer(Caster);
                m_Table[Caster] = t;
                t.Start();

                Caster.FixedParticles(0x375A, 1, 15, 0x480, 1, 4, EffectLayer.Waist);
            }
        }

        private class InternalTimer : Timer
        {
            private Mobile m_Owner;

            public InternalTimer(Mobile owner) : base(TimeSpan.Zero, TimeSpan.FromSeconds(1.5))
            {
                m_Owner = owner;
            }

            protected override void OnTick()
            {
                if (!m_Owner.CheckAlive() || m_Owner.Mana < 3)
                {
                    m_Owner.EndAction(typeof(DivineFocusSpell));
                    m_Table.Remove(m_Owner);
                    m_Owner.SendMessage("Your mind weakens and you are unable to maintain your divine focus.");
                    Stop();
                }
                else
                {
                    m_Owner.Mana -= 3;
                }
            }
        }
    }
}
