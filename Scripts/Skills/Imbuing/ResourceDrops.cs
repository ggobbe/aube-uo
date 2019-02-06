using Server;
using System;
using System.Collections.Generic;
using Server.Aube;
using Server.Mobiles;

namespace Server.Items
{
    public class IngredientDropEntry
    {
        private Type m_CreatureType;
        private bool m_DropMultiples;
        private string m_Region;
        private double m_Chance;
        private Type[] m_Ingredients;

        public Type CreatureType { get { return m_CreatureType; } }
        public bool DropMultiples { get { return m_DropMultiples; } }
        public string Region { get { return m_Region; } }
        public double Chance { get { return m_Chance; } }
        public Type[] Ingredients { get { return m_Ingredients; } }

        public IngredientDropEntry(Type creature, bool dropMultiples, double chance, params Type[] ingredients)
            : this(creature, dropMultiples, null, chance, ingredients)
        {
        }

        public IngredientDropEntry(Type creature, bool dropMultiples, string region, double chance, params Type[] ingredients)
        {
            m_CreatureType = creature;
            m_Ingredients = ingredients;
            m_DropMultiples = dropMultiples;
            m_Region = region;
            m_Chance = chance;
        }

        private static List<IngredientDropEntry> m_IngredientTable;
        public static List<IngredientDropEntry> IngredientTable { get { return m_IngredientTable; } }

        public static void Initialize()
        {
            EventSink.CreatureDeath += OnCreatureDeath;

            m_IngredientTable = new List<IngredientDropEntry>();

            // Imbuing Gems
            m_IngredientTable.Add(new IngredientDropEntry(typeof(AncientLichRenowned), true, .5, ImbuingGems));
            m_IngredientTable.Add(new IngredientDropEntry(typeof(DevourerRenowned), true, .5, ImbuingGems));
            m_IngredientTable.Add(new IngredientDropEntry(typeof(FireElementalRenowned), true, .5, ImbuingGems));
            m_IngredientTable.Add(new IngredientDropEntry(typeof(GrayGoblinMageRenowned), true, .5, ImbuingGems));
            m_IngredientTable.Add(new IngredientDropEntry(typeof(GreenGoblinAlchemistRenowned), true, .5, ImbuingGems));
            m_IngredientTable.Add(new IngredientDropEntry(typeof(PixieRenowned), true, .5, ImbuingGems));
            m_IngredientTable.Add(new IngredientDropEntry(typeof(RakktaviRenowned), true, .5, ImbuingGems));
            m_IngredientTable.Add(new IngredientDropEntry(typeof(SkeletalDragonRenowned), true, .5, ImbuingGems));
            m_IngredientTable.Add(new IngredientDropEntry(typeof(TikitaviRenowned), true, .5, ImbuingGems));
            m_IngredientTable.Add(new IngredientDropEntry(typeof(VitaviRenowned), true, .5, ImbuingGems));

            //Bottle of Ichor/Spider Carapace
            m_IngredientTable.Add(new IngredientDropEntry(typeof(TrapdoorSpider), true, .05, typeof(SpiderCarapace)));
            m_IngredientTable.Add(new IngredientDropEntry(typeof(WolfSpider), true, .15, typeof(BottleIchor)));
            m_IngredientTable.Add(new IngredientDropEntry(typeof(SentinelSpider), true, .15, typeof(BottleIchor)));
            m_IngredientTable.Add(new IngredientDropEntry(typeof(Navrey), true, .5, typeof(BottleIchor), typeof(SpiderCarapace)));

            //Reflective wolf eye
            m_IngredientTable.Add(new IngredientDropEntry(typeof(ClanSSW), true, .2, typeof(ReflectiveWolfEye)));
            m_IngredientTable.Add(new IngredientDropEntry(typeof(LeatherWolf), true, .2, typeof(ReflectiveWolfEye)));

            //Faery Dust - drop from silver sapling mini champ
            m_IngredientTable.Add(new IngredientDropEntry(typeof(FairyDragon), true, .25, typeof(FaeryDust)));
            m_IngredientTable.Add(new IngredientDropEntry(typeof(Pixie), true, .25, typeof(FaeryDust)));
            m_IngredientTable.Add(new IngredientDropEntry(typeof(SAPixie), true, .25, typeof(FaeryDust)));
            m_IngredientTable.Add(new IngredientDropEntry(typeof(Wisp), true, .25, typeof(FaeryDust)));
            m_IngredientTable.Add(new IngredientDropEntry(typeof(DarkWisp), true, .25, typeof(FaeryDust)));

            m_IngredientTable.Add(new IngredientDropEntry(typeof(FairyDragon), true, .25, typeof(FeyWings)));

            //Boura Pelt
            m_IngredientTable.Add(new IngredientDropEntry(typeof(RuddyBoura), true, .05, typeof(BouraPelt)));
            m_IngredientTable.Add(new IngredientDropEntry(typeof(LowlandBoura), true, .05, typeof(BouraPelt)));
            m_IngredientTable.Add(new IngredientDropEntry(typeof(HighPlainsBoura), true, 1.0, typeof(BouraPelt)));

            //Silver snake skin
            m_IngredientTable.Add(new IngredientDropEntry(typeof(SilverSerpent), true, .10, typeof(SilverSnakeSkin)));

            //Harpsichord Roll
            m_IngredientTable.Add(new IngredientDropEntry(typeof(BaseCreature), true, "Ilshenar", .05, typeof(HarpsichordRoll)));

            //Void Orb/Vial of Vitriol
            m_IngredientTable.Add(new IngredientDropEntry(typeof(BaseVoidCreature), true, .05, typeof(VoidOrb)));
            m_IngredientTable.Add(new IngredientDropEntry(typeof(UnboundEnergyVortex), true, .25, typeof(VoidOrb), typeof(VialOfVitriol)));
            m_IngredientTable.Add(new IngredientDropEntry(typeof(AcidSlug), true, .10, typeof(VialOfVitriol)));

            //Slith Tongue
            m_IngredientTable.Add(new IngredientDropEntry(typeof(Slith), true, .05, typeof(SlithTongue)));
            m_IngredientTable.Add(new IngredientDropEntry(typeof(StoneSlith), true, .05, typeof(SlithTongue)));
            m_IngredientTable.Add(new IngredientDropEntry(typeof(ToxicSlith), true, .05, typeof(SlithTongue)));

            //Raptor Teeth
            m_IngredientTable.Add(new IngredientDropEntry(typeof(Raptor), true, .05, typeof(RaptorTeeth)));

            //Daemon Claw
            m_IngredientTable.Add(new IngredientDropEntry(typeof(FireDaemon), true, .6, typeof(DaemonClaw)));
            m_IngredientTable.Add(new IngredientDropEntry(typeof(FireDaemonRenowned), true, 1.0, typeof(DaemonClaw)));

            //Goblin Blood
            m_IngredientTable.Add(new IngredientDropEntry(typeof(GreenGoblin), true, .10, typeof(GoblinBlood)));
            m_IngredientTable.Add(new IngredientDropEntry(typeof(GreenGoblinAlchemist), true, .10, typeof(GoblinBlood)));
            m_IngredientTable.Add(new IngredientDropEntry(typeof(GreenGoblinScout), true, .10, typeof(GoblinBlood)));
            m_IngredientTable.Add(new IngredientDropEntry(typeof(GrayGoblin), true, .10, typeof(GoblinBlood)));
            m_IngredientTable.Add(new IngredientDropEntry(typeof(GrayGoblinKeeper), true, .10, typeof(GoblinBlood)));
            m_IngredientTable.Add(new IngredientDropEntry(typeof(GrayGoblinMage), true, .10, typeof(GoblinBlood)));
            m_IngredientTable.Add(new IngredientDropEntry(typeof(EnslavedGoblinKeeper), true, .25, typeof(GoblinBlood)));
            m_IngredientTable.Add(new IngredientDropEntry(typeof(EnslavedGoblinMage), true, .25, typeof(GoblinBlood)));
            m_IngredientTable.Add(new IngredientDropEntry(typeof(EnslavedGoblinScout), true, .25, typeof(GoblinBlood)));
            m_IngredientTable.Add(new IngredientDropEntry(typeof(EnslavedGrayGoblin), true, .25, typeof(GoblinBlood)));
            m_IngredientTable.Add(new IngredientDropEntry(typeof(EnslavedGreenGoblin), true, .25, typeof(GoblinBlood)));
            m_IngredientTable.Add(new IngredientDropEntry(typeof(EnslavedGreenGoblinAlchemist), true, .25, typeof(GoblinBlood)));

            //Lava Serpent Crust
            m_IngredientTable.Add(new IngredientDropEntry(typeof(LavaElemental), true, .25, typeof(LavaSerpentCrust)));
            m_IngredientTable.Add(new IngredientDropEntry(typeof(FireElementalRenowned), true, 1.0, typeof(LavaSerpentCrust)));

            //Undying Flesh
            m_IngredientTable.Add(new IngredientDropEntry(typeof(UndeadGuardian), true, .10, typeof(UndyingFlesh)));
            m_IngredientTable.Add(new IngredientDropEntry(typeof(Niporailem), true, 1.0, typeof(UndyingFlesh)));
            m_IngredientTable.Add(new IngredientDropEntry(typeof(ChaosVortex), true, .25, typeof(UndyingFlesh)));

            //Crystaline Blackrock
            m_IngredientTable.Add(new IngredientDropEntry(typeof(AgapiteElemental), true, .25, typeof(CrystallineBlackrock)));
            m_IngredientTable.Add(new IngredientDropEntry(typeof(BronzeElemental), true, .25, typeof(CrystallineBlackrock)));
            m_IngredientTable.Add(new IngredientDropEntry(typeof(CopperElemental), true, .25, typeof(CrystallineBlackrock)));
            m_IngredientTable.Add(new IngredientDropEntry(typeof(GoldenElemental), true, .25, typeof(CrystallineBlackrock)));
            m_IngredientTable.Add(new IngredientDropEntry(typeof(ShadowIronElemental), true, .25, typeof(CrystallineBlackrock)));
            m_IngredientTable.Add(new IngredientDropEntry(typeof(ValoriteElemental), true, .25, typeof(CrystallineBlackrock)));
            m_IngredientTable.Add(new IngredientDropEntry(typeof(VeriteElemental), true, .25, typeof(CrystallineBlackrock)));

            m_IngredientTable.Add(new IngredientDropEntry(typeof(ChaosVortex), true, .25, typeof(ChagaMushroom)));

            m_IngredientTable.Add(new IngredientDropEntry(typeof(BaseCreature), false, "Ilshenar", .05, typeof(DelicateScales),
                typeof(ArcanicRuneStone), typeof(PowderedIron), typeof(EssenceBalance), typeof(CrushedGlass), typeof(CrystallineBlackrock),
                typeof(ElvenFletching), typeof(CrystalShards), typeof(Lodestone), typeof(AbyssalCloth), typeof(SeedOfRenewal)));

            m_IngredientTable.Add(new IngredientDropEntry(typeof(BaseCreature), false, "Ilshenar", .05, typeof(EssenceSingularity)));
            m_IngredientTable.Add(new IngredientDropEntry(typeof(BaseCreature), false, "Ilshenar", .05, typeof(EssenceDiligence)));
            m_IngredientTable.Add(new IngredientDropEntry(typeof(BaseCreature), false, "Ilshenar", .05, typeof(EssenceAchievement)));
            m_IngredientTable.Add(new IngredientDropEntry(typeof(BaseCreature), false, "Ilshenar", .05, typeof(EssencePrecision)));
            m_IngredientTable.Add(new IngredientDropEntry(typeof(BaseCreature), false, "Ilshenar", .05, typeof(EssencePassion)));
            m_IngredientTable.Add(new IngredientDropEntry(typeof(BaseCreature), false, "Ilshenar", .05, typeof(EssenceOrder)));
            m_IngredientTable.Add(new IngredientDropEntry(typeof(BaseCreature), false, "Ilshenar", .05, typeof(GoblinBlood), typeof(EssenceControl)));
            m_IngredientTable.Add(new IngredientDropEntry(typeof(BaseCreature), false, "Ilshenar", .05, typeof(EssenceDirection)));
            m_IngredientTable.Add(new IngredientDropEntry(typeof(BaseCreature), false, "Ilshenar", .05, typeof(EssenceFeeling)));
            m_IngredientTable.Add(new IngredientDropEntry(typeof(BaseCreature), false, "Ilshenar", .05, typeof(EssencePersistence)));

            if (ValentinesDay.IsValentineHolidays())
            {
                var chance = ValentinesDay.GetChance();
                m_IngredientTable.Add(new IngredientDropEntry(typeof(BaseCreature), false, chance, typeof(ValentineChocolate)));
            }
        }

        public static void OnCreatureDeath(CreatureDeathEventArgs e)
        {
            BaseCreature bc = e.Creature as BaseCreature;
            Container c = e.Corpse;

            if (bc != null && c != null && !c.Deleted && !bc.Controlled && !bc.Summoned)
            {
                CheckDrop(bc, c);
            }

            if (e.Killer is BaseVoidCreature)
            {
                ((BaseVoidCreature)e.Killer).Mutate(VoidEvolution.Killing);
            }
        }

        public static void CheckDrop(BaseCreature bc, Container c)
        {
            if (m_IngredientTable != null)
            {
                foreach (IngredientDropEntry entry in m_IngredientTable)
                {
                    if (entry == null)
                        continue;

                    if (entry.Region != null)
                    {
                        string reg = entry.Region;

                        if (reg == "TerMur" && c.Map != Map.TerMur)
                        {
                            continue;
                        }
                        else if (reg == "Ilshenar" && c.Map != Map.Ilshenar)
                        {
                            continue;
                        }
                        else if (reg == "Abyss" && (c.Map != Map.TerMur || c.X < 235 || c.X > 1155 || c.Y < 40 || c.Y > 1040))
                        {
                            continue;
                        }
                        else if (reg != "TerMur" && reg != "Abyss" && reg != "Ilshenar")
                        {
                            Server.Region r = Server.Region.Find(c.Location, c.Map);

                            if (r == null || !r.IsPartOf(entry.Region))
                                continue;
                        }
                    }

                    if (bc.GetType() != entry.CreatureType && !bc.GetType().IsSubclassOf(entry.CreatureType))
                    {
                        continue;
                    }

                    double toBeat = entry.Chance;

                    if (entry.Region == "Ilshenar")
                    {
                        const int minFame = 17000;
                        if (bc.Fame < minFame)
                        {
                            continue;
                        }
                        toBeat *= (bc.Fame - minFame) / 10000.0;
                    }

                    List<Item> drops = new List<Item>();

                    if (bc is BaseVoidCreature)
                    {
                        toBeat *= ((BaseVoidCreature)bc).Stage + 1;
                    }

                    if (entry.DropMultiples)
                    {
                        foreach (Type type in entry.Ingredients)
                        {
                            if (toBeat >= Utility.RandomDouble())
                            {
                                Item drop = Loot.Construct(type);

                                if (drop != null)
                                    drops.Add(drop);
                            }
                        }
                    }
                    else if (toBeat >= Utility.RandomDouble())
                    {
                        Item drop = Loot.Construct(entry.Ingredients);

                        if (drop != null)
                            drops.Add(drop);
                    }

                    foreach (Item item in drops)
                    {
                        c.DropItem(item);
                    }

                    ColUtility.Free(drops);
                }
            }
        }

        public static Type[] ImbuingGems =
        {
            typeof(FireRuby),
            typeof(WhitePearl),
            typeof(BlueDiamond),
			typeof(Turquoise)
        };
    }
}
