namespace Server.Items.Cleric
{
	public class RestorationScroll : SpellScroll
	{
		[Constructable]
		public RestorationScroll() : this( 1 )
		{
		}

		[Constructable]
		public RestorationScroll( int amount ) : base( 356, 0xE39, amount )
		{
			Name = "Restoration";
			Hue = 0x1F0;
		}

		public RestorationScroll( Serial serial ) : base( serial )
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
