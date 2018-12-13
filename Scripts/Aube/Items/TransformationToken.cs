using Server.Mobiles;

namespace Server.Aube.Items
{
    public class TransformationToken : Item
    {
        private Mobile m_Owner;

        [CommandProperty(AccessLevel.GameMaster)]
        public Mobile Owner
        {
            get { return m_Owner; }
            set
            {
                BlessedFor = m_Owner;
                m_Owner = value;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int BodyMod { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        public int HueMod { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool CanRevert { get; set; }

        [Constructable]
        public TransformationToken() : base(0x2AAA)
        {
            Name = "Jeton de transformation";
            Weight = 1.0;

            BodyMod = 0;
            HueMod = -1;
            CanRevert = false;
        }

        public override void OnDoubleClick(Mobile @from)
        {
            if (!IsChildOf(from.Backpack))
            {
                from.SendLocalizedMessage(1062334); // This item must be in your backpack to be used.
            }
            else if (from is PlayerMobile)
            {
                if (Owner != null && from != Owner && from.AccessLevel < AccessLevel.GameMaster)
                {
                    from.SendMessage("Ceci ne vous appartient pas.");
                    return;
                }

                if (from.IsBodyMod)
                {
                    if (from.BodyMod == BodyMod && (CanRevert || from.AccessLevel >= AccessLevel.GameMaster))
                    {
                        from.BodyMod = 0;
                        from.HueMod = -1;
                    }
                    else
                    {
                        from.SendMessage("Vous êtes déjà transformé.");
                    }

                    return;
                }

                from.BodyMod = BodyMod;
                from.HueMod = HueMod;
            }
        }

        public TransformationToken(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int) 0); // version

            writer.Write(Owner);
            writer.Write(BodyMod);
            writer.Write(HueMod);
            writer.Write(CanRevert);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            Owner = reader.ReadMobile();
            BodyMod = reader.ReadInt();
            HueMod = reader.ReadInt();
            CanRevert = reader.ReadBool();
        }
    }
}
