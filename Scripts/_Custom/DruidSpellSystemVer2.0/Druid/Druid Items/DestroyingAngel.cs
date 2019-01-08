using System;
using Server;
using Server.Items;

namespace Server.Items
{
   public class DestroyingAngel : BaseReagent, ICommodity
   {
       public TextDefinition Description { get { return LabelNumber; } }
       bool ICommodity.IsDeedable { get { return (Core.ML); } }

      [Constructable]
      public DestroyingAngel() : this( 1 )
      {
      }

      [Constructable]
      public DestroyingAngel( int amount ) : base( 0xE1F, amount )
      {
         Hue = 0x290;
         Name = "destroying angel";
      }

      public DestroyingAngel( Serial serial ) : base( serial )
      {
      }

     /* public override Item Dupe( int amount )
      {
         return base.Dupe( new DestroyingAngel( amount ), amount );
      }*/

      public override void Serialize( GenericWriter writer )
      {
         base.Serialize( writer );

         writer.Write( (int) 1 ); // version
      }

      public override void Deserialize( GenericReader reader )
      {
         base.Deserialize( reader );

         int version = reader.ReadInt();
      	if (version==0)
      		this.ItemID=3971;
      }
   }
}