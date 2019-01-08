using System;
using System.Collections.Generic;
using System.Linq;
using Server.Commands;
using Server.Items;
using Server.Targeting;

namespace Server.Aube.Commands
{
    public class Vider
    {
        public static void Initialize()
        {
            CommandSystem.Register("Vider", AccessLevel.Player, Vider_OnCommand);
        }

        [Usage("Vider")]
        [Description("Vide un récipient dans un autre")]
        private static void Vider_OnCommand(CommandEventArgs arg)
        {
            var m = arg.Mobile;
            m.SendMessage("Choississez le récipient à vider.");
            m.Target = new InternalTarget1();
        }

        private class InternalTarget1 : Target
        {
            public InternalTarget1() : base(1, false, TargetFlags.None)
            {
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                var container = targeted as Container;
                if (container == null)
                {
                    from.SendMessage("Ceci n'est pas un récipient valide");
                    return;
                }

                if (!container.IsChildOf(from.Backpack))
                {
                    from.SendMessage("Le récipient doit être dans votre sac.");
                    return;
                }

                from.SendMessage("Choississez le récipient dans lequel vider le précédent.");
                from.Target = new InternalTarget2(container);
            }
        }

        private class InternalTarget2 : Target
        {
            private readonly Container _source;

            public InternalTarget2(Container source) : base(1, false, TargetFlags.None)
            {
                _source = source;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                var container = targeted as Container;
                if (container == null)
                {
                    from.SendMessage("Ceci n'est pas un récipient valide");
                    return;
                }

                if (!container.CheckHold(from, _source, true, true))
                {
                    return;
                }

                var q = new Queue<Item>();

                foreach (var item in _source.Items.ToList())
                {
                    if (item.CheckItemUse(from) && item.CheckLift(from) && item.VerifyMove(from))
                    {
                        q.Enqueue(item);
                    }
                    else
                    {
                        from.SendMessage("Cet objet ne peut être déplacé:");
                        TextDefinition.SendMessageTo(from, new TextDefinition(item));
                    }
                }

                if (!q.Any())
                {
                    return;
                }

                from.SendSound(container.GetDroppedSound(_source), container.GetWorldLocation());
                foreach (var item in q)
                {
                    if (!container.TryDropItem(from, item, true))
                    {
                        from.SendMessage("Cet objet n'a pas pu être déplacé:");
                        TextDefinition.SendMessageTo(from, new TextDefinition(item));
                    }
                }
            }
        }
    }
}
