using Server.Gumps;
using Server.Mobiles;

namespace Server.Misc
{
    public class Feeding
    {
        public static void Initialize()
        {
            EventSink.HungerChanged += RefreshGump;
            EventSink.ThirstChanged += RefreshGump;
        }

        private static void RefreshGump(HungerChangedEventArgs args)
        {
            UpdateGump(args.Mobile);
        }

        private static void RefreshGump(ThirstChangedEventArgs args)
        {
            UpdateGump(args.Mobile);
        }

        private static void UpdateGump(Mobile m)
        {
            if (m is PlayerMobile && m.HasGump(typeof(FeedingGump)))
            {
                var gump = m.FindGump(typeof(FeedingGump));
                var x = gump.X;
                var y = gump.Y;
                m.CloseGump(typeof(FeedingGump));
                m.SendGump(new FeedingGump(m, x, y));
            }
        }
    }
}
