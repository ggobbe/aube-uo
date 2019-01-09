using System.Collections.Generic;
using Server.Items;
using Server.Mobiles;

namespace Server.Aube.Mobiles.Vendors.SBInfos
{
    public class SBPeddlerC : SBInfo
    {
        private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBPeddlerC()
        {
        }

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                Add(new GenericBuyInfo(typeof(ShojiScreen), 1000, 5, 0x24CB, 0));
                Add(new GenericBuyInfo(typeof(BambooScreen), 1000, 5, 0x24D0, 0));
            }
        }

        public class InternalSellInfo : GenericSellInfo
        {
            public InternalSellInfo()
            {
            }
        }
    }
}
