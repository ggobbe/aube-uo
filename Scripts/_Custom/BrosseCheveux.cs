using System.Collections.Generic;
using Server.Gumps;
using Server.Network;

namespace Server.Items
{
    public class BrosseCheveux : Item, IDyable
    {
        [Constructable]
        public BrosseCheveux() : base(0x1372)
        {
            Name = "Brosse à cheveux";
            Weight = 1;
            Stackable = false;
            Hue = 23;
        }

        public BrosseCheveux(Serial serial) : base(serial)
        {
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (!((from.BodyValue == 0x190) || (from.BodyValue == 0x191) || (from.BodyValue == 0x25D) || (from.BodyValue == 0x25E)))
            {
                from.SendMessage("Désolé, vous ne semblez pas morphologiquements compatible");
                return;
            }

            if (!IsChildOf(from.Backpack))
            {
                from.SendMessage("Ce serait beaucoup plus pratique s'il était sur vous");
                return;
            }

            from.SendGump(new BrosseCheveuxGump(from));
        }

        public virtual bool Dye(Mobile from, DyeTub sender)
        {
            if (Deleted)
                return false;

            if (RootParent is Mobile && from != RootParent)
                return false;

            Hue = sender.DyedHue;

            return true;
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int) 0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class BrosseCheveuxGump : Gump
    {
        // Short, Long, ponytail, 2 tails, pageboy, Buns, Curly, Topknot, Mohawk
        private readonly List<List<int>> _WomanHairs = new List<List<int>>
        {
            new List<int> {60700, 60701, 60702, 60902, 60710, 60712, 60900, 60903, 60703},
            new List<int> {60573, 60584, 60820, 60824, 60825, 60827, 60828, 60998, 60845, 60846},
            new List<int> {60847, 60848, 60849, 60850, 60851, 60852, 60853, 60854, 60855, 60856},
            new List<int> {60857, 60858, 60859, 60860, 60861, 60862, 60863, 60864, 60949, 60988}
        };

        private readonly List<List<int>> _ManHairs = new List<List<int>>
        {
            new List<int> {50700, 50701, 50702, 50902, 50710, 50712, 50900, 50903, 50703},
            new List<int> {50573, 50584, 50820, 50824, 50825, 50827, 50828, 50998, 50845, 50846},
            new List<int> {50847, 50848, 50849, 50850, 50851, 50852, 50853, 50854, 50855, 50856},
            new List<int> {50857, 50858, 50859, 50860, 50861, 50862, 50863, 50864, 50949, 50988}
        };

        private readonly int[] _HairIds =
        {
            0x203B, 0x203C, 0x203D, 0x2049, 0x2045, 0x2046, 0x2047, 0x204a, 0x2044, 0x2294,
            0x2295, 0x2296, 0x2297, 0x2298, 0x2299, 0x229A, 0x229B, 0x229C, 0x229D, 0x229E,
            0x229F, 0x22A0, 0x22A1, 0x22A2, 0x22A3, 0x22A4, 0x22A5, 0x22A6, 0x22A7, 0x22A8,
            0x22A9, 0x22AA, 0x22AB, 0x22AC, 0x22AD, 0x22AE, 0x22AF, 0x22B0, 0x22B1
        };

        public BrosseCheveuxGump(Mobile from)
            : base(PropsConfig.GumpOffsetX, PropsConfig.GumpOffsetY)
        {
            Closable = true;
            Disposable = true;
            Dragable = true;
            Resizable = false;
            AddPage(0);

            AddBackground(0, 0, 1190, 410, 2620);

            var hairs = from.Female ? _WomanHairs : _ManHairs;

            var buttonId = 0;
            for (var i = 0; i < hairs.Count; i++)
            {
                for (var j = 0; j < hairs[i].Count; j++)
                {
                    AddImage(0 + j * 115, i * 75, hairs[i][j]);
                    AddButton(40 + j * 115, 55 + i * 75, 0xA9A, 0xA9B, buttonId++, GumpButtonType.Reply, 0);
                }
            }

            AddLabel(40, 16, 0x111, "Choix de coiffure");
            AddLabel(40, 370, 0x111, "Vous devez vous déconnecter pour que les autres joueurs voient votre nouvelle coupe.");
        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
            Mobile from = state.Mobile;

            if (info.ButtonID >= 0 && info.ButtonID < _HairIds.Length)
            {
                from.PlaySound(0x57);
                from.HairItemID = _HairIds[info.ButtonID];
            }
        }
    }
}
