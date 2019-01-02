using System;
using System.Collections;
using Server.Items;
using Server.ContextMenus;
using Server.Mobiles;
using Server.Misc;
using Server.Network;

namespace Server.Mobiles
{
	public class EvilDruidLord : BaseCreature
	{

		[Constructable]
		public EvilDruidLord() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{

            Name = "Evil Druid Lord";
			Hue = 1045;
            HairItemID = 0x203D;
            HairHue = 2101;
			if ( this.Female = Utility.RandomBool() )
			{
				Body = 0x191;
			//	Name = NameList.RandomName( "female" );
				AddItem( new Skirt());
			}
			else
			{
				Body = 0x190;
			//	Name = NameList.RandomName( "male" );
				AddItem( new ShortPants());
			}

			SetStr(850 );
			SetDex(115 );
			SetInt(200 );

			SetHits(64500 );
			SetMana( 300 );

			SetDamage( 40, 53 );

            SetDamageType(ResistanceType.Physical, 100);

			SetSkill( SkillName.Macing, 107.5 );
			SetSkill( SkillName.Tactics, 87.5 );
			SetSkill( SkillName.Magery, 93.5 );
			SetSkill( SkillName.EvalInt, 93.5 );
			SetSkill( SkillName.MagicResist, 93.5 );
			SetSkill( SkillName.Meditation, 76.5 );

			SetResistance( ResistanceType.Physical, 65 );
			SetResistance( ResistanceType.Fire, 65 );
			SetResistance( ResistanceType.Cold, 65 );
			SetResistance( ResistanceType.Poison, 65 );
			SetResistance( ResistanceType.Energy, 65 );

			Fame = 6000;
			Karma = -15000;

			AddItem( new Boots());
			AddItem( new Robe(1444));
			AddItem( new LeatherChest() );
			AddItem( new LeatherGloves() );
			AddItem( new LeatherGorget() );
			AddItem( new LeatherArms() );
			AddItem( new LeatherLegs() );
            DruidStaff weapon = new DruidStaff();
            weapon.Movable = false;
            AddItem(weapon);

            switch (Utility.Random(3))
            {
                case 0: PackItem( new SpringWater(4)); break;
                case 1: PackItem( new Pumice(4)); break;
                case 2: PackItem( new PetrifiedWood(4)); break;
            }
		} 

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
		}
        public override bool BardImmune { get { return !Core.SE; } }
        public override bool Unprovokable { get { return Core.SE; } }
        public override bool Uncalmable { get { return Core.SE; } }
		public override bool AlwaysMurderer{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
        public override bool IsScaredOfScaryThings { get { return false; } }
        public override bool IsScaryToPets { get { return true; } }

		public EvilDruidLord( Serial serial ) : base( serial )
		{
		}
        public override void OnDeath(Container c)
        {
            base.OnDeath(c);
            switch (Utility.Random(21))
            {
                case 0: c.DropItem(new SpringOfLifeScroll()); break;
                case 1: c.DropItem(new VolcanicEruptionScroll()); break;
                case 2: c.DropItem(new EnchantedGroveScroll()); break;
                case 3: c.DropItem(new HollowReedScroll()); break;
                case 4: c.DropItem(new MushroomGatewayScroll()); break;
                case 5: c.DropItem(new RestorativeSoilScroll()); break;
                case 6: c.DropItem(new DeadlySporesScroll()); break;
                //   default: break;

            }
            if (0.03 > Utility.RandomDouble())
            {
                switch (Utility.Random(2))
                {
                    case 0: c.DropItem(new DruidicSpellbook()); break;
                    case 1: c.DropItem(new DruidCloak()); break;
                    //     default: break;
                }
            }

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