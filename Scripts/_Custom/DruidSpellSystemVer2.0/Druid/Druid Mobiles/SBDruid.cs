using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Mobiles
{
    public class SBDruid : SBInfo
    {
        private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBDruid()
        {
        }

        public override IShopSellInfo SellInfo
        {
            get { return m_SellInfo; }
        }

        public override List<GenericBuyInfo> BuyInfo
        {
            get { return m_BuyInfo; }
        }

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                //	Add( new GenericBuyInfo(  "Tome of Nature", typeof( DruidicSpellbook ), 15000, 10, 0xEFA, 0x48C ) );

                Add(new GenericBuyInfo(typeof(ScribesPen), 8, 10, 0xFBF, 0));

                Add(new GenericBuyInfo(typeof(BlankScroll), 5, 20, 0x0E34, 0));

                Add(new GenericBuyInfo(typeof(RefreshPotion), 20, 10, 0xF0B, 0, true));
                Add(new GenericBuyInfo(typeof(AgilityPotion), 20, 10, 0xF08, 0, true));
                Add(new GenericBuyInfo(typeof(NightSightPotion), 20, 10, 0xF06, 0, true));
                Add(new GenericBuyInfo(typeof(LesserHealPotion), 20, 10, 0xF0C, 0, true));
                Add(new GenericBuyInfo(typeof(StrengthPotion), 20, 10, 0xF09, 0, true));
                Add(new GenericBuyInfo(typeof(LesserPoisonPotion), 20, 10, 0xF0A, 0, true));
                Add(new GenericBuyInfo(typeof(LesserCurePotion), 20, 10, 0xF07, 0, true));
                Add(new GenericBuyInfo(typeof(LesserExplosionPotion), 26, 10, 0xF0D, 0, true));

                Add(new GenericBuyInfo("Petrified Wood", typeof(PetrifiedWood), 50, 20, 0x97A, 0));
                Add(new GenericBuyInfo("Fertile Earth", typeof(FertileEarth), 50, 20, 0xF81, 0));
                Add(new GenericBuyInfo("Spring Water", typeof(SpringWater), 50, 20, 0xE24, 0));
                Add(new GenericBuyInfo("Pumice", typeof(Pumice), 50, 20, 0xF8B, 0));
                Add(new GenericBuyInfo("Fen Moss", typeof(FenMoss), 50, 20, 0x26B7, 0));
                Add(new GenericBuyInfo("Destroying Angel", typeof(DestroyingAngel), 50, 20, 0xEF1, 0));
                Add(new GenericBuyInfo("Firefly Scroll", typeof(FireflyScroll), 22, 20, 0xE39, 0x58B));
                Add(new GenericBuyInfo("Lure Stone Scroll", typeof(LureStoneScroll), 63, 20, 0xE39, 0x58B));
                Add(new GenericBuyInfo("Nature's Passage Scroll", typeof(NaturesPassageScroll), 63, 20, 0xE39, 0x58B));
            }
        }

        public class InternalSellInfo : GenericSellInfo
        {
            public InternalSellInfo()
            {
                Add(typeof(WizardsHat), 15);
                Add(typeof(PetrifiedWood), 10);
                Add(typeof(FertileEarth), 10);
                Add(typeof(FenMoss), 10);
                Add(typeof(SpringWater), 10);
                Add(typeof(Pumice), 10);
                Add(typeof(DestroyingAngel), 10);
            }
        }
    }
}
