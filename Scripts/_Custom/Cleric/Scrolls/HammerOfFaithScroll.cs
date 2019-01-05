namespace Server.Items.Cleric
{
	public class HammerOfFaithScroll : SpellScroll
	{
		[Constructable]
		public HammerOfFaithScroll() : this( 1 )
		{
		}

		[Constructable]
		public HammerOfFaithScroll( int amount ) : base( 354, 0xE39, amount )
		{
			Name = "Hammer Of Faith";
			Hue = 0x1F0;
		}

		public HammerOfFaithScroll( Serial serial ) : base( serial )
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
