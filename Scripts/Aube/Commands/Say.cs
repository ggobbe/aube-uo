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
            CommandSystem.Register("Emo", AccessLevel.GameMaster, Emote_OnCommand);
            CommandSystem.Register("Emote", AccessLevel.GameMaster, Emote_OnCommand);
        }

        [Usage("Say <text>")]
        [Description("Forces Mobile or Item to Say <text>.")]
        public static void Say_OnCommand(CommandEventArgs e)
        {
            SayIt(e, false);
        }

        [Usage("Emote <text>")]
        [Description("Forces Mobile or Item to Emote <text>.")]
        public static void Emote_OnCommand(CommandEventArgs e)
        {
            SayIt(e, true);
        }

        private static void SayIt(CommandEventArgs e, bool emote)
        {
            string toSay = e.ArgString.Trim();

            if (emote)
            {
                if (!toSay.StartsWith("*"))
                    toSay = string.Format("*{0}", toSay);

                if (!toSay.EndsWith(("*")))
                    toSay = string.Format("{0}*", toSay);
            }

            if (string.IsNullOrWhiteSpace(toSay))
            {
                e.Mobile.SendMessage("Format: Say \"<text>\"");
                return;
            }

            e.Mobile.Target = new SayTarget(toSay, emote);
        }

        private class SayTarget : Target
        {
            private readonly string m_Speech;
            private readonly bool m_Emote;

            public SayTarget(string say, bool emote) : base(-1, false, TargetFlags.None)
            {
                m_Speech = say;
                m_Emote = emote;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (targeted is Mobile)
                {
                    var m = (Mobile) targeted;

                    if (from != m && from.AccessLevel > m.AccessLevel)
                    {
                        CommandLogging.WriteLine(from, "{0} {1} forcing speech on {2}", from.AccessLevel, CommandLogging.Format(from), CommandLogging.Format(m));
                        if (m_Emote)
                            m.Emote(m_Speech);
                        else
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
