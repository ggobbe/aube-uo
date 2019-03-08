using Server.Mobiles;

namespace Server.Items
{
    public class LureStone : Item
    {
        private Mobile m_Owner;

        [Constructable]
        public LureStone(Mobile owner) : base(0x1355)
        {
            m_Owner = owner;
            Movable = false;
            Name = "Lure Stone";
            //AddComponent( new AddonComponent( 0x1355 ), 0, 0, 0 );
            //AddComponent( new AddonComponent( 0x1356 ), 0, -1, 0 );
        }

        public LureStone(Serial serial) : base(serial)
        {
        }

        public override bool HandlesOnMovement
        {
            get { return true; }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            Delete();
        }

        public override void OnMovement(Mobile m, Point3D oldLocation)
        {
            if (m_Owner != null)
            {
                if (m.InRange(this, 600))
                {
                    BaseCreature cret = m as BaseCreature;
                    if (cret != null)
                        if (cret.Tamable && (cret.Combatant == null || !cret.Combatant.Alive || cret.Combatant.Deleted))
                        {
                            double tamer = m_Owner.Skills[SkillName.AnimalLore].Value;
                            double bonus = m_Owner.Skills[SkillName.AnimalTaming].Value / 100;
                            if (cret.MinTameSkill <= (tamer + bonus) + 0.1)
                                cret.TargetLocation = new Point2D(this.X, this.Y);
                        }

                }
            }
        }
    }
}