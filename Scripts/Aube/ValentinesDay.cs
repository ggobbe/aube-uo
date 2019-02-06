using System;
using Server.Items;

namespace Server.Aube
{
    public static class ValentinesDay
    {
        public static Type[] Artifacts = new Type[]
        {
            typeof(HeartShapedBox), typeof(ValentineBearA), typeof(ValentineBearB)
        };

        public static bool IsValentineHolidays()
        {
            var now = Now();
            return now >= new DateTime(now.Year, 2, 7) && now < new DateTime(now.Year, 2, 15, 8, 0, 0);
        }

        public static bool IsValentineDay()
        {
            var now = Now();
            return now.Date == new DateTime(now.Year, 2, 14).Date;
        }

        public static double GetChance()
        {
            var now = Now();
            var chance = -0.051f + Math.Pow(Math.Min(14, now.Day), 3) * 0.00015f;
            return IsValentineHolidays() ? Math.Min(Math.Max(0.01, chance), 0.35) : 0;
        }

        public static int GetHue()
        {
            return Utility.RandomDouble() < .001 ? 0x47E : 0xE8;
        }

        private static DateTime Now()
        {
            // Let's use server time as most players play in the same country
            return DateTime.Now;
        }
    }
}
