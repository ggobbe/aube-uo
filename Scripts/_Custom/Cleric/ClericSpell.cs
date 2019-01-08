using System;
using Server;
using Server.Spells;
using Server.Network;

namespace Server.Spells.Cleric
{
	public abstract class ClericSpell : Spell
	{
		public virtual int SpellLevel{ get{ return 1; } }

		private static int[] m_ManaTable = new int[] { 0, 4, 6, 9, 11, 14, 20, 40, 50 };

        public abstract int RequiredTithing { get; }

        public abstract double RequiredSkill { get; }

        public abstract string SpellDescription { get; }

		public override int GetMana()
		{
			return m_ManaTable[SpellLevel];
		}

		public override TimeSpan CastDelayBase
		{
			get
			{
				return TimeSpan.FromSeconds( (3 + SpellLevel) * CastDelaySecondsPerTick );
			}
		}

		public override SkillName CastSkill{ get{ return SkillName.Forensics; } }
		public override bool ClearHandsOnCast{ get{ return false; } }

		public ClericSpell( Mobile caster, Item scroll, SpellInfo info ) : base( caster, scroll, info )
		{
		}

		public override bool CheckCast()
		{
			if ( !base.CheckCast() )
				return false;

			if ( Caster.Skills[CastSkill].Value < RequiredSkill )
			{
				Caster.SendMessage( "You must have at least " + RequiredSkill + " Spirit Speak to invoke this prayer" );
				return false;
			}
			else if ( Caster.TithingPoints < RequiredTithing )
			{
				Caster.SendMessage( "You must have at least " + RequiredTithing + " Piety to invoke this prayer." );
				return false;
			}
			else if ( Caster.Mana < ScaleMana( GetMana() ) )
			{
				Caster.SendMessage( "You must have at least " + GetMana() + " Mana to invoke this prayer." );
				return false;
			}

			return true;
		}

		public override bool CheckFizzle()
		{
			if ( !base.CheckFizzle() )
				return false;

			int tithing = RequiredTithing;
			double min, max;

			GetCastSkills( out min, out max );

			if ( AosAttributes.GetValue( Caster, AosAttribute.LowerRegCost ) > Utility.Random( 100 ) )
				tithing = 0;

			int mana = ScaleMana( GetMana() );

			if ( Caster.Skills[CastSkill].Value < RequiredSkill )
			{
				Caster.SendMessage( "You must have at least " + RequiredSkill + " Spirit Speak to invoke this prayer." );
				return false;
			}
			else if ( Caster.TithingPoints < tithing )
			{
				Caster.SendMessage( "You must have at least " + tithing + " Piety to invoke this prayer." );
				return false;
			}
			else if ( Caster.Mana < mana )
			{
				Caster.SendMessage( "You must have at least " + mana + " Mana to invoke this prayer." );
				return false;
			}

			Caster.TithingPoints -= tithing;

			return true;
		}

		public override void SayMantra()
		{
			Caster.PublicOverheadMessage( MessageType.Regular, 0x3B2, false, Info.Mantra );
			Caster.PlaySound( 0x24A );
		}

		public override void DoFizzle()
		{
			Caster.PlaySound( 0x1D6 );
			Caster.NextSpellTime = Core.TickCount;
		}

		public override void DoHurtFizzle()
		{
			Caster.PlaySound( 0x1D6 );
		}

		public override void OnDisturb( DisturbType type, bool message )
		{
			base.OnDisturb( type, message );

			if ( message )
				Caster.PlaySound( 0x1D6 );
		}

		public override void OnBeginCast()
		{
			base.OnBeginCast();

			Caster.FixedEffect( 0x37C4, 10, 42, 4, 3 );
		}

		public override void GetCastSkills( out double min, out double max )
		{
			min = RequiredSkill;
			max = RequiredSkill + 40.0;
		}
	}
}
