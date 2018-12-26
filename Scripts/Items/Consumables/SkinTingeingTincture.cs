using System;
using System.Linq;
using Server.Gumps;
using Server.Mobiles;

namespace Server.Items
{
    public class SkinTingeingTincture : Item
    {
        public override int LabelNumber { get { return 1114770; } } //Skin Tingeing Tincture

        public static void Initialize()
        {
            // Force elves to select a hue we like
            EventSink.Login += (args) =>
            {
                var pm = args.Mobile as PlayerMobile;
                if (pm == null)
                {
                    return;
                }

                var hues = InternalGump.ElfSkinHues.Select(h => pm.Race.ClipSkinHue(h & 0x3FFF) | 0x8000);
                if (pm.Race == Race.Elf && !hues.Contains(pm.Hue))
                {
                    var tincture = new SkinTingeingTincture();
                    pm.AddToBackpack(tincture);
                    BaseGump.SendGump(new InternalGump(pm, tincture, true));
                }
            };
        }

        [Constructable]
        public SkinTingeingTincture()
            : base(0xEFF)
        {
            Hue = 90;
        }

        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);
            list.Add(1114771); // Apply Directly to Forehead
        }

        public override void OnDoubleClick(Mobile m)
        {
            if (IsChildOf(m.Backpack) && m is PlayerMobile)
            {
                if (!m.HasGump(typeof(InternalGump)))
                {
                    BaseGump.SendGump(new InternalGump((PlayerMobile)m, this));
                }
            }
        }

        public SkinTingeingTincture(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        private class InternalGump : BaseGump
        {
            public override int GetTypeID()
            {
                return 0xF3EA1;
            }

            public SkinTingeingTincture Item { get; set; }
            public int SelectedHue { get; set; }

            public InternalGump(PlayerMobile pm, SkinTingeingTincture item, bool force = false)
                : base(pm, 50, 50)
            {
                Item = item;
                Closable = !force;
                Dragable = !force;
            }

            public override void AddGumpLayout()
            {
                AddBackground(0, 0, 460, 300, 2620);

                int[] list = GetHueList();

                int rows = User.Race == Race.Human ? 8 : 6;
                int start = User.Race == Race.Human ? 40 : 80;
                bool elf = User.Race == Race.Elf;

                int x = start;
                int y = start;
                int displayHue;

                for (int i = 0; i < list.Length; i++)
                {
                    if (i > 0 && i % rows == 0)
                    {
                        x = start;
                        y += 22;
                    }

                    displayHue = elf ? list[i] - 1 : list[i];

                    AddImage(x, y, 210, displayHue);
                    AddButton(x, y, 212, 212, i + 100, GumpButtonType.Reply, 0);

                    x += 21;
                }

                displayHue = SelectedHue != 0 ? SelectedHue : User.Hue ^ 0x8000;

                if (elf)
                    displayHue--;

                AddImage(240, 0, GetPaperdollImage(), displayHue);

                AddButton(250, 260, 239, 238, 1, GumpButtonType.Reply, 0);
                AddButton(50, 260, 242, 241, 0, GumpButtonType.Reply, 0);
            }

            public override void OnResponse(RelayInfo info)
            {
                int button = info.ButtonID;

                if (button >= 100)
                {
                    button -= 100;

                    int[] list = GetHueList();

                    if (button >= 0 && button < list.Length)
                    {
                        SelectedHue = list[button];
                        Refresh(true, false);
                    }
                }
                else if (button == 1 && Item != null)
                {
                    if (SelectedHue != 0)
                    {
                        User.Hue = User.Race.ClipSkinHue(SelectedHue & 0x3FFF) | 0x8000;
                        Item.Delete();
                    }
                }
            }

            private int GetPaperdollImage()
            {
                if (User.Race == Race.Human)
                {
                    return User.Female ? 13 : 12;
                }

                if (User.Race == Race.Elf)
                {
                    return User.Female ? 15: 14;
                }

                if (User.Race == Race.Gargoyle)
                {
                    return User.Female ? 665 : 666;
                }

                return 0;
            }

            private int[] GetHueList()
            {
                if (User.Race == Race.Human)
                {
                    return HumanSkinHues;
                }

                if (User.Race == Race.Elf)
                {
                    return ElfSkinHues;
                }

                if (User.Race == Race.Gargoyle)
                {
                    return GargoyleSkinHues;
                }

                return new int[0];
            }

            private static int[] _HumanSkinHues;
            private static int[] _ElfSkinHues;
            private static int[] _GargoyleSkinHues;

            public static int[] HumanSkinHues
            {
                get
                {
                    if (_HumanSkinHues == null)
                    {
                        _HumanSkinHues = new int[57];

                        for (int i = 0; i < _HumanSkinHues.Length; i++)
                        {
                            _HumanSkinHues[i] = i + 1001;
                        }
                    }

                    return _HumanSkinHues;
                }
            }

            public static int[] ElfSkinHues
            {
                get
                {
                    if (_ElfSkinHues == null)
                    {
                        _ElfSkinHues = new int[]
                        {
                            2307, 2309, 2311, 2312,  // peau
                            1447, 1449, 1451,        // (oliviatre)
                            1833, 1830, 1828,        // tan
                            2419, 2421, 2424,        // gris
                            1801, 1803, 1806,        // gris vert
                            1519, 1521, 1523         // rosé
                        };
                    }

                    return _ElfSkinHues;
                }
            }

            public static int[] GargoyleSkinHues
            {
                get
                {
                    if (_GargoyleSkinHues == null)
                    {
                        _GargoyleSkinHues = new int[25];

                        for (int i = 0; i < _GargoyleSkinHues.Length; i++)
                        {
                            _GargoyleSkinHues[i] = i + 1754;
                        }
                    }

                    return _GargoyleSkinHues;
                }
            }
        }
    }
}