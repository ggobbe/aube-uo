using Server.Commands;
using Server.Network;
using Server.Targeting;

namespace Server.Aube.Commands
{
    public class Say
    {
        public static void Initialize()
        {
            CommandSystem.Register("Say", AccessLevel.GameMaster, Say_OnCommand);
        }

        [Usage("Say <text>")]
        [Description("Forces Mobile or Item to Say <text>.")]
        public static void Say_OnCommand(CommandEventArgs e)
        {
            string toSay = e.ArgString.Trim();

            if (string.IsNullOrWhiteSpace(toSay))
            {
                e.Mobile.SendMessage("Format: Say \"<text>\"");
                return;
            }

            e.Mobile.Target = new SayTarget(toSay);
        }

        private class SayTarget : Target
        {
            private string m_Speech;

            public SayTarget(string say) : base(-1, false, TargetFlags.None)
            {
                m_Speech = say;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (targeted is Mobile)
                {
                    var m = (Mobile) targeted;

                    if (from != m && from.AccessLevel > m.AccessLevel)
                    {
                        CommandLogging.WriteLine(from, "{0} {1} forcing speech on {2}", from.AccessLevel, CommandLogging.Format(from), CommandLogging.Format(m));
                        m.Say(m_Speech);
                    }
                }
                else if (targeted is Item)
                {
                    var targ = (Item) targeted;
                    targ.PublicOverheadMessage(MessageType.Regular, Utility.RandomDyedHue(), false, m_Speech);
                }
                else
                    from.SendMessage("Invalid Target Type");
            }
        }
    }
}
