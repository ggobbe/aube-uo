using System.Collections.Generic;
using Server.Items;
using Server.Mobiles;

namespace Server.Aube.Mobiles.Vendors.SBInfos
{
    public class SBValentine : SBInfo
    {
        private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();


        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }

        public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                Add(new GenericBuyInfo(typeof(ValentinesCardEast), 2500, 20, 0x0EBE, 0xE8));
                Add(new GenericBuyInfo(typeof(ValentinesCardSouth), 2500, 20, 0x0EBD, 0xE8));
                Add(new GenericBuyInfo(typeof(HeartShapedBox), 10000, 20, 0x49CC, 0));
                Add(new GenericBuyInfo(typeof(ValentineBearA), 25000, 20, 0x48E0, 0));
                Add(new GenericBuyInfo(typeof(ValentineBearB), 25000, 20, 0x48E2, 0));
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
