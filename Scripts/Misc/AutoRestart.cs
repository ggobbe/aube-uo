using System;
using Server.Commands;

namespace Server.Misc
{
    public class AutoRestart : Timer
    {
        private static readonly TimeSpan RestartDelay = TimeSpan.FromSeconds(10);  // how long the server should remain active before restart (period of 'server wars')
        private static readonly TimeSpan WarningDelay = TimeSpan.FromMinutes(1.0); // at what interval should the shutdown message be displayed?

        public static DateTime RestartTime { get; private set; }
        public static bool Restarting { get; private set; }
        public static Timer Timer { get; private set; }
        public static bool DoneWarning { get; private set; }

        public static bool Enabled = Config.Get("AutoRestart.Enabled", false);
        public static int Hour = Config.Get("AutoRestart.Hour", 12);
        public static int Minutes = Config.Get("AutoRestart.Minute", 0);
        public static int Frequency = Config.Get("AutoRestart.Frequency", 24);

        public AutoRestart()
            : base(TimeSpan.FromSeconds(1.0), TimeSpan.FromSeconds(1.0))
        {
        }

        public static void Initialize()
        {
			CommandSystem.Register("Restart", AccessLevel.Administrator, new CommandEventHandler(Restart_OnCommand));
			CommandSystem.Register("Shutdown", AccessLevel.Administrator, new CommandEventHandler(Shutdown_OnCommand));

            if (Enabled)
            {
                var now = DateTime.Now;
                var force = new DateTime(now.Year, now.Month, now.Day, Hour, Minutes, 0);

                if (now > force)
                {
                    force += TimeSpan.FromHours(Frequency);
                }

                RestartTime = force;

                BeginTimer();

                Utility.WriteConsoleColor(ConsoleColor.Magenta, "[Auto Restart] Configured for {0}:{1}:00, every {2} hours!", RestartTime.Hour, RestartTime.Minute, Frequency);
                Utility.WriteConsoleColor(ConsoleColor.Magenta, "[Auto Restart] Next Shard Restart: {0}", RestartTime.ToString());
            }
        }

        public static void Restart_OnCommand(CommandEventArgs e)
        {
            if (Restarting)
            {
                e.Mobile.SendMessage("The server is already restarting.");
            }
            else
            {
                e.Mobile.SendMessage("You have initiated server restart.");

                StopTimer();

                Timer.DelayCall(TimeSpan.FromSeconds(1), () =>
                    {
                        AutoSave.Save();

                        Restarting = true;
                        TimedShutdown(true);
                    });
            }
        }

		public static void Shutdown_OnCommand(CommandEventArgs e)
		{
		    if (e.Length > 1)
		    {
		        e.Mobile.SendMessage("Shutdown <seconds>");
		        return;
		    }

			if (Restarting)
			{
				e.Mobile.SendMessage("The server is already shutting down.");
			}
			else
			{
				e.Mobile.SendMessage("You have initiated server shutdown.");

			    if (e.Length == 1)
			    {
			        ScheduledShutdown(e.GetInt32(0));
			        return;
			    }

                StopTimer();

                Timer.DelayCall(TimeSpan.FromSeconds(1), () =>
                {
                    AutoSave.Save();
                    Restarting = true;

                    TimedShutdown(false);
                });
			}
		}

        private static void ScheduledShutdown(int seconds)
        {
            var delay = TimeSpan.FromSeconds(seconds);
            RestartTime = DateTime.UtcNow.Add(delay);
            var warningInterval = delay >= TimeSpan.FromMinutes(15) ? TimeSpan.FromMinutes(5) :
                delay >= TimeSpan.FromMinutes(5) ? TimeSpan.FromMinutes(1) :
                TimeSpan.FromSeconds(30);

            Timer.DelayCall(warningInterval, warningInterval, () =>
            {
                var remaining = RestartTime - DateTime.UtcNow;
                BroadcastsShutdown(remaining);
            });

            BroadcastsShutdown(delay);
            Timer.DelayCall(delay - RestartDelay, () =>
            {
                AutoSave.Save();
                Restarting = true;

                TimedShutdown(false);
            });
        }

        private static void BroadcastsShutdown(TimeSpan delay)
        {
            if (delay < TimeSpan.FromSeconds(15))
            {
                return;
            }

            if (delay >= TimeSpan.FromMinutes(2))
            {
                World.Broadcast(0x22, true, "The server will be going down in about {0} minute{1}.", delay.TotalMinutes.ToString("F0"), delay.TotalMinutes == 1 ? "" : "s");
            }
            else
            {
                World.Broadcast(0x22, true, "The server will be going down in about {0} seconds!", delay.TotalSeconds.ToString("F0"));
            }
        }

        private static void BeginTimer()
        {
            StopTimer();

            Timer = new AutoRestart();
            Timer.Start();
        }

        private static void StopTimer()
        {
            if (Timer != null)
            {
                Timer.Stop();
                Timer = null;
            }
        }

		protected override void OnTick()
        {
            if (Restarting || !Enabled)
                return;

            if (WarningDelay > TimeSpan.Zero && !DoneWarning && RestartTime - WarningDelay < DateTime.Now)
            {
                World.Broadcast(0x22, true, "The server will be going down in about {0} minute{1}.", WarningDelay.TotalMinutes.ToString(), WarningDelay.TotalMinutes == 1 ? "" : "s");

                DoneWarning = true;
                return;
            }

            if (DateTime.Now < RestartTime)
            {
                return;
            }

            AutoSave.Save();
            Restarting = true;

            TimedShutdown(true);
        }

        private static void TimedShutdown(bool restart)
        {
            World.Broadcast(0x22, true, String.Format("The server will be going down in about {0} seconds!", RestartDelay.TotalSeconds.ToString()));
            Timer.DelayCall(RestartDelay, rest =>
                {
                    Core.Kill(rest);
                },
                restart);
        }
    }
}
