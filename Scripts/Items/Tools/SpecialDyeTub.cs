using System;

namespace Server.Items
{
    public class SpecialDyeTub : DyeTub, Engines.VeteranRewards.IRewardItem
    {
        private bool m_IsRewardItem;

        private int m_UsesRemaining;

        [CommandProperty(AccessLevel.GameMaster)]
        public int UsesRemaining { get { return m_UsesRemaining; } set { m_UsesRemaining = value; InvalidateProperties(); } }

        [Constructable]
        public SpecialDyeTub()
        {
            this.LootType = LootType.Blessed;
            UsesRemaining = 25;
        }

        public SpecialDyeTub(Serial serial)
            : base(serial)
        {
        }

        public override CustomHuePicker CustomHuePicker
        {
            get
            {
                return CustomHuePicker.SpecialDyeTub;
            }
        }
        public override int LabelNumber
        {
            get
            {
                return 1041285;
            }
        }// Special Dye Tub
        [CommandProperty(AccessLevel.GameMaster)]
        public bool IsRewardItem
        {
            get
            {
                return this.m_IsRewardItem;
            }
            set
            {
                this.m_IsRewardItem = value;
            }
        }
        public override void OnDoubleClick(Mobile from)
        {
            if (this.m_IsRewardItem && !Engines.VeteranRewards.RewardSystem.CheckIsUsableBy(from, this, null))
                return;

            base.OnDoubleClick(from);
        }

        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);

            if (Core.ML && this.m_IsRewardItem)
                list.Add(1076217); // 1st Year Veteran Reward

            if(UsesRemaining > 0)
                list.Add(1060584, UsesRemaining.ToString());
        }

        public override void OnDye(Mobile from)
        {
            base.OnDye(from);
            if(UsesRemaining > 0 && --UsesRemaining == 0)
            {
                from.SendMessage("La teinture ayant trop servie, vous la jetez.");
                Consume();
            }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)2); // version

            writer.Write(m_UsesRemaining);
            writer.Write((bool)this.m_IsRewardItem);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            switch ( version )
            {
                case 2:
                {
                    m_UsesRemaining = reader.ReadInt();
                    goto case 1;
                }
                case 1:
                    {
                        if (version == 1)
                        {
                            m_UsesRemaining = 25;
                        }
                        this.m_IsRewardItem = reader.ReadBool();
                        break;
                    }
            }
        }
    }
}