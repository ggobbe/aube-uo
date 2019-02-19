namespace Server.Aube.Misc
{
    public class SpeechLogging
    {
        private static readonly AubeLogger _Logger = new AubeLogger("Speech");

        public static void Initialize()
        {
            EventSink.Speech += EventSink_OnSpeech;
            EventSink.PartySpeech += EventSink_OnPartySpeech;
        }

        private static void EventSink_OnSpeech(SpeechEventArgs args)
        {
            HandleSpeech(args.Mobile, args.Speech);
        }

        private static void EventSink_OnPartySpeech(PartySpeechEventArgs args)
        {
            HandleSpeech(args.Mobile, args.PartySpeech);
        }

        private static void HandleSpeech(Mobile m, string speech)
        {
            if (m == null)
            {
                return;
            }

            var region = "unknown";
            if (m.Region != null && !string.IsNullOrWhiteSpace(m.Region.Name))
            {
                region = m.Region.Name;
            }

            _Logger.Log(string.Format("{0} ({1}): {2}", m.Name, region, speech));
        }
    }
}
