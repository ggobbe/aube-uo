using System;
using Server;
using Server.Items;

namespace Server.Items.Cleric
{
	public class ClericBag : Bag
	{
		[Constructable]
		public ClericBag()
		{
			Hue = 0x1F0;
			DropItem( new AngelicFaithScroll() );
			DropItem( new BanishEvilScroll() );
			DropItem( new DampenSpiritScroll() );
			DropItem( new DivineFocusScroll() );
			DropItem( new HammerOfFaithScroll() );
			DropItem( new PurgeScroll() );
			DropItem( new RestorationScroll() );
			DropItem( new SacredBoonScroll() );
			DropItem( new SacrificeScroll() );
			DropItem( new SmiteScroll() );
			DropItem( new TouchOfLifeScroll() );
			DropItem( new TrialByFireScroll() );
		}

		public ClericBag( Serial serial ) : base( serial )
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
