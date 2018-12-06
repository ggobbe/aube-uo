using System;
using System.IO;

namespace Server.Aube.Misc
{
    public class SpeechLogging
    {
        private static StreamWriter m_Output;

        private static DateTime m_CreatedAt;

        public static void Initialize()
        {
            EventSink.Speech += EventSink_OnSpeech;
        }

        private static void EventSink_OnSpeech(SpeechEventArgs args)
        {
            if (args.Mobile == null)
            {
                return;
            }

            try
            {
                var now = DateTime.UtcNow;

                if (m_CreatedAt.Date != now.Date)
                {
                    CreateNewLogFile();
                }

                var region = "unknown";
                if (args.Mobile.Region != null && !string.IsNullOrWhiteSpace(args.Mobile.Region.Name))
                {
                    region = args.Mobile.Region.Name;
                }

                m_Output.WriteLine("[{0:s}] {1} ({2}): {3}", now, args.Mobile.Name, region, args.Speech);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error whilst logging speech: {0}", e);
            }
        }

        private static void CreateNewLogFile()
        {
            if (!Directory.Exists("Logs"))
                Directory.CreateDirectory("Logs");

            var directory = Path.Combine("Logs", "Speech");

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            m_CreatedAt = DateTime.UtcNow;
            m_Output = new StreamWriter(Path.Combine(directory, string.Format("{0:yyyy-MM-dd}.log", m_CreatedAt)), true) {AutoFlush = true};
        }
    }
}
