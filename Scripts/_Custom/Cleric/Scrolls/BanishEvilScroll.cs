namespace Server.Items.Cleric
{
	public class BanishEvilScroll : SpellScroll
	{
		[Constructable]
		public BanishEvilScroll() : this( 1 )
		{
		}

		[Constructable]
		public BanishEvilScroll( int amount ) : base( 351, 0xE39, amount )
		{
			Name = "Banish Evil";
			Hue = 0x1F0;
		}

		public BanishEvilScroll( Serial serial ) : base( serial )
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
