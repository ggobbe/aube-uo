using System;
using System.IO;

namespace Server.Aube.Misc
{
    public class AubeLogger
    {
        private readonly string _LogName;

        public AubeLogger(string logName)
        {
            _LogName = logName;
        }

        public void Log(string log)
        {
            try
            {
                var now = DateTime.UtcNow;

                using (var output = GetLogWriter(now))
                {
                    output.WriteLine("[{0:s}] {1}", now, log);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error whilst logging: {0}", e);
            }
        }

        private StreamWriter GetLogWriter(DateTime dt)
        {
            const string logsDir = "Logs";

            if (!Directory.Exists(logsDir))
                Directory.CreateDirectory(logsDir);

            var directory = Path.Combine(logsDir, _LogName);

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            var filename = string.Format("{0:yyyy-MM-dd}.log", dt);

            return new StreamWriter(Path.Combine(directory, filename), true) {AutoFlush = true};
        }
    }
}
