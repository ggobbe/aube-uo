using System.Collections.Generic;
using Server.Items;
using Server.Mobiles;

namespace Server.Aube.Mobiles.Vendors.SBInfos
{
    public class SBPeddlerB : SBInfo
    {
        private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBPeddlerB()
        {
        }

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                Add(new GenericBuyInfo(typeof(PottedPlant), 1200, 3, 0x11CA, 0));
                Add(new GenericBuyInfo(typeof(PottedPlant1), 1200, 3, 0x11CB, 0));
                Add(new GenericBuyInfo(typeof(PottedPlant2), 1200, 3, 0x11CC, 0));
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
