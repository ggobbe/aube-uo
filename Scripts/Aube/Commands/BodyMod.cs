using Server.Targeting;

namespace Server.Commands
{
    public class BodyModCommand
    {
        public static void Initialize()
        {
            CommandSystem.Register("BodyMod", AccessLevel.Counselor, BodyMod_OnCommand);
        }

        [Usage("BodyMod [value]")]
        [Description("Change le BodyMod d'un mobile")]
        private static void BodyMod_OnCommand(CommandEventArgs arg)
        {
            if (arg.Length != 1)
            {
                arg.Mobile.SendMessage("BodyMod <value>");
                return;
            }

            arg.Mobile.Target = new InternalTarget(arg.GetInt32(0));
        }

        private class InternalTarget : Target
        {
            private readonly int _Value;

            public InternalTarget(int value) : base(-1, false, TargetFlags.None)
            {
                _Value = value;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                var pm = targeted as Mobile;
                if (pm == null)
                {
                    from.SendMessage("Invalid target");
                    return;
                }

                pm.BodyMod = _Value;
            }
        }
    }
}
