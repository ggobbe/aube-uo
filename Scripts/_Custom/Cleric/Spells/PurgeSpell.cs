using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using Server.Spells.Necromancy;
using Server.Spells;

namespace Server.Spells.Cleric
{
    public class PurgeSpell : ClericSpell
    {
        public override int SpellLevel
        {
            get { return 2; }
        }

        private static SpellInfo m_Info = new SpellInfo(
            "Purge", "Repurgo",
            212,
            9041
        );

        public override int RequiredTithing
        {
            get { return 5; }
        }

        public override double RequiredSkill
        {
            get { return 10.0; }
        }

        public override string SpellDescription
        {
            get { return "The target is cured of all poisons and has all negative stat curses removed."; }
        }

        public PurgeSpell(Mobile caster, Item scroll) : base(caster, scroll, m_Info)
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
            else if (CheckBSequence(m, false))
            {
                SpellHelper.Turn(Caster, m);

                m.PlaySound(0xF6);
                m.PlaySound(0x1F7);
                m.FixedParticles(0x3709, 1, 30, 9963, 13, 3, EffectLayer.Head);

                IEntity from = new Entity(Serial.Zero, new Point3D(m.X, m.Y, m.Z - 10), Caster.Map);
                IEntity to = new Entity(Serial.Zero, new Point3D(m.X, m.Y, m.Z + 50), Caster.Map);
                Effects.SendMovingParticles(from, to, 0x2255, 1, 0, false, false, 13, 3, 9501, 1, 0, EffectLayer.Head, 0x100);

                StatMod mod;

                mod = m.GetStatMod("[Magic] Str Offset");
                if (mod != null && mod.Offset < 0)
                    m.RemoveStatMod("[Magic] Str Offset");

                mod = m.GetStatMod("[Magic] Dex Offset");
                if (mod != null && mod.Offset < 0)
                    m.RemoveStatMod("[Magic] Dex Offset");

                mod = m.GetStatMod("[Magic] Int Offset");
                if (mod != null && mod.Offset < 0)
                    m.RemoveStatMod("[Magic] Int Offset");

                m.Paralyzed = false;
                m.CurePoison(Caster);

                EvilOmenSpell.TryEndEffect(m);
                StrangleSpell.RemoveCurse(m);
                CorpseSkinSpell.RemoveCurse(m);
            }

            FinishSequence();
        }

        private class InternalTarget : Target
        {
            private PurgeSpell m_Owner;

            public InternalTarget(PurgeSpell owner) : base(12, false, TargetFlags.Beneficial)
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
