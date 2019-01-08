using System;
using System.Collections;
using Server.Targeting;

namespace Server.Spells.Cleric
{
    public class DampenSpiritSpell : ClericSpell
    {
        public override int SpellLevel
        {
            get { return 4; }
        }

        private static SpellInfo m_Info = new SpellInfo(
            "Dampen Spirit", "Abicio Spiritus",
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
            get { return "The caster's enemy is slowly drained of his stamina, greatly hindering their ability to fight in combat or flee."; }
        }

        private static Hashtable m_Table = new Hashtable();

        public DampenSpiritSpell(Mobile caster, Item scroll) : base(caster, scroll, m_Info)
        {
        }

        public override void OnCast()
        {
            Caster.Target = new InternalTarget(this);
        }

        public static bool HasEffect(Mobile m)
        {
            return (m_Table[m] != null);
        }

        public static void RemoveEffect(Mobile m)
        {
            Timer t = (Timer) m_Table[m];

            if (t != null)
            {
                t.Stop();
                m_Table.Remove(m);
            }
        }

        public void Target(Mobile m)
        {
            if (!Caster.CanSee(m))
            {
                Caster.SendLocalizedMessage(500237); // Target can not be seen.
            }
            else if (CheckHSequence(m))
            {
                SpellHelper.Turn(Caster, m);

                Timer t = new InternalTimer(m);

                m_Table[m] = t;

                t.Start();

                m.FixedParticles(0x374A, 10, 15, 5032, EffectLayer.Head);
                m.PlaySound(0x1F8);
                m.SendMessage("You feel your spirit weakening.");
            }

            FinishSequence();
        }

        private class InternalTimer : Timer
        {
            private Mobile m_Owner;
            private DateTime m_Expire;

            public InternalTimer(Mobile owner) : base(TimeSpan.Zero, TimeSpan.FromSeconds(1.5))
            {
                m_Owner = owner;
                m_Expire = DateTime.Now + TimeSpan.FromSeconds(25.0);
            }

            protected override void OnTick()
            {
                if (!m_Owner.CheckAlive(false) || DateTime.Now >= m_Expire)
                {
                    Stop();
                    m_Table.Remove(m_Owner);
                    m_Owner.SendMessage("Your spirit begins to recover.");
                }
                else if (m_Owner.Stam < 3)
                {
                    m_Owner.Stam = 0;
                }
                else
                {
                    m_Owner.Stam -= 3;
                }
            }
        }

        private class InternalTarget : Target
        {
            private DampenSpiritSpell m_Owner;

            public InternalTarget(DampenSpiritSpell owner) : base(12, false, TargetFlags.Harmful)
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
