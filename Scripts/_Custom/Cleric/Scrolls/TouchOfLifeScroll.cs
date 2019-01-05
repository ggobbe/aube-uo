namespace Server.Items.Cleric
{
	public class TouchOfLifeScroll : SpellScroll
	{
		[Constructable]
		public TouchOfLifeScroll() : this( 1 )
		{
		}

		[Constructable]
		public TouchOfLifeScroll( int amount ) : base( 360, 0xE39, amount )
		{
			Name = "Touch Of Life";
			Hue = 0x1F0;
		}

		public TouchOfLifeScroll( Serial serial ) : base( serial )
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
