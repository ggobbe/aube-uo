using System.Linq;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Commands
{
    public class ClearTitlesCommand
    {
        public static void Initialize()
        {
            CommandSystem.Register("ClearTitles", AccessLevel.Administrator, BodyMod_OnCommand);
        }

        [Usage("ClearTitles")]
        [Description("Remove titles on PlayerMobiles")]
        private static void BodyMod_OnCommand(CommandEventArgs args)
        {
            var players = World.Mobiles.Values.Where(m => m is PlayerMobile).Cast<PlayerMobile>().ToList();

            args.Mobile.SendMessage("Clearing titles for {0} PlayerMobiles", players.Count());

            foreach (var player in players)
            {
                player.PaperdollSkillTitle = null;
                player.CurrentChampTitle = null;
                player.OverheadTitle = null;
                player.DisplayGuildAbbr = true;
                player.SubtitleSkillTitle = null;
                player.SelectRewardTitle(-1, true);
                player.CurrentVeteranTitle = -1;
                player.DisplayGuildTitle = true;
            }

            args.Mobile.SendMessage("DONE");

            World.Save();
        }
    }
}
