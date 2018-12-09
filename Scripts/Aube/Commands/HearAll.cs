using System;
using System.Collections.Generic;
using System.Linq;
using Server.Commands;

namespace Server.Aube.Commands
{
    public class HearAll
    {
        private static readonly IList<Mobile> _Listeners = new List<Mobile>();

        public static void Initialize()
        {
            EventSink.Speech += EventSink_OnSpeech;

            CommandSystem.Register("HearAll", AccessLevel.GameMaster, HearAll_OnCommand);
            CommandSystem.Register("peep", AccessLevel.GameMaster, HearAll_OnCommand);

            Timer.DelayCall(TimeSpan.FromMinutes(1), TimeSpan.FromMinutes(1), CleanListeners);
        }

        [Usage("HearAll")]
        [Description("Hear every speech no matter how far you are from its source.")]
        private static void HearAll_OnCommand(CommandEventArgs e)
        {
            if (_Listeners.Contains(e.Mobile))
            {
                RemoveListener(e.Mobile);
                e.Mobile.SendMessage("Peeping mode OFF");
            }
            else
            {
                AddListener(e.Mobile);
                e.Mobile.SendMessage("Peeping mode ON");
            }
        }

        private static void EventSink_OnSpeech(SpeechEventArgs args)
        {
            if (!_Listeners.Any())
            {
                return;
            }

            if (args.Mobile == null)
            {
                return;
            }

            var region = "unknown";
            if (args.Mobile.Region != null && !string.IsNullOrWhiteSpace(args.Mobile.Region.Name))
            {
                region = args.Mobile.Region.Name;
            }

            var message = string.Format("{0} ({1}): {2}", args.Mobile.Name, region, args.Speech);

            foreach (var listener in _Listeners.Where(l => l.NetState != null && l != args.Mobile))
            {
                listener.SendMessage(message);
            }
        }

        private static void CleanListeners()
        {
            foreach (var listener in _Listeners.Where(l => l.NetState == null).ToList())
            {
                RemoveListener(listener);
            }
        }

        private static void AddListener(Mobile m)
        {
            Console.WriteLine("[HearAll] Listener added: {0} ({1})", m.Name, m.Account != null ? m.Account.Username : "null");
            _Listeners.Add(m);
        }

        private static void RemoveListener(Mobile m)
        {
            Console.WriteLine("[HearAll] Listener removed: {0} ({1})", m.Name, m.Account != null ? m.Account.Username : "null");
            _Listeners.Remove(m);
        }
    }
}
