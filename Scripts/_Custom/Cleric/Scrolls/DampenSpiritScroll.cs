using System;
using Server;
using Server.Items;

namespace Server.ACC.CSS.Systems.Cleric
{
	public class DampenSpiritScroll : SpellScroll
	{
		[Constructable]
		public DampenSpiritScroll() : this( 1 )
		{
		}

		[Constructable]
		public DampenSpiritScroll( int amount ) : base( 352, 0xE39, amount )
		{
			Name = "Dampen Spirit";
			Hue = 0x1F0;
		}

		public DampenSpiritScroll( Serial serial ) : base( serial )
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
