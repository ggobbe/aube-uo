using Server.Commands;

namespace Server.Gumps
{
    public class AccountLogin
    {
        public static void Initialize()
        {
            CommandSystem.Register("Compte", AccessLevel.Player, new CommandEventHandler(AccountLogin_OnCommand));
        }

        [Usage("Compte [<command>]")]
        [Description("Permet de vérifier les informations de votre compte et de changer votre mot de passe")]
        private static void AccountLogin_OnCommand(CommandEventArgs e)
        {
            e.Mobile.SendGump(new AccountInfo(e.Mobile));
        }
    }
}
