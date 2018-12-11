using Server.Network;
using Server.Targeting;

namespace Server.Items
{
    public class SeedingTool : Item
    {
        private ItemQuality m_Quality;
        private int m_UsesRemaining;

        [CommandProperty(AccessLevel.GameMaster)]
        public ItemQuality Quality
        {
            get { return m_Quality; }
            set
            {
                UnscaleUses();
                m_Quality = value;
                InvalidateProperties();
                ScaleUses();
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int UsesRemaining
        {
            get { return m_UsesRemaining; }
            set
            {
                m_UsesRemaining = value;
                InvalidateProperties();
            }
        }

        public bool ShowUsesRemaining
        {
            get { return true; }
            set { }
        }

        public virtual bool BreakOnDepletion
        {
            get { return true; }
        }

        [Constructable]
        public SeedingTool() : this(50)
        {
        }

        [Constructable]
        public SeedingTool(int uses) : base(0xF39)
        {
            Name = "A seeding tool";
            Hue = 1269;
            Weight = 1.0;
            m_UsesRemaining = uses;
            m_Quality = ItemQuality.Normal;

        }

        public SeedingTool(Serial serial) : base(serial)
        {
        }

        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);

            if (m_Quality == ItemQuality.Exceptional)
                list.Add(1060636); // exceptional

            list.Add(1060584, m_UsesRemaining.ToString()); // uses remaining: ~1_val~
        }

        public virtual void DisplayDurabilityTo(Mobile m)
        {
            LabelToAffix(m, 1017323, AffixType.Append, ": " + m_UsesRemaining.ToString()); // Durability
        }

        public override void OnSingleClick(Mobile from)
        {
            DisplayDurabilityTo(from);

            base.OnSingleClick(from);
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (IsChildOf(from.Backpack) || Parent == from)
            {
                from.BeginTarget(-1, false, TargetFlags.None, new TargetCallback(Seed_OnTarget));
                from.SendMessage("From what do you want to extract a seed?");
            }
            else
            {
                from.SendLocalizedMessage(1042001); // That must be in your pack for you to use it.
            }
        }

        public virtual void Seed_OnTarget(Mobile from, object targ)
        {
            var item = targ as ISeedable;
            if (item == null)
            {
                from.SendMessage("This must be something that you can extract seeds from");
                return;
            }

            var seed = item.GetSeed();
            if (seed != null)
            {
                item.Consume();
                from.AddToBackpack(seed);
                from.SendMessage("You manage to extract a seed from this plant");
                UsesRemaining--;
            }

            if (UsesRemaining <= 0)
            {
                from.SendMessage("You broke the tool");
                Delete();
            }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int) 0); // version

            writer.Write((int) m_Quality);
            writer.Write((int) m_UsesRemaining);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
            m_Quality = (ItemQuality) reader.ReadInt();
            m_UsesRemaining = reader.ReadInt();
        }

        private void ScaleUses()
        {
            m_UsesRemaining = (m_UsesRemaining * GetUsesScalar()) / 100;
            InvalidateProperties();
        }

        private void UnscaleUses()
        {
            m_UsesRemaining = (m_UsesRemaining * 100) / GetUsesScalar();
        }

        private int GetUsesScalar()
        {
            if (m_Quality == ItemQuality.Exceptional)
                return 200;

            return 100;
        }
    }
}
