namespace Server.Items.Cleric
{
	public class TrialByFireScroll : SpellScroll
	{
		[Constructable]
		public TrialByFireScroll() : this( 1 )
		{
		}

		[Constructable]
		public TrialByFireScroll( int amount ) : base( 361, 0xE39, amount )
		{
			Name = "Trial By Fire";
			Hue = 0x1F0;
		}

		public TrialByFireScroll( Serial serial ) : base( serial )
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
