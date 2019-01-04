using System;
using System.Collections;
using Server.Aube;
using Server.Engines.XmlSpawner2;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using Server.Items;
using PSys= Server.Engines.PartySystem;
using Server.Spells;

namespace Server.Spells.Cleric
{
	public class SacrificeSpell : ClericSpell
	{
		public override int SpellLevel{ get{ return 1; } }

		private static SpellInfo m_Info = new SpellInfo(
				"Sacrifice", "Adoleo",
				212,
				9041
			   );

		public override int RequiredTithing{ get{ return 5; } }
		public override double RequiredSkill{ get{ return 5.0; } }
        public override string SpellDescription
        {
            get
            {
                return "The caster sacrifices himself for his allies. Whenever damaged, all party members are healed a small percent of the damage dealt. The caster still takes damage.";
            }
        }

		public static void Initialize()
        {
            var m = new PlayerMobile();
			PlayerEvent.OnWeaponHit += InternalCallback;
		}

		public SacrificeSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override void OnCast()
		{
			if ( CheckSequence() )
			{
				if ( !Caster.CanBeginAction( typeof( SacrificeSpell ) ) )
				{
					Caster.EndAction( typeof( SacrificeSpell ) );
					Caster.PlaySound( 0x244 );
					Caster.FixedParticles( 0x3709, 1, 30, 9965, 1152, 0, EffectLayer.Waist );
					Caster.FixedParticles( 0x376A, 1, 30, 9502, 1152, 0, EffectLayer.Waist );
					Caster.SendMessage( "You stop sacrificing your essence for the well being of others." );
				}
				else
				{
					Caster.BeginAction( typeof( SacrificeSpell ) );
					Caster.FixedParticles( 0x3709, 1, 30, 9965, 1153, 7, EffectLayer.Waist );
					Caster.FixedParticles( 0x376A, 1, 30, 9502, 1153, 3, EffectLayer.Waist );
					Caster.PlaySound( 0x244 );
					Caster.SendMessage( "You begin sacrificing your essence for the well being of others." );
				}
			}
			FinishSequence();
		}

		private static void InternalCallback( OnWeaponHitEventArgs e )
		{
			if ( !e.Defender.CanBeginAction( typeof( SacrificeSpell ) ) )
			{
				PSys.Party p = PSys.Party.Get( e.Defender );

				if ( p != null )
				{
					foreach( PSys.PartyMemberInfo info in p.Members )
					{
						Mobile m = info.Mobile;

						if ( m != e.Defender && m != e.Attacker && !m.Poisoned )
						{
							m.Heal( e.DamageGiven / 2 );
							m.PlaySound( 0x202 );
							m.FixedParticles( 0x376A, 1, 62, 9923, 3, 3, EffectLayer.Waist );
							m.FixedParticles( 0x3779, 1, 46, 9502, 5, 3, EffectLayer.Waist );
						}
					}
				}
			}
		}
	}
}
