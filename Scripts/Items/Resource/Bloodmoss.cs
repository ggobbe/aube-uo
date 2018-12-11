using System;

namespace Server.Items
{
    public class Bloodmoss : BaseReagent, ICommodity, ISeedable
    {
        [Constructable]
        public Bloodmoss()
            : this(1)
        {
        }

        [Constructable]
        public Bloodmoss(int amount)
            : base(0xF7B, amount)
        {
        }

        public Bloodmoss(Serial serial)
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
            return new HarvestableSeed(GetType(), HarvestableSeed.DefaultDelay, "Bloodmoss", 0x573D, 0xF7B)
            {
                Hue = 38
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