using System;
using Server.Network;
using Server.Prompts;
using Server.Items;
using Server.Targeting;
using System.Collections.Generic;
using Server.Gumps;
using Server;
using Server.Commands;
using System.IO;
using Server.Mobiles;
using Server.Accounting;

namespace Server.Gumps
{
    public class ChangeLayer : Gump
    {

        public static Layer[] ValidLayers
        {
            get
            {
                Layer[] lays =
                {
                    Layer.Arms,
                    Layer.Bracelet,
                    Layer.Cloak,
                    Layer.Earrings,
                    Layer.Gloves,
                    Layer.Helm,
                    Layer.InnerTorso,
                    Layer.MiddleTorso,
                    Layer.Neck,
                    Layer.OuterLegs,
                    Layer.OuterTorso,
                    Layer.Pants,
                    Layer.Ring,
                    Layer.Shirt,
                    Layer.Shoes,
                    Layer.Talisman,
                    Layer.Waist
                };
                return lays;
            }
        }

        public static bool IsValid(Layer lay)
        {
            for (int i = 0; i < ValidLayers.Length; i++)
                if (ValidLayers[i] == lay)
                    return true;

            return false;
        }


        public static void Initialize()
        {
            CommandSystem.Register("ChangeLayer", AccessLevel.Player, new CommandEventHandler(AccountLogin_OnCommand));
        }

        [Usage("ChangeLayer [<command>]")]
        [Description("Permet de vérifier les informations de votre compte et de changer votre mot de passe")]

        private static void AccountLogin_OnCommand(CommandEventArgs e)
        {
            e.Mobile.Target = new ChangeLayerTarget();

        }

        private Mobile m_From;

        public ChangeLayer(Mobile owner) : base(25, 25)
        {

        }

        public override void OnResponse(NetState state, RelayInfo info)
        {


            Mobile from = state.Mobile;

            //		from.SendGump( new ChangeLayerGump( from ) );
        }


        private class ChangeLayerTarget : Target
        {
            public ChangeLayerTarget()
                : base(-1, false, TargetFlags.None)
            {
            }

            protected override void OnTarget(Mobile from, object target)
            {

                if (!(target is BaseClothing))
                {
                    from.SendMessage("Invalid target.");
                    return;
                }

                BaseClothing clothing = (BaseClothing) target;

                if (clothing is BaseHat && !clothing.PlayerConstructed)
                {
                    from.SendMessage("Invalid target..");
                    return;
                }

                if (!clothing.SkillBonuses.IsEmpty || !clothing.Attributes.IsEmpty || !clothing.Resistances.IsEmpty || clothing.IsImbued)
                {
                    from.SendMessage("Invalid target...");
                    return;
                }

                if ((clothing.RootParent != from) || !(clothing.IsChildOf(from.Backpack)))
                {
                    from.SendMessage("You must target something in your pack that is not equipped.");
                    return;
                }

                if (!(IsValid(clothing.Layer)))
                {
                    from.SendMessage("You must target something in your pack that has a valid Layer.");
                    return;
                }

                clothing.Movable = false;

                if (from.HasGump(typeof(ChangeLayerGump)))
                    from.CloseGump(typeof(ChangeLayerGump));

                from.SendGump(new ChangeLayerGump(clothing));
            }
        }
    }
}


namespace Server.Gumps
{
    public class ChangeLayerGump : Gump
    {
        private BaseClothing m_cloth;
        private Layer m_selection;
        private Layer[] lays;

        public ChangeLayerGump(BaseClothing cloth)
            : this(cloth, Layer.Invalid)
        {
        }

        public ChangeLayerGump(BaseClothing cloth, Layer selection)
            : base(50, 50)
        {
            m_cloth = cloth;
            m_selection = selection;

            this.Closable = true;
            this.Disposable = true;
            this.Dragable = true;
            this.Resizable = false;
            lays = ChangeLayer.ValidLayers;

            int space = 25;

            AddBackground();
            for (int i = 1; i < 3; i++)
            {
                AddPage(i);
                for (int j = 0; j < 9; j++)
                {
                    if ((lays.Length >= (i - 1) * 9 + j + 1) && (lays[(i - 1) * 9 + j] != m_selection))
                        AddButton(80, 117 + space * j, 1202, 1204, (i - 1) * 9 + j + 1, GumpButtonType.Reply, 0);
                }

                AddBackground(76, 116, 165, 225, 9200);
                for (int j = 0; j < 9; j++)
                {
                    if ((lays.Length >= (i - 1) * 9 + j + 1) && (lays[(i - 1) * 9 + j] != m_selection))
                        AddLabel(103, 115 + space * j, 0, lays[(i - 1) * 9 + j].ToString());
                }

                if (i == 1)
                    AddButton(213, 341, 5224, 248, 30, GumpButtonType.Page, 2);
                else if (i == 2)
                    AddButton(84, 341, 5223, 5223, 40, GumpButtonType.Page, 1);

                if (m_selection != Layer.Invalid)
                    AddButton(139, 372, 247, 248, 50, GumpButtonType.Reply, 0);

                AddButton(42, 372, 242, 243, 0, GumpButtonType.Reply, 0);

            }

        }

        private void AddBackground()
        {
            AddPage(0);
            AddBackground(4, 4, 244, 404, 9200);
            AddItem(18, 138, m_cloth.ItemID, m_cloth.Hue);
            AddLabel(49, 12, 0, @"Change Layer Menu");
            AddLabel(20, 39, 0, @"Item Name: " + (String.IsNullOrEmpty(m_cloth.Name) ? m_cloth.GetType().Name : m_cloth.Name));
            AddLabel(13, 62, 0, @"Current Layer: " + m_cloth.Layer.ToString());

            if (m_selection != Layer.Invalid)
                AddLabel(20, 87, 0, @"Change To: " + m_selection.ToString());
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile from = sender.Mobile;

            switch (info.ButtonID)
            {
                case 0:
                {
                    m_cloth.Movable = true;
                    break;
                }
                case 50:
                {
                    if (m_selection != Layer.Invalid)
                    {
                        m_cloth.Layer = m_selection;
                        m_cloth.Movable = true;
                    }

                    break;
                }
                default:
                {
                    if (from.HasGump(typeof(ChangeLayerGump)))
                        from.CloseGump(typeof(ChangeLayerGump));

                    from.SendGump(new ChangeLayerGump(m_cloth, lays[info.ButtonID - 1]));
                    break;
                }

            }
        }
    }
}
