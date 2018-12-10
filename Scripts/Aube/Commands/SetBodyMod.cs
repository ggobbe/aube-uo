using Server.Targeting;

namespace Server.Commands
{
    public class SetBodyModCommand
    {
        public static void Initialize()
        {
            CommandSystem.Register("SetBodyMod", AccessLevel.GameMaster, BodyMod_OnCommand);
        }

        [Usage("SetBodyMod [value]")]
        [Description("Change le BodyMod d'un mobile")]
        private static void BodyMod_OnCommand(CommandEventArgs arg)
        {
            if (arg.Length != 1)
            {
                arg.Mobile.SendMessage("SetBodyMod <value>");
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
