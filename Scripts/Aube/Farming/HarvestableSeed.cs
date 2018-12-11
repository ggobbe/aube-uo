using System;
using System.Linq;
using System.Reflection;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Items
{
    public interface ISeedable
    {
        Item GetSeed();
        void Consume();
    }

    public class HarvestableSeed : Item
    {
        public static readonly TimeSpan DefaultDelay = TimeSpan.FromMinutes(20);

        private Type m_GrownItem;
        private bool m_Ready;
        private TimeSpan m_Delay;
        private int m_CropID;
        private static Timer m_Timer;

        private readonly int[] _dirtStaticIds = {9, 13001};

        public HarvestableSeed(Type grownitem, TimeSpan delay, string name, int seedId, int cropId) : base(0xCB5)
        {
            ItemID = seedId;
            m_CropID = cropId;
            Weight = 0.1;
            m_Ready = false;

            m_GrownItem = grownitem;
            m_Delay = delay;
            Name = string.Format("{0} Seed", name);
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool Ready
        {
            get { return m_Ready; }
            set { m_Ready = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public TimeSpan Delay
        {
            get { return m_Delay; }
            set { m_Delay = value; }
        }

        public HarvestableSeed(Serial serial)
            : base(serial)
        {
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (!Ready && IsChildOf(from.Backpack))
            {
                from.SendMessage("Où voulez vous planter ceci ?");
                from.BeginTarget(-1, true, TargetFlags.None, Plant_OnTarget);
            }
            else if (Ready && m_GrownItem != null)
            {
                Item dropped = (Item) Activator.CreateInstance(m_GrownItem);
                dropped.Amount = Utility.Random(2, 5);
                from.AddToBackpack(dropped);
                from.SendMessage("Vous récoltez {0} {1}", dropped.Amount, m_GrownItem);
                Delete();
            }
            else if (Movable)
            {
                from.SendLocalizedMessage(1042001); // That must be in your pack for you to use it.
            }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int) 0); // version

            writer.Write(m_Delay);
            writer.Write(m_Ready);
            writer.Write(m_CropID);
            writer.Write(m_GrownItem.ToString());
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            m_Delay = reader.ReadTimeSpan();
            m_Ready = reader.ReadBool();
            m_CropID = reader.ReadInt();
            m_GrownItem = Assembly.GetExecutingAssembly().GetType(reader.ReadString());

            if (Movable == false && !m_Ready)
                StartTimer(m_Delay);
        }

        public virtual void StartTimer(TimeSpan delay)
        {
            m_Timer = Timer.DelayCall(delay, ReadyToHarvest);
            m_Timer.Start();
        }

        public virtual void ReadyToHarvest()
        {
            Ready = true;
            ItemID = m_CropID;
            Hue = 0;
        }

        public virtual void Plant_OnTarget(Mobile from, object targ)
        {
            if (!(targ is LandTarget))
            {
                from.SendMessage("Il vaut mieux mettre ceci dans le sol");
                return;
            }

            Point3D loc = ((LandTarget) targ).Location;
            if (!from.InRange(loc, 3) || !from.InLOS(targ) || !from.CanSee(targ))
            {
                from.SendMessage("Cet endroit est inaccessible");
                return;
            }

            int tileId = ((LandTarget) targ).TileID;
            if (!_dirtStaticIds.Contains(tileId))
            {
                from.SendMessage("Impossible de faire pousser quelque chose dans ce type de sol");
                return;
            }

            var items = from.Map.GetItemsInRange(loc, 0);
            if (items.Any(i => i is HarvestableSeed))
            {
                from.SendMessage("Il y a déjà une pousse à cet endroit");
                return;
            }

            DropToWorld(from, loc);
            Movable = false;
            StartTimer(m_Delay);
        }

        public override bool HandlesOnMovement
        {
            get { return true; }
        }

        public bool CheckRange(Point3D loc, Point3D oldLoc, int range)
        {
            return CheckRange(loc, range) && !CheckRange(oldLoc, range);
        }

        public bool CheckRange(Point3D loc, int range)
        {
            return ((Z + 8) >= loc.Z && (loc.Z + 16) > Z) &&
                   Utility.InRange(GetWorldLocation(), loc, range);
        }

        public override void OnMovement(Mobile m, Point3D oldLocation)
        {
            base.OnMovement(m, oldLocation);

            if (Movable)
                return;

            if (m.Location == oldLocation)
                return;

            if (CheckRange(m.Location, oldLocation, 0))
            {
                int chance = Utility.Random(0, m is PlayerMobile ? 4 : 10);

                if (chance == 2)
                {
                    if (m is PlayerMobile)
                    {
                        if(((PlayerMobile)m).AccessLevel >= AccessLevel.Counselor)
                            return;

                        m.SendMessage("Vous avez piétiné une pousse !");
                    }
                    else
                        m.Emote(m is BaseCreature && Utility.RandomBool() ? "*mange la pousse*" : "*piétine une pousse*");

                    Delete();
                }
            }
        }
    }
}
