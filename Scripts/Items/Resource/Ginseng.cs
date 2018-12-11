using System;

namespace Server.Items
{
    public class Ginseng : BaseReagent, ICommodity, ISeedable
    {
        [Constructable]
        public Ginseng()
            : this(1)
        {
        }

        [Constructable]
        public Ginseng(int amount)
            : base(0xF85, amount)
        {
        }

        public Ginseng(Serial serial)
            : base(serial)
        {
        }

        TextDefinition ICommodity.Description
        {
            get
            {
                return this.LabelNumber;
            }
        }
        bool ICommodity.IsDeedable
        {
            get
            {
                return true;
            }
        }

        Item ISeedable.GetSeed()
        {
            return new HarvestableSeed(GetType(), HarvestableSeed.DefaultDelay, "Ginseng", 0x18EB, 0x18E9);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}