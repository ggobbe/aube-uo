using System;

namespace Server.Items
{
    public class IntelligencePotion : BaseIntelligencePotion
    {
        [Constructable]
        public IntelligencePotion()
            : base(PotionEffect.Intelligence)
        {
            Name = "Potion d'intelligence";
        }

        public IntelligencePotion(Serial serial)
            : base(serial)
        {
        }

        public override int IntOffset
        {
            get
            {
                return 10;
            }
        }
        public override TimeSpan Duration
        {
            get
            {
                return TimeSpan.FromMinutes(2.0);
            }
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
