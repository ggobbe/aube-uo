namespace Server.Items.Cleric
{
	public class PurgeScroll : SpellScroll
	{
		[Constructable]
		public PurgeScroll() : this( 1 )
		{
		}

		[Constructable]
		public PurgeScroll( int amount ) : base( 355, 0xE39, amount )
		{
			Name = "Purge";
			Hue = 0x1F0;
		}

		public PurgeScroll( Serial serial ) : base( serial )
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
