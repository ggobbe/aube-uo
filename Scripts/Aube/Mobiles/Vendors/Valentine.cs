using System;
using System.Collections.Generic;
using Server.Aube.Mobiles.Vendors.SBInfos;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests
{
    public class Valentine : BaseVendor
    {
        private List<SBInfo> _SBInfos = new List<SBInfo>();

        protected override List<SBInfo> SBInfos { get { return _SBInfos; } }

        [Constructable]
        public Valentine()
            : base("Valentine")
        {
        }

        public Valentine(Serial serial)
            : base(serial)
        {
        }

        public override void InitSBInfo()
        {
            _SBInfos.Add(new SBValentine());
        }

        public override void InitBody()
        {
            this.InitStats(100, 100, 25);

            this.Female = true;
            this.Race = Race.Human;

            this.Hue = 0x83EE;
            this.HairItemID = 0x2049;
            this.HairHue = 0x599;
        }

        public override void InitOutfit()
        {
            this.AddItem(new Backpack());
            this.AddItem(new Boots());
            this.AddItem(new GildedDress());
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
