using Server.Gumps.Cleric;

namespace Server.Items.Cleric
{
	public class ClericSpellbook : Spellbook
	{
        public override SpellbookType SpellbookType{ get{ return SpellbookType.Cleric; } }
        public override int BookOffset{ get{ return 350; } }
        public override int BookCount{ get{ return 12; } }

		[Constructable]
		public ClericSpellbook() : this( (ulong)0, false )
		{
		}

		[Constructable]
		public ClericSpellbook( bool full ) : this( (ulong)0, full )
		{
		}

		[Constructable]
		public ClericSpellbook( ulong content, bool full ) : base( content, 0xEFA )
		{
			Hue = 0x1F0;
			Name = "Holy Book";
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( from.AccessLevel == AccessLevel.Player )
			{
				Container pack = from.Backpack;
				if( !(Parent == from || (pack != null && Parent == pack)) )
				{
					from.SendMessage( "The spellbook must be in your backpack [and not in a container within] to open." );
					return;
				}
			}

            from.CloseGump(typeof(ClericSpellBookGump));
            from.SendGump(new ClericSpellBookGump(from, this));
        }

		public ClericSpellbook( Serial serial ) : base( serial )
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
