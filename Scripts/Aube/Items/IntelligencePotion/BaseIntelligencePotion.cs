using System;

namespace Server.Items
{
    public abstract class BaseIntelligencePotion : BasePotion
    {
        public BaseIntelligencePotion(PotionEffect effect)
            : base(0xF0B, effect)
        {
            Hue = 15;
        }

        public BaseIntelligencePotion(Serial serial)
            : base(serial)
        {
        }

        public abstract int IntOffset { get; }
        public abstract TimeSpan Duration { get; }
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

        public bool DoIntelligence(Mobile from)
        {
            // TODO: Verify scaled; is it offset, duration, or both?
            int scale = Scale(from, this.IntOffset);
            if (Spells.SpellHelper.AddStatOffset(from, StatType.Int, scale, this.Duration))
            {
                from.FixedEffect(0x375A, 10, 15);
                from.PlaySound(0x1E7);

                BuffInfo.AddBuff(from, new BuffInfo(BuffIcon.Cunning, 1075843, this.Duration, from, scale.ToString()));

                return true;
            }

            from.SendLocalizedMessage(502173); // You are already under a similar effect.
            return false;
        }

        public override void Drink(Mobile from)
        {
            if (this.DoIntelligence(from))
            {
                PlayDrinkEffect(from);
                Consume();
            }
        }
    }
}
