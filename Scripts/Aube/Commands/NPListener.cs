/***************************************************************************
 *                               NPListener.cs
 *                            -------------------
 *   creation             : May 25, 2010
 *   copyright            : (C) Scriptiz
 *   email                : maeliguul@hotmail.com
 *   version              : 2018-12-13
 *
 ***************************************************************************/

/***************************************************************************
 *
 *   This program is free software; you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation; either version 2 of the License, or
 *   (at your option) any later version.
 *
 ***************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using Server.Mobiles;

namespace Server.Misc
{
    public class NPListener
    {
        private const int _Distance = 15;

        private static Dictionary<Mobile, IList<Mobile>> _ListenedMobiles = new Dictionary<Mobile, IList<Mobile>>();

        public static void Initialize()
        {
            EventSink.Speech += SpeechToNPC;

            Timer.DelayCall(TimeSpan.FromMinutes(1), TimeSpan.FromMinutes(1), CleanListeners);
        }

        public static void AddListenedMobile(Mobile listener, Mobile listened)
        {
            if (listener == null || listened == null) return;

            if (!_ListenedMobiles.ContainsKey(listened))
            {
                _ListenedMobiles.Add(listened, new List<Mobile>());
            }

            if (!_ListenedMobiles[listened].Contains(listener))
            {
                _ListenedMobiles[listened].Add(listener);
            }
        }

        public static bool RemoveListenedMobile(Mobile listener, Mobile listened)
        {
            if (listener == null || listened == null)
                return false;

            if (!_ListenedMobiles.ContainsKey(listened))
                return false;

            if (!_ListenedMobiles[listened].Contains(listener))
                return false;

            _ListenedMobiles[listened].Remove(listener);

            if (!_ListenedMobiles[listened].Any())
            {
                _ListenedMobiles.Remove(listened);
            }

            return true;
        }

        private static void SpeechToNPC(SpeechEventArgs args)
        {
            if (args.Mobile == null) return;

            var speaker = args.Mobile;

            foreach (var listened in speaker.GetMobilesInRange(_Distance))
            {
                if (_ListenedMobiles.ContainsKey(listened))
                {
                    var listeners = _ListenedMobiles[listened];

                    foreach (var listener in listeners.Where(l => l.NetState != null))
                    {
                        if (listener.Map != listened.Map || listener.GetDistanceToSqrt(listened) >= _Distance)
                        {
                            listener.SendMessage(listened.SpeechHue, "<" + listened.Name + "> " + speaker.Name + ": " + args.Speech);
                        }
                    }
                }
            }
        }

        private static void CleanListeners()
        {
            if (!_ListenedMobiles.Any()) return;

            foreach (var listened in _ListenedMobiles.Keys.ToList())
            {
                foreach (var listener in _ListenedMobiles[listened].ToList())
                {
                    if (listener.NetState == null)
                    {
                        _ListenedMobiles[listened].Remove(listener);
                    }
                }

                if (!_ListenedMobiles[listened].Any())
                {
                    _ListenedMobiles.Remove(listened);
                }
            }
        }
    }
}
