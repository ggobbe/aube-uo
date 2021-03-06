namespace Server.Items.Cleric
{
	public class SmiteScroll : SpellScroll
	{
		[Constructable]
		public SmiteScroll() : this( 1 )
		{
		}

		[Constructable]
		public SmiteScroll( int amount ) : base( 359, 0xE39, amount )
		{
			Name = "Smite";
			Hue = 0x1F0;
		}

		public SmiteScroll( Serial serial ) : base( serial )
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
