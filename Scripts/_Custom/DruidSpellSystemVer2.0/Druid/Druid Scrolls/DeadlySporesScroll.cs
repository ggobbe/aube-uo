using System;
using Server;
using Server.Items;

namespace Server.Items
{
   public class DeadlySporesScroll : SpellScroll
   {
      [Constructable]
      public DeadlySporesScroll() : this( 1 )
      {
      }

      [Constructable]
      public DeadlySporesScroll( int amount ) : base( 305, 0xE39 )
      {
          Name = "Deadly Spores";
         Hue = 0x58B;
      }

      public DeadlySporesScroll(Serial serial)
          : base(serial)
      {
          Name = "Deadly Spores";
        ItemID=0xE39;
      }

      public override void Serialize( GenericWriter writer )
      {
         base.Serialize( writer );

         writer.Write( (int) 0 ); // version
      }

      public override void Deserialize( GenericReader reader )
      {
         base.Deserialize( reader );

         int version = reader.ReadInt();
      }
   }
}
