/**
 * MacroCheck's Command (adapted from RunUO1 version created by Hyel staff)
 * @author Scriptiz
 * @date 20090913
 * @updated 20181127
 */
using System;
using Server.Accounting;
using Server.Gumps;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Commands
{
    public class MacroCommand
    {
        public static void Initialize()
        {
            CommandSystem.Register("Macro", AccessLevel.Counselor, Macro_OnCommand);
        }

        [Usage("Macro [target]")]
        [Description("Envoie un avertissement au joueur pour déterminer s'il macrote ou non.")]
        private static void Macro_OnCommand(CommandEventArgs e)
        {
            var from = e.Mobile;
            from.SendMessage("Qui suspectez vous de macrotage ?");
            from.Target = new InternalTarget();
        }

        private class InternalTarget : Target
        {
            public InternalTarget() : base(-1, false, TargetFlags.None)
            {
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                var pm = targeted as PlayerMobile;
                if (pm == null)
                {
                    from.SendMessage("Invalid target");
                    return;
                }

                if (!pm.HasGump(typeof(MacroGump)))
                {
                    pm.SendGump(new MacroGump(from, pm));
                }
            }
        }
    }

    public class MacroGump : Gump
    {
        private readonly Mobile _jailor;
        private readonly PlayerMobile _badBoy;
        private readonly DateTime _createdAt;
        private readonly int _goodButton;
        private Timer _kickTimer;

        const int NumberOfButtons = 6;

        public MacroGump(Mobile jailor, PlayerMobile badboy) : base(70, 40)
        {
            _createdAt = DateTime.UtcNow;
            _jailor = jailor;
            _badBoy = badboy;

            _goodButton = Utility.Random(NumberOfButtons);

            AddLayout();

            _kickTimer = new MacroTimer(() => CaughtInTheAct(false));
        }

        private void AddLayout()
        {
            Closable = false;
            Dragable = true;
            AddPage(0);
            AddBackground(0, 0, 326, 320, 5054);
            AddImageTiled(9, 65, 308, 240, 2624);
            AddAlphaRegion(9, 65, 308, 240);

            AddHtml(16, 10, 250, 50, "Etes-vous en train de macroter ?", false, false);

            for (var i = 0; i < NumberOfButtons; i++)
            {
                AddButton(20, 72 + i * 40, 2472, 2473, i, GumpButtonType.Reply, 0);
                AddLabel(50, 75 + i * 40, 200, _goodButton == i ? "Je suis la !" : "Je confesse, je suis un vilain macroteur.");
            }

            _badBoy.SendMessage("Vous êtes suspecté de macrotage, veuillez répondre s'il vous plait.");
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            if (_kickTimer != null)
            {
                _kickTimer.Stop();
                _badBoy.CloseGump(typeof(MacroGump));
            }

            if (_goodButton == info.ButtonID)
            {
                _jailor.SendMessage(string.Format("{0} a répondu à la vérification en {1} secondes.", _badBoy.Name, (int)DateTime.UtcNow.Subtract(_createdAt).TotalSeconds));
            }
            else
            {
                CaughtInTheAct(true);
            }
        }

        private void CaughtInTheAct(bool confessed)
        {
            NetState kicked = _badBoy.NetState;
            if (kicked != null)
            {
                ((Account) _badBoy.Account).Comments.Add(new AccountComment(_jailor.Name, "Kické pour macrotage"));
                _badBoy.SendMessage("Vous êtes kické pour cause de Macrotage.");
                kicked.Dispose();
            }

            _jailor.SendMessage(!confessed
                ? "{0} a été kické pour Macrotage suite au délai de votre avertissement."
                : "{0} a été kické pour Macrotage en avouant ses crimes.", _badBoy.Name);
        }

        private class MacroTimer : Timer
        {
            private readonly Action _action;

            public MacroTimer(Action action)
                : base(TimeSpan.FromMinutes(1))
            {
                _action = action;
                Start();
            }

            protected override void OnTick()
            {
                _action();
            }
        }
    }
}
