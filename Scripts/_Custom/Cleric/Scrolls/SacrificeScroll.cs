using System;
using Server;
using Server.Items;

namespace Server.ACC.CSS.Systems.Cleric
{
	public class SacrificeScroll : SpellScroll
	{
		[Constructable]
		public SacrificeScroll() : this( 1 )
		{
		}

		[Constructable]
		public SacrificeScroll( int amount ) : base( 358, 0xE39, amount )
		{
			Name = "Sacrifice";
			Hue = 0x1F0;
		}

		public SacrificeScroll( Serial serial ) : base( serial )
		{
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
