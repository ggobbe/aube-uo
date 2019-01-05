namespace Server.Items.Cleric
{
	public class AngelicFaithScroll : SpellScroll
	{
		[Constructable]
		public AngelicFaithScroll() : this( 1 )
		{
		}

		[Constructable]
		public AngelicFaithScroll( int amount ) : base( 350, 0xE39, amount )
		{
			Name = "Angelic Faith";
			Hue = 0x1F0;
		}

		public AngelicFaithScroll( Serial serial ) : base( serial )
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
