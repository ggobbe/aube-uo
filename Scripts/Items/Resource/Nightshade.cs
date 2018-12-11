using System;

namespace Server.Items
{
    public class Nightshade : BaseReagent, ICommodity, ISeedable
    {
        [Constructable]
        public Nightshade()
            : this(1)
        {
        }

        [Constructable]
        public Nightshade(int amount)
            : base(0xF88, amount)
        {
        }

        public Nightshade(Serial serial)
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
            return new HarvestableSeed(GetType(), HarvestableSeed.DefaultDelay, "Nightshade", 0xDCF, 0x18E5)
            {
                Hue = 707
            };
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