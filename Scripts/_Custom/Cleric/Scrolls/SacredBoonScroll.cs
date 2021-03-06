namespace Server.Items.Cleric
{
	public class SacredBoonScroll : SpellScroll
	{
		[Constructable]
		public SacredBoonScroll() : this( 1 )
		{
		}

		[Constructable]
		public SacredBoonScroll( int amount ) : base( 357, 0xE39, amount )
		{
			Name = "Sacred Boon";
			Hue = 0x1F0;
		}

		public SacredBoonScroll( Serial serial ) : base( serial )
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
