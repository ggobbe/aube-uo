#region AuthorHeader
//
//	Shrink Potion version 0.1, by Scriptiz
//
//
#endregion AuthorHeader
using Server;
using Xanthos.Interfaces;

namespace Xanthos.ShrinkSystem
{
    public class ShrinkPotion : Item, IShrinkTool
    {
        private int m_Charges = 1;

        [CommandProperty(AccessLevel.GameMaster)]
        public int ShrinkCharges
        {
            get { return m_Charges; }
            set
            {
                if (0 == m_Charges || 0 == (m_Charges = value))
                    Delete();
                else
                    InvalidateProperties();
            }
        }

        public override bool ForceShowProperties
        {
            get { return ObjectPropertyList.Enabled; }
        }

        [Constructable]
        public ShrinkPotion() : this(0xF07)
        {
        }

        [Constructable]
        public ShrinkPotion(int itemID) : base(itemID)
        {
            Hue = 0x24D;
            Name = "Potion de rétrécissement";
        }

        public ShrinkPotion(Serial serial) : base(serial)
        {
        }

        public override void AddNameProperties(ObjectPropertyList list)
        {
            base.AddNameProperties(list);

            if (m_Charges >= 0)
                list.Add(1060658, "Charges\t{0}", m_Charges.ToString());
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (!IsChildOf(from.Backpack))
                from.SendLocalizedMessage(1042010);

            from.Target = new ShrinkTarget(from, this, false);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int) 0); // version
            writer.Write(m_Charges);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
            m_Charges = reader.ReadInt();
        }
    }
}
