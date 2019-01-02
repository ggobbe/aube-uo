//created by henry_r
//12/19/07
//[RunUO 2.0 RC1]
//See .txt file for info
//
using System;
using System.Collections;
using Server.ContextMenus;
using Server;
using Server.Mobiles;
using Server.Items;
using Server.Spells;
using Server.DruidSystem;

namespace Server.DruidSystem.Mobiles
{
    [CorpseName("a arch druid corpse")]
    public class Archdruid : BaseCreature
    {

        private static string[] m_Titles = new string[]
            {
                "Grand High Druid",
                "Lord of the Druids",
                "Druid Lord",
                "Master of the Druids",
                "ArchDruid"
            }; 

        [Constructable]
        public Archdruid()
            : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            SpeechHue = 38;
            Title = m_Titles[Utility.Random(m_Titles.Length)];
            Hue = 1045;
         //   Name = "ArchDruid";

            if (this.Female = Utility.RandomBool())
            {
                Body = 0x191;
                HairItemID = 0x2049;
                HairHue = 2101;
                Name = NameList.RandomName("female");
                AddItem(new Skirt());
            }
            else
            {
                Body = 0x190;
                HairItemID = 0x203C;
                HairHue = 2101;
                Name = NameList.RandomName("male");
                AddItem(new ShortPants());
            }

            SetStr(950);
            SetDex(175);
            SetInt(250);
            SetHits(75000);
            SetDamage(42, 68);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 95);
            SetResistance(ResistanceType.Fire, 70);
            SetResistance(ResistanceType.Cold, 70);
            SetResistance(ResistanceType.Poison, 70);
            SetResistance(ResistanceType.Energy, 70);

            SetSkill(SkillName.Herding, 120.0);
            SetSkill(SkillName.AnimalLore, 120.0);
            SetSkill(SkillName.Meditation, 100.0);
            SetSkill(SkillName.MagicResist, 120.0);
            SetSkill(SkillName.Tactics, 120.0);
            SetSkill(SkillName.Macing, 120.0);

            Fame = 8000;
            Karma = -20000;

            VirtualArmor = 70;

            AddItem(new Robe(1982));
            AddItem(new Sandals());
            AddItem(new LeatherChest());
            AddItem(new LeatherGloves());
            AddItem(new LeatherGorget());
            AddItem(new LeatherArms());
            AddItem(new LeatherLegs());
            ArchDruidStaff weapon = new ArchDruidStaff();
            weapon.Movable = false;
            AddItem(weapon);

            switch (Utility.Random(3))
            {
                case 0: PackItem(new PetrifiedWood(8)); break;
                case 1: PackItem(new Pumice(8)); break;
                case 2: PackItem(new SpringWater(8)); break;
            }
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Average);
        }
        public override bool BardImmune { get { return !Core.SE; } }
        public override bool Unprovokable { get { return Core.SE; } }
        public override bool Uncalmable { get { return Core.SE; } }
        public override bool CanRummageCorpses { get { return false; } }
        public override Poison PoisonImmune { get { return Poison.Lethal; } }
        public override bool ShowFameTitle { get { return false; } }
        public override bool AlwaysMurderer { get { return true; } }
        public override bool IsScaredOfScaryThings { get { return false; } }
        public override bool IsScaryToPets { get { return true; } }

        public override bool InitialInnocent { get { return true; } }

        private DateTime m_NextAbilityTime;

        public override void OnThink()
        {
            if (DateTime.Now >= m_NextAbilityTime)
            {
                Mobile combatant = Combatant as Mobile;

                if (combatant != null && combatant.Map == this.Map && combatant.InRange(this, 12) && IsEnemy(combatant) && !UnderEffect(combatant))
                {
                    m_NextAbilityTime = DateTime.Now + TimeSpan.FromSeconds(Utility.RandomMinMax(45, 60));

                    this.Say(true, "I call a swarm of insects to sting your flesh!");

                    m_Table[combatant] = Timer.DelayCall(TimeSpan.FromSeconds(0.5), TimeSpan.FromSeconds(7.0), new TimerStateCallback(DoEffect), new object[] { combatant, 0 });
                }
            }

            base.OnThink();
        }

        private static Hashtable m_Table = new Hashtable();

        public static bool UnderEffect(Mobile m)
        {
            return m_Table.Contains(m);
        }

        public static void StopEffect(Mobile m, bool message)
        {
            Timer t = (Timer)m_Table[m];

            if (t != null)
            {
                if (message)
                    m.PublicOverheadMessage(Network.MessageType.Emote, m.SpeechHue, true, "* The open flame begins to scatter the swarm of insects *");

                t.Stop();
                m_Table.Remove(m);
            }
        }

        public void DoEffect(object state)
        {
            object[] states = (object[])state;

            Mobile m = (Mobile)states[0];
            int count = (int)states[1];

            if (!m.Alive)
            {
                StopEffect(m, false);
            }
            else
            {
                Torch torch = m.FindItemOnLayer(Layer.TwoHanded) as Torch;

                if (torch != null && torch.Burning)
                {
                    StopEffect(m, true);
                }
                else
                {
                    if ((count % 4) == 0)
                    {
                        m.LocalOverheadMessage(Network.MessageType.Emote, m.SpeechHue, true, "* The swarm of insects bites and stings your flesh! *");
                        m.NonlocalOverheadMessage(Network.MessageType.Emote, m.SpeechHue, true, String.Format("* {0} is stung by a swarm of insects *", m.Name));
                    }

                    m.FixedParticles(0x91C, 10, 180, 9539, EffectLayer.Waist);
                    m.PlaySound(0x00E);
                    m.PlaySound(0x1BC);

                    AOS.Damage(m, this, Utility.RandomMinMax(30, 40) - (Core.AOS ? 0 : 10), 100, 0, 0, 0, 0);

                    states[1] = count + 1;

                    if (!m.Alive || Utility.Random(20) > 18)
                        StopEffect(m, false);
                }
            }
        } 

        public Archdruid(Serial serial)
            : base(serial)
        {
        }
        public override void OnDeath(Container c)
        {
            base.OnDeath(c);
            switch (Utility.Random(21))
            {
                case 0: c.DropItem(new SwarmOfInsectsScroll()); break;
                case 1: c.DropItem(new FireflyScroll()); break;
                case 2: c.DropItem(new LureStoneScroll()); break;
                case 3: c.DropItem(new HurricaneScroll()); break;
                case 4: c.DropItem(new ShieldOfEarthScroll()); break;
                case 5: c.DropItem(new TreefellowScroll()); break;
                case 6: c.DropItem(new ForestKinScroll()); break;

            }
            if (0.03 > Utility.RandomDouble())
            {
                switch (Utility.Random(3))
                {
                    case 0: c.DropItem(new DruidicSpellbook()); break;
                    case 1: c.DropItem(new DruidCloak()); break;
                    case 2: c.DropItem(new ArchDruidStaff()); break;
                    //     default: break;
                }
            }

        }
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}