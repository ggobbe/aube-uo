using Server.Commands;

namespace Server.Gumps
{
    public class FeedingGump : Gump
    {
        public static void Initialize()
        {
            CommandSystem.Register("Faim", AccessLevel.Player, Alimentation_OnCommand);
            CommandSystem.Register("Soif", AccessLevel.Player, Alimentation_OnCommand);
        }

        [Usage("Faim")]
        [Aliases("Soif")]
        [Description("Affiche le degré de faim et de soif du joueur en cours.")]
        private static void Alimentation_OnCommand(CommandEventArgs e)
        {
            var m = e.Mobile;
            if (!m.HasGump(typeof(FeedingGump)))
                e.Mobile.SendGump(new FeedingGump(m));
        }

        public FeedingGump(Mobile owner)
            : this(owner, PropsConfig.GumpOffsetX, PropsConfig.GumpOffsetY)
        {
        }

        public FeedingGump(Mobile owner, int x, int y)
            : base(x, y)    // offset x et y
        {
            Closable = true;
            Dragable = true;
            Resizable = false;

            AddPage(0);
            AddBackground(0, 0, 164, 61, 9200);

            // Hunger background (yellow or red)
            AddImageTiled(45, 15, 109, 11, owner.Hunger > 10 ? 2057 : 2053);

            // Hunger foreground (blue)
            int hunger = (int)((owner.Hunger / 20.0) * 109);
            if(hunger > 109) hunger = 109;	// To enable hunger boosts
            AddImageTiled(45, 15, hunger, 11, 2054);

            // Thirst background (yellow or red)
            AddImageTiled(45, 35, 109, 11, owner.Thirst > 10 ? 2057 : 2053);

            // Thirst foreground (blue)
            int thirst = (int)((owner.Thirst / 20.0) * 109);
            if(thirst > 109) thirst = 109;	// To enable thirst boosts
            AddImageTiled(45, 35, thirst, 11, 2054);

            AddLabel(10, 10, 0, @"Faim");
            AddLabel(10, 30, 0, @"Soif");
        }
    }
}
