using System;
using System.Collections.Generic;
using System.Linq;
using Server.Aube.Mobiles.Vendors.SBInfos;
using Server.Mobiles;

namespace Server.Aube.Mobiles.Vendors
{
    public class Peddler : BaseVendor
    {
        private static readonly SBInfo[] RandomSBInfos = {new SBPeddlerA(), new SBPeddlerB(), new SBPeddlerC(), new SBPeddlerD()};

        private Timer _peddlerSpeech;    // le timer pour qu'il parle

        private List<SBInfo> _SBInfos = new List<SBInfo>();

        protected override List<SBInfo> SBInfos { get { return _SBInfos; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public DateTime RestUntil { get; set; }

        // la chanson du peddler
        public static List<string> Lyrics = new List<string>() {
            "Moi je viens d'un pays de désert infini,",
            "Où les caravanes rêvent et flânent.",
            "Où, pendant ton sommeil,",
            "Les serpents t'ensorcellent !",
            "C'est bizarre çà ?",
            "Mais, eh, c'est chez moi !",
            "Quand le vent vient de l'Est,",
            "Le soleil est à l'Ouest,",
            "Et s'endort dans les sables d'or...",
            "C'est l'instant envoûtant,",
            "Vole en tapis volant,",
            "Vers la magie des nuits d'Orient !",
            "Oh Nuits d'arabie,",
            "Mille et une folies.",
            "Insomnie d'amour,",
            "Plus chaude à minuit",
            "Qu'au soleil, en plein jour !",
            "Oh Nuits d'arabie,",
            "Au parfum de velours.",
            "Pour le fou qui se perd,",
            "Au coeur du désert,",
            "Fatal est l'amour ! "
        };

        // les phrases du peddler
        public static List<string> Speech = new List<string>()
        {
            "Aaaah, salam ! Je vous souhaite le bonsoir mon noble ami. Approchez, approchez, venez plus prêt...",
            "TROP PRÈS! Un peu trop près, voilà.",
            "Bienvenue à Agrabba, cité de la magie noire, des enchantements,",
            "et des plus belles marchandises du Jourdan en soldes aujourd'hui, profitez-en ! *rit*",
            "Regardez, oui, un combiné narguilé et cafetière qui fait aussi les pommes de terres frites !",
            "Incassable, incass... cassé.",
            "Ooooooh, regardez, c'est la première fois que j'en vois un aussi bien conservé,",
             "c'est le célèbre Tupperware de la Mer Morte, écoutez! *PROUT*",
            "Aaah, il fonctionne, huhu.",
            "Attendez une seconde, je vois que vous ne vous intéressez qu'aux objets exceptionnellement rares.",
            "Il me semble avoir ici de quoi faire votre bonheur, voyez !",
            "Ne vous laissez pas rebuter par son apparente banalité",
            "comme tant d’autres choses ce n’est pas ce qu’il y a à l’extérieur,",
            " mais ce qu’il y a à l’intérieur qui compte !",
            "Ce n’est pas n’importe quelle lampe ! Elle a même changé le cours de la vie d’un jeune homme.",
            "Et ce jeune homme, tout comme cette lampe, valait beaucoup plus qu’on ne l’estimait...",
            "Un diamant d’innocence !",
            "Je vous raconte cette histoire ?",
            "Elle commence par une nuit... noire, où l’on découvre un homme en noir, nourrissant de noirs desseins...",
            "*raconte ensuite son histoire pendant de longues heures*"
        };


        [Constructable]
        public Peddler()
            : base("le Colporteur")
        {
            Name = "Ikboul";
            SpeechHue = 234;

            StartTimer();
        }

        public override void InitBody()
        {
            this.Female = false;
            this.Race = Race.Human;

            this.Hue = 0x83EE;
        }

        public override void InitSBInfo()
        {
            _SBInfos.Add(new SBPeddler());

            // Add another SB Info at random
            var online = Network.NetState.Instances.Count;
            int which = 0;
            if (online >= RandomSBInfos.Length)
            {
                which = online % RandomSBInfos.Length;
            }
            else
            {
                which = Utility.Random(RandomSBInfos.Length);
            }

            _SBInfos.Add(RandomSBInfos[which]);
        }

        public override TimeSpan RestockDelay { get { return TimeSpan.FromDays(1); } }

        public override void Restock()
        {
            Emote("*arrange ses marchandises différement*");
            LoadSBInfo();
            base.Restock();
        }

        public Peddler(Serial serial)
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

            StartTimer();
        }

        private void StartTimer()
        {
            if (_peddlerSpeech == null)
            {
                _peddlerSpeech = new PeddlerSpeechTimer(this);
            }
            _peddlerSpeech.Start();
        }

        private class PeddlerSpeechTimer : Timer
        {
            private enum PeddlerMode
            {
                None,
                Singing,
                Speaking
            }

            private readonly Peddler _peddler;

            private PeddlerMode _mode;
            private int _indexLyrics;
            private int _indexSpeech;

            public PeddlerSpeechTimer(Peddler peddler)
                : base(TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(10))
            {
                _peddler = peddler;
                _indexLyrics = _indexSpeech = 0;
                _mode = PeddlerMode.None;
            }

            protected override void OnTick()
            {
                var now = DateTime.UtcNow;
                if (now < _peddler.RestUntil)
                {
                    Interval = TimeSpan.FromMinutes(1);
                    return;
                }
                else
                {
                    Interval = TimeSpan.FromSeconds(10);
                }

                var inRange = _peddler.GetMobilesInRange(16).Where(m => m is PlayerMobile && !m.Hidden).ToList();
                if (!inRange.Any())
                {
                    if (_mode != PeddlerMode.None)
                    {
                        Pause();
                    }

                    return;
                }

                if (_mode != PeddlerMode.Speaking)
                {
                    _mode = PeddlerMode.Singing;
                    foreach (var m in inRange)
                    {
                        if (_peddler.GetDistanceToSqrt(m) < 5 && _peddler.InLOS(m))
                        {
                            _mode = PeddlerMode.Speaking;
                            break;
                        }
                    }
                }

                switch (_mode)
                {
                    case PeddlerMode.Singing:
                        Sing();
                        break;
                    case PeddlerMode.Speaking:
                        Speak();
                        break;
                }
            }

            private void Pause()
            {
                _mode = PeddlerMode.None;
                _indexLyrics = _indexSpeech = 0;
                _peddler.RestUntil = DateTime.UtcNow.AddHours(Utility.Random(2, 12));
            }

            private void Sing()
            {
                // Si la chanson est finie on recommence
                if (_indexLyrics >= Lyrics.Count)
                {
                    _indexLyrics = 0;
                    return;
                }

                _peddler.Say(Lyrics[_indexLyrics++]);
            }

            private void Speak()
            {
                // Si c'est la fin du speech on s'arrête
                if (_indexSpeech >= Speech.Count)
                {
                    Pause();
                    return;
                }

                _peddler.Say(Speech[_indexSpeech++]);
            }
        }
    }
}
