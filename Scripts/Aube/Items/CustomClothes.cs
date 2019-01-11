using Server.Items;

namespace Server.Aube.Items
{
    public class CapeCourte : BaseCloak
    {
        [Constructable]
        public CapeCourte() : this(0)
        {
        }

        [Constructable]
        public CapeCourte(int hue) : base(0x16DA, hue)
        {
            Name = "Cape Courte";
            Weight = 5.0;
        }

        public CapeCourte(Serial serial) : base(serial)
        {
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

    public class CapePeau : BaseCloak
    {
        [Constructable]
        public CapePeau() : this(0)
        {
        }

        [Constructable]
        public CapePeau(int hue) : base(0x16DB, hue)
        {
            Name = "Cape de Peau";
            Weight = 5.0;
        }

        public CapePeau(Serial serial) : base(serial)
        {
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

    public class CapeDrapee : BaseCloak
    {
        [Constructable]
        public CapeDrapee() : this(0)
        {
        }

        [Constructable]
        public CapeDrapee(int hue) : base(0x16DC, hue)
        {
            Name = "Cape Drapée";
            Weight = 5.0;
        }

        public CapeDrapee(Serial serial) : base(serial)
        {
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

    public class CapeFourrure : BaseCloak
    {
        [Constructable]
        public CapeFourrure() : this(0)
        {
        }

        [Constructable]
        public CapeFourrure(int hue) : base(0x16DD, hue)
        {
            Name = "Cape de Fourrure";
            Weight = 5.0;
        }

        public CapeFourrure(Serial serial) : base(serial)
        {
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

    public class CapeLegere : BaseCloak
    {
        [Constructable]
        public CapeLegere() : this(0)
        {
        }

        [Constructable]
        public CapeLegere(int hue) : base(0x16DE, hue)
        {
            Name = "Cape Légère";
            Weight = 5.0;
        }

        public CapeLegere(Serial serial) : base(serial)
        {
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

    public class CapeStylisee : BaseCloak
    {
        [Constructable]
        public CapeStylisee() : this(0)
        {
        }

        [Constructable]
        public CapeStylisee(int hue) : base(0x16DF, hue)
        {
            Name = "Cape Stylisée";
            Weight = 5.0;
        }

        public CapeStylisee(Serial serial) : base(serial)
        {
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

    public class CapeVoyageur : BaseCloak
    {
        [Constructable]
        public CapeVoyageur() : this(0)
        {
        }

        [Constructable]
        public CapeVoyageur(int hue) : base(0x16E0, hue)
        {
            Name = "Cape du Voyageur";
            Weight = 5.0;
        }

        public CapeVoyageur(Serial serial) : base(serial)
        {
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

    public class FoulardTaille : BaseOuterLegs
    {
        [Constructable]
        public FoulardTaille() : this(0)
        {
        }

        [Constructable]
        public FoulardTaille(int hue) : base(0x16E1, hue)
        {
            Name = "Foulard de Taille";
            Weight = 4.0;
        }

        public FoulardTaille(Serial serial) : base(serial)
        {
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

    public class JupeCintree : BaseOuterLegs
    {
        [Constructable]
        public JupeCintree() : this(0)
        {
        }

        [Constructable]
        public JupeCintree(int hue) : base(0x16E2, hue)
        {
            Name = "Jupe Cintrée";
            Weight = 4.0;
        }

        public JupeCintree(Serial serial) : base(serial)
        {
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

    public class JupeCombat : BaseOuterLegs
    {
        [Constructable]
        public JupeCombat() : this(0)
        {
        }

        [Constructable]
        public JupeCombat(int hue) : base(0x16E3, hue)
        {
            Name = "Jupe de Combat";
            Weight = 4.0;
        }

        public JupeCombat(Serial serial) : base(serial)
        {
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

    public class JupeNomade : BaseOuterLegs
    {
        [Constructable]
        public JupeNomade() : this(0)
        {
        }

        [Constructable]
        public JupeNomade(int hue) : base(0x16E4, hue)
        {
            Name = "Jupe de Nomade";
            Weight = 4.0;
        }

        public JupeNomade(Serial serial) : base(serial)
        {
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

    public class JupeDechiree : BaseOuterLegs
    {
        [Constructable]
        public JupeDechiree() : this(0)
        {
        }

        [Constructable]
        public JupeDechiree(int hue) : base(0x16E5, hue)
        {
            Name = "Jupe Déchirée";
            Weight = 4.0;
        }

        public JupeDechiree(Serial serial) : base(serial)
        {
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

    public class JupeFendue : BaseOuterLegs
    {
        [Constructable]
        public JupeFendue() : this(0)
        {
        }

        [Constructable]
        public JupeFendue(int hue) : base(0x16E6, hue)
        {
            Name = "Jupe Fendue";
            Weight = 4.0;
        }

        public JupeFendue(Serial serial) : base(serial)
        {
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

    public class JupeFluide : BaseOuterLegs
    {
        [Constructable]
        public JupeFluide() : this(0)
        {
        }

        [Constructable]
        public JupeFluide(int hue) : base(0x16E7, hue)
        {
            Name = "Jupe Fluide";
            Weight = 4.0;
        }

        public JupeFluide(Serial serial) : base(serial)
        {
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

    public class JupeLongue : BaseOuterLegs
    {
        [Constructable]
        public JupeLongue() : this(0)
        {
        }

        [Constructable]
        public JupeLongue(int hue) : base(0x16E8, hue)
        {
            Name = "Jupe Longue";
            Weight = 4.0;
        }

        public JupeLongue(Serial serial) : base(serial)
        {
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

    public class JupeNordique : BaseOuterLegs
    {
        [Constructable]
        public JupeNordique() : this(0)
        {
        }

        [Constructable]
        public JupeNordique(int hue) : base(0x16E9, hue)
        {
            Name = "Jupe Nordique";
            Weight = 4.0;
        }

        public JupeNordique(Serial serial) : base(serial)
        {
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

    public class JupeSombre : BaseOuterLegs
    {
        [Constructable]
        public JupeSombre() : this(0)
        {
        }

        [Constructable]
        public JupeSombre(int hue) : base(0x16EA, hue)
        {
            Name = "Jupe Sombre";
            Weight = 4.0;
        }

        public JupeSombre(Serial serial) : base(serial)
        {
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

    public class PantalonGance : BasePants
    {
        [Constructable]
        public PantalonGance() : this(0)
        {
        }

        [Constructable]
        public PantalonGance(int hue) : base(0x16EB, hue)
        {
            Name = "Pantalon à Gance";
            Weight = 2.0;
        }

        public PantalonGance(Serial serial) : base(serial)
        {
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

    public class PantalonBouffant : BasePants
    {
        [Constructable]
        public PantalonBouffant() : this(0)
        {
        }

        [Constructable]
        public PantalonBouffant(int hue) : base(0x16EC, hue)
        {
            Name = "Pantalon Bouffant";
            Weight = 2.0;
        }

        public PantalonBouffant(Serial serial) : base(serial)
        {
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

    public class PantalonCourt : BasePants
    {
        [Constructable]
        public PantalonCourt() : this(0)
        {
        }

        [Constructable]
        public PantalonCourt(int hue) : base(0x16ED, hue)
        {
            Name = "Pantalon Court";
            Weight = 2.0;
        }

        public PantalonCourt(Serial serial) : base(serial)
        {
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

    public class PantalonCuir : BasePants
    {
        [Constructable]
        public PantalonCuir() : this(0)
        {
        }

        [Constructable]
        public PantalonCuir(int hue) : base(0x16EE, hue)
        {
            Name = "Pantalon Cuir";
            Weight = 2.0;
        }

        public PantalonCuir(Serial serial) : base(serial)
        {
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

    public class PantalonMoulant : BasePants
    {
        [Constructable]
        public PantalonMoulant() : this(0)
        {
        }

        [Constructable]
        public PantalonMoulant(int hue) : base(0x16EF, hue)
        {
            Name = "Pantalon Moulant";
            Weight = 2.0;
        }

        public PantalonMoulant(Serial serial) : base(serial)
        {
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

    public class PantalonNinja : BasePants
    {
        [Constructable]
        public PantalonNinja() : this(0)
        {
        }

        [Constructable]
        public PantalonNinja(int hue) : base(0x16F0, hue)
        {
            Name = "Pantalon de Ninja";
            Weight = 2.0;
        }

        public PantalonNinja(Serial serial) : base(serial)
        {
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

    public class PantalonNinja2 : BasePants
    {
        [Constructable]
        public PantalonNinja2() : this(0)
        {
        }

        [Constructable]
        public PantalonNinja2(int hue) : base(0x16F1, hue)
        {
            Name = "Pantalon de Ninja";
            Weight = 2.0;
        }

        public PantalonNinja2(Serial serial) : base(serial)
        {
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

    public class PantalonOrne : BasePants
    {
        [Constructable]
        public PantalonOrne() : this(0)
        {
        }

        [Constructable]
        public PantalonOrne(int hue) : base(0x16F2, hue)
        {
            Name = "Pantalon Orné";
            Weight = 2.0;
        }

        public PantalonOrne(Serial serial) : base(serial)
        {
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

    public class PantalonPauvre : BasePants
    {
        [Constructable]
        public PantalonPauvre() : this(0)
        {
        }

        [Constructable]
        public PantalonPauvre(int hue) : base(0x16F3, hue)
        {
            Name = "Pantalon de Pauvre";
            Weight = 2.0;
        }

        public PantalonPauvre(Serial serial) : base(serial)
        {
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

    public class PantalonRodeur : BasePants
    {
        [Constructable]
        public PantalonRodeur() : this(0)
        {
        }

        [Constructable]
        public PantalonRodeur(int hue) : base(0x16F4, hue)
        {
            Name = "Pantalon de Rodeur";
            Weight = 2.0;
        }

        public PantalonRodeur(Serial serial) : base(serial)
        {
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

    public class ChemiseLassee : BaseShirt
    {
        [Constructable]
        public ChemiseLassee() : this(0)
        {
        }

        [Constructable]
        public ChemiseLassee(int hue) : base(0x31C1, hue)
        {
            Name = "chemise lassée";
            Weight = 2.0;
        }

        public ChemiseLassee(Serial serial) : base(serial)
        {
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

    public class ChemiseNoble : BaseShirt
    {
        [Constructable]
        public ChemiseNoble() : this(0)
        {
        }

        [Constructable]
        public ChemiseNoble(int hue) : base(0x31C2, hue)
        {
            Name = "Chemise noble";
            Weight = 2.0;
        }

        public ChemiseNoble(Serial serial) : base(serial)
        {
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

    public class GambisonAjuste : BaseShirt
    {
        [Constructable]
        public GambisonAjuste() : this(0)
        {
        }

        [Constructable]
        public GambisonAjuste(int hue) : base(0x31C3, hue)
        {
            Name = "Gambison ajusté";
            Weight = 1.0;
        }

        public GambisonAjuste(Serial serial) : base(serial)
        {
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

    public class JusteAuCorpCuir : BaseShirt
    {
        [Constructable]
        public JusteAuCorpCuir() : this(0)
        {
        }

        [Constructable]
        public JusteAuCorpCuir(int hue) : base(0x31C4, hue)
        {
            Name = "Juste au corp de cuire";
            Weight = 1.0;
        }

        public JusteAuCorpCuir(Serial serial) : base(serial)
        {
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

    public class JusteAuCorpRafine : BaseShirt
    {
        [Constructable]
        public JusteAuCorpRafine() : this(0)
        {
        }

        [Constructable]
        public JusteAuCorpRafine(int hue) : base(0x31C5, hue)
        {
            Name = "Juste au corps rafiné";
            Weight = 2.0;
        }

        public JusteAuCorpRafine(Serial serial) : base(serial)
        {
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

    public class ManteauVille : BaseShirt
    {
        [Constructable]
        public ManteauVille() : this(0)
        {
        }

        [Constructable]
        public ManteauVille(int hue) : base(0x31C6, hue)
        {
            Name = "Manteau de Ville";
            Weight = 2.0;
        }

        public ManteauVille(Serial serial) : base(serial)
        {
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

    public class PourpointCuir : BaseShirt
    {
        [Constructable]
        public PourpointCuir() : this(0)
        {
        }

        [Constructable]
        public PourpointCuir(int hue) : base(0x31C7, hue)
        {
            Name = "Pourpoint de Cuire";
            Weight = 1.0;
        }

        public PourpointCuir(Serial serial) : base(serial)
        {
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

    public class PourpointFourrure : BaseShirt
    {
        [Constructable]
        public PourpointFourrure() : this(0)
        {
        }

        [Constructable]
        public PourpointFourrure(int hue) : base(0x31C8, hue)
        {
            Name = "Pourpoint de Fourrure";
            Weight = 1.0;
        }

        public PourpointFourrure(Serial serial) : base(serial)
        {
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

    public class SurvetementCollerette : BaseShirt
    {
        [Constructable]
        public SurvetementCollerette() : this(0)
        {
        }

        [Constructable]
        public SurvetementCollerette(int hue) : base(0x31C9, hue)
        {
            Name = "Survêtement à Collerette";
            Weight = 1.0;
        }

        public SurvetementCollerette(Serial serial) : base(serial)
        {
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

    public class SurvetementCuir : BaseShirt
    {
        [Constructable]
        public SurvetementCuir() : this(0)
        {
        }

        [Constructable]
        public SurvetementCuir(int hue) : base(0x31CA, hue)
        {
            Name = "Survêtement de Cuir";
            Weight = 2.0;
        }

        public SurvetementCuir(Serial serial) : base(serial)
        {
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

    public class TabarCeinturon : BaseMiddleTorso
    {
        [Constructable]
        public TabarCeinturon() : this(0)
        {
        }

        [Constructable]
        public TabarCeinturon(int hue) : base(0x31CB, hue)
        {
            Name = "Tabar à Ceinturon";
            Weight = 5.0;
        }

        public TabarCeinturon(Serial serial) : base(serial)
        {
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

    public class TenueForestiere : BaseShirt
    {
        [Constructable]
        public TenueForestiere() : this(0)
        {
        }

        [Constructable]
        public TenueForestiere(int hue) : base(0x31CC, hue)
        {
            Name = "Tenue Forestière";
            Weight = 1.0;
        }

        public TenueForestiere(Serial serial) : base(serial)
        {
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

    public class TuniqueCintree : BaseMiddleTorso
    {
        [Constructable]
        public TuniqueCintree() : this(0)
        {
        }

        [Constructable]
        public TuniqueCintree(int hue) : base(0x31CD, hue)
        {
            Name = "Tunique Cintrée";
            Weight = 5.0;
        }

        public TuniqueCintree(Serial serial) : base(serial)
        {
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

    public class TuniqueCombat : BaseMiddleTorso
    {
        [Constructable]
        public TuniqueCombat() : this(0)
        {
        }

        [Constructable]
        public TuniqueCombat(int hue) : base(0x31CE, hue)
        {
            Name = "Tunique de Combat";
            Weight = 5.0;
        }

        public TuniqueCombat(Serial serial) : base(serial)
        {
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

    public class TuniqueDefraichie : BaseMiddleTorso
    {
        [Constructable]
        public TuniqueDefraichie() : this(0)
        {
        }

        [Constructable]
        public TuniqueDefraichie(int hue) : base(0x31CF, hue)
        {
            Name = "Tunique Défraîchie";
            Weight = 5.0;
        }

        public TuniqueDefraichie(Serial serial) : base(serial)
        {
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

    public class VesteFourrure : BaseShirt
    {
        [Constructable]
        public VesteFourrure() : this(0)
        {
        }

        [Constructable]
        public VesteFourrure(int hue) : base(0x31D0, hue)
        {
            Name = "Veste de Fourrure";
            Weight = 1.0;
        }

        public VesteFourrure(Serial serial) : base(serial)
        {
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

    public class VestonCuir : BaseShirt
    {
        [Constructable]
        public VestonCuir() : this(0)
        {
        }

        [Constructable]
        public VestonCuir(int hue) : base(0x31D1, hue)
        {
            Name = "Veston de Cuir";
            Weight = 1.0;
        }

        public VestonCuir(Serial serial) : base(serial)
        {
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

    public class VestonColV : BaseShirt
    {
        [Constructable]
        public VestonColV() : this(0)
        {
        }

        [Constructable]
        public VestonColV(int hue) : base(0x31D2, hue)
        {
            Name = "Veston à Col en V";
            Weight = 2.0;
        }

        public VestonColV(Serial serial) : base(serial)
        {
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

    public class ChemiseOrnee : BaseShirt
    {
        [Constructable]
        public ChemiseOrnee() : this(0)
        {
        }

        [Constructable]
        public ChemiseOrnee(int hue) : base(0x2BE9, hue)
        {
            Name = "Chemise Ornée";
            Weight = 1.0;
        }

        public ChemiseOrnee(Serial serial) : base(serial)
        {
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

    public class CorsetCuir : BaseShirt
    {
        [Constructable]
        public CorsetCuir() : this(0)
        {
        }

        [Constructable]
        public CorsetCuir(int hue) : base(0x2BEA, hue)
        {
            Name = "Corset de Cuir";
            Weight = 1.0;
        }

        public CorsetCuir(Serial serial) : base(serial)
        {
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

    public class DoubletPaysan : BaseMiddleTorso
    {
        [Constructable]
        public DoubletPaysan() : this(0)
        {
        }

        [Constructable]
        public DoubletPaysan(int hue) : base(0x2BEB, hue)
        {
            Name = "Doublet de Paysan";
            Weight = 2.0;
        }

        public DoubletPaysan(Serial serial) : base(serial)
        {
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

    public class Gaine : BaseMiddleTorso
    {
        [Constructable]
        public Gaine() : this(0)
        {
        }

        [Constructable]
        public Gaine(int hue) : base(0x2BEC, hue)
        {
            Name = "Gaine";
            Weight = 2.0;
        }

        public Gaine(Serial serial) : base(serial)
        {
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

    public class Corsage : BaseMiddleTorso
    {
        [Constructable]
        public Corsage() : this(0)
        {
        }

        [Constructable]
        public Corsage(int hue) : base(0x2BED, hue)
        {
            Name = "Corsage";
            Weight = 2.0;
        }

        public Corsage(Serial serial) : base(serial)
        {
        }

        public override bool OnEquip(Mobile @from)
        {
            return from.Female && base.OnEquip(@from);
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

    public class PetitCorset : BaseMiddleTorso
    {
        [Constructable]
        public PetitCorset() : this(0)
        {
        }

        [Constructable]
        public PetitCorset(int hue) : base(0x2BEE, hue)
        {
            Name = "Petit Corset";
            Weight = 2.0;
        }

        public PetitCorset(Serial serial) : base(serial)
        {
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

    public class PourpointNoble : BaseShirt
    {
        [Constructable]
        public PourpointNoble() : this(0)
        {
        }

        [Constructable]
        public PourpointNoble(int hue) : base(0x2BEF, hue)
        {
            Name = "Pourpoint Noble";
            Weight = 2.0;
        }

        public PourpointNoble(Serial serial) : base(serial)
        {
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

    public class SoutienGorgeEchancre : BaseShirt
    {
        [Constructable]
        public SoutienGorgeEchancre() : this(0)
        {
        }

        [Constructable]
        public SoutienGorgeEchancre(int hue) : base(0x2BF0, hue)
        {
            Name = "Soutien Gorge Echancré";
            Weight = 1.0;
        }

        public SoutienGorgeEchancre(Serial serial) : base(serial)
        {
        }

        public override bool OnEquip(Mobile @from)
        {
            return from.Female && base.OnEquip(@from);
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

    public class SoutienGorgeTissu : BaseShirt
    {
        [Constructable]
        public SoutienGorgeTissu() : this(0)
        {
        }

        [Constructable]
        public SoutienGorgeTissu(int hue) : base(0x2BF1, hue)
        {
            Name = "Soutien Gorge en Tissu";
            Weight = 1.0;
        }

        public SoutienGorgeTissu(Serial serial) : base(serial)
        {
        }

        public override bool OnEquip(Mobile @from)
        {
            return from.Female && base.OnEquip(@from);
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

    public class TuniqueCuir : BaseMiddleTorso
    {
        [Constructable]
        public TuniqueCuir() : this(0)
        {
        }

        [Constructable]
        public TuniqueCuir(int hue) : base(0x2BF2, hue)
        {
            Name = "Tunique de Cuir";
            Weight = 5.0;
        }

        public TuniqueCuir(Serial serial) : base(serial)
        {
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

    public class TuniqueForestier : BaseMiddleTorso
    {
        [Constructable]
        public TuniqueForestier() : this(0)
        {
        }

        [Constructable]
        public TuniqueForestier(int hue) : base(0x2BF3, hue)
        {
            Name = "Tunique de Forestier";
            Weight = 5.0;
        }

        public TuniqueForestier(Serial serial) : base(serial)
        {
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

    public class UniformeCapitaine : BaseMiddleTorso
    {
        [Constructable]
        public UniformeCapitaine() : this(0)
        {
        }

        [Constructable]
        public UniformeCapitaine(int hue) : base(0x2BF4, hue)
        {
            Name = "Uniforme de Capitaine";
            Weight = 5.0;
        }

        public UniformeCapitaine(Serial serial) : base(serial)
        {
        }

        public override bool OnEquip(Mobile @from)
        {
            return !from.Female && base.OnEquip(@from);
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

    public class VestonPirate : BaseMiddleTorso
    {
        [Constructable]
        public VestonPirate() : this(0)
        {
        }

        [Constructable]
        public VestonPirate(int hue) : base(0x18C3, hue)
        {
            Name = "Veston Pirate";
            Weight = 5.0;
        }

        public VestonPirate(Serial serial) : base(serial)
        {
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

    public class VestonBum : BaseMiddleTorso
    {
        [Constructable]
        public VestonBum() : this(0)
        {
        }

        [Constructable]
        public VestonBum(int hue) : base(0x18C4, hue)
        {
            Name = "Veston Bum";
            Weight = 5.0;
        }

        public VestonBum(Serial serial) : base(serial)
        {
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

    public class RobeAubergiste : BaseShirt
    {
        [Constructable]
        public RobeAubergiste() : this(0)
        {
        }

        [Constructable]
        public RobeAubergiste(int hue) : base(0x31D3, hue)
        {
            Name = "Robe Aubergiste";
            Weight = 2.0;
        }

        public RobeAubergiste(Serial serial) : base(serial)
        {
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

    public class RobeVoyage : BaseOuterTorso
    {
        [Constructable]
        public RobeVoyage() : this(0)
        {
        }

        [Constructable]
        public RobeVoyage(int hue) : base(0x31D4, hue)
        {
            Name = "Robe de Voyage";
            Weight = 2.0;
        }

        public RobeVoyage(Serial serial) : base(serial)
        {
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

    public class RobeEquitation : BaseOuterTorso
    {
        [Constructable]
        public RobeEquitation() : this(0)
        {
        }

        [Constructable]
        public RobeEquitation(int hue) : base(0x31D5, hue)
        {
            Name = "Robe d'Equitation";
            Weight = 2.0;
        }

        public RobeEquitation(Serial serial) : base(serial)
        {
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

    public class RobeSofistiquee : BaseOuterTorso
    {
        [Constructable]
        public RobeSofistiquee() : this(0)
        {
        }

        [Constructable]
        public RobeSofistiquee(int hue) : base(0x31D6, hue)
        {
            Name = "Robe Sofistiquée";
            Weight = 2.0;
        }

        public RobeSofistiquee(Serial serial) : base(serial)
        {
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

    public class RobeVaporeuse : BaseOuterTorso
    {
        [Constructable]
        public RobeVaporeuse() : this(0)
        {
        }

        [Constructable]
        public RobeVaporeuse(int hue) : base(0x31D7, hue)
        {
            Name = "Robe Vaporeuse";
            Weight = 2.0;
        }

        public RobeVaporeuse(Serial serial) : base(serial)
        {
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

    public class RobeVaporeuseManches : BaseOuterTorso
    {
        [Constructable]
        public RobeVaporeuseManches() : this(0)
        {
        }

        [Constructable]
        public RobeVaporeuseManches(int hue) : base(0x31D8, hue)
        {
            Name = "Robe Vaporeuse à Manches";
            Weight = 2.0;
        }

        public RobeVaporeuseManches(Serial serial) : base(serial)
        {
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

    public class RobeAjustee : BaseOuterTorso
    {
        [Constructable]
        public RobeAjustee() : this(0)
        {
        }

        [Constructable]
        public RobeAjustee(int hue) : base(0x31D9, hue)
        {
            Name = "Robe Ajustée";
            Weight = 2.0;
        }

        public RobeAjustee(Serial serial) : base(serial)
        {
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

    public class RobeBohemienne : BaseShirt
    {
        [Constructable]
        public RobeBohemienne() : this(0)
        {
        }

        [Constructable]
        public RobeBohemienne(int hue) : base(0x31DA, hue)
        {
            Name = "Robe de Bohémienne";
            Weight = 2.0;
        }

        public RobeBohemienne(Serial serial) : base(serial)
        {
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

    public class RobeBourgeoise : BaseShirt
    {
        [Constructable]
        public RobeBourgeoise() : this(0)
        {
        }

        [Constructable]
        public RobeBourgeoise(int hue) : base(0x31DB, hue)
        {
            Name = "Robe Bourgoise";
            Weight = 2.0;
        }

        public RobeBourgeoise(Serial serial) : base(serial)
        {
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

    public class RobeDepravee : BaseOuterTorso
    {
        [Constructable]
        public RobeDepravee() : this(0)
        {
        }

        [Constructable]
        public RobeDepravee(int hue) : base(0x31DC, hue)
        {
            Name = "Robe Depravée";
            Weight = 2.0;
        }

        public RobeDepravee(Serial serial) : base(serial)
        {
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

    public class RobeDrappee : BaseOuterTorso
    {
        [Constructable]
        public RobeDrappee() : this(0)
        {
        }

        [Constructable]
        public RobeDrappee(int hue) : base(0x31DE, hue)
        {
            Name = "Robe Drappée";
            Weight = 2.0;
        }

        public RobeDrappee(Serial serial) : base(serial)
        {
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

    public class RobeMonastere : BaseShirt
    {
        [Constructable]
        public RobeMonastere() : this(0)
        {
        }

        [Constructable]
        public RobeMonastere(int hue) : base(0x31DF, hue)
        {
            Name = "Robe de Monastère";
            Weight = 2.0;
        }

        public RobeMonastere(Serial serial) : base(serial)
        {
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

    public class RobeNoble : BaseShirt
    {
        [Constructable]
        public RobeNoble() : this(0)
        {
        }

        [Constructable]
        public RobeNoble(int hue) : base(0x31E0, hue)
        {
            Name = "Robe Noble";
            Weight = 2.0;
        }

        public RobeNoble(Serial serial) : base(serial)
        {
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

    public class RobePlissee : BaseOuterTorso
    {
        [Constructable]
        public RobePlissee() : this(0)
        {
        }

        [Constructable]
        public RobePlissee(int hue) : base(0x31E1, hue)
        {
            Name = "Robe Plissée";
            Weight = 2.0;
        }

        public RobePlissee(Serial serial) : base(serial)
        {
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

    public class RobeSansManches : BaseOuterTorso
    {
        [Constructable]
        public RobeSansManches() : this(0)
        {
        }

        [Constructable]
        public RobeSansManches(int hue) : base(0x31E2, hue)
        {
            Name = "Robe sans Manches";
            Weight = 2.0;
        }

        public RobeSansManches(Serial serial) : base(serial)
        {
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

    public class TogeSombre : BaseOuterTorso
    {
        [Constructable]
        public TogeSombre() : this(0)
        {
        }

        [Constructable]
        public TogeSombre(int hue) : base(0x31E3, hue)
        {
            Name = "Toge Sombre";
            Weight = 3.0;
        }

        public TogeSombre(Serial serial) : base(serial)
        {
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

    public class RobePelerin : BaseOuterTorso
    {
        [Constructable]
        public RobePelerin() : this(0)
        {
        }

        [Constructable]
        public RobePelerin(int hue) : base(0x16F5, hue)
        {
            Name = "Robe de Pèlerin";
            Weight = 2.0;
        }

        public RobePelerin(Serial serial) : base(serial)
        {
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

    public class BandageAbdomen : BaseWaist
    {
        [Constructable]
        public BandageAbdomen() : this(0)
        {
        }

        [Constructable]
        public BandageAbdomen(int hue) : base(0x2E48, hue)
        {
            Name = "Bandage Abdomen";
            Weight = 2.0;
        }

        public BandageAbdomen(Serial serial) : base(serial)
        {
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

    public class BandagePoignets : BaseClothing
    {
        [Constructable]
        public BandagePoignets() : this(0)
        {
        }

        [Constructable]
        public BandagePoignets(int hue) : base(0x2E49, Layer.Arms, hue)
        {
            Name = "Bandage Poignets";
            Weight = 2.0;
        }

        public BandagePoignets(Serial serial) : base(serial)
        {
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

    public class BandagePieds : BaseClothing
    {
        [Constructable]
        public BandagePieds() : this(0)
        {
        }

        [Constructable]
        public BandagePieds(int hue) : base(0x2E4A, Layer.InnerLegs, hue)
        {
            Name = "Bandages Pieds";
            Weight = 2.0;
        }

        public BandagePieds(Serial serial) : base(serial)
        {
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

    public class Carquois : ElvenQuiver
    {
        [Constructable]
        public Carquois() : this(0)
        {
        }

        [Constructable]
        public Carquois(int hue) : base()
        {
            Name = "Carquois";
            ItemID = 0x2E4B;
            Hue = hue;
            Weight = 2.0;
        }

        public Carquois(Serial serial) : base(serial)
        {
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

    public class CeintureCouteaux : BaseWaist
    {
        [Constructable]
        public CeintureCouteaux() : this(0)
        {
        }

        [Constructable]
        public CeintureCouteaux(int hue) : base(0x2E4C, hue)
        {
            Name = "Ceinture à Couteaux";
            Weight = 2.0;
        }

        public CeintureCouteaux(Serial serial) : base(serial)
        {
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

    public class CeinturePochette : BaseWaist
    {
        [Constructable]
        public CeinturePochette() : this(0)
        {
        }

        [Constructable]
        public CeinturePochette(int hue) : base(0x2E4D, hue)
        {
            Name = "Ceinture à Pochette";
            Weight = 2.0;
        }

        public CeinturePochette(Serial serial) : base(serial)
        {
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

    public class CeintureBarbare : BaseWaist
    {
        [Constructable]
        public CeintureBarbare() : this(0)
        {
        }

        [Constructable]
        public CeintureBarbare(int hue) : base(0x2E4E, hue)
        {
            Name = "Ceinture Barbare";
            Weight = 2.0;
        }

        public CeintureBarbare(Serial serial) : base(serial)
        {
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

    public class CeintureCloutee : BaseWaist
    {
        [Constructable]
        public CeintureCloutee() : this(0)
        {
        }

        [Constructable]
        public CeintureCloutee(int hue) : base(0x2E4F, hue)
        {
            Name = "Ceinture Cloutée";
            Weight = 2.0;
        }

        public CeintureCloutee(Serial serial) : base(serial)
        {
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

    public class CeintureCorsaire : BaseWaist
    {
        [Constructable]
        public CeintureCorsaire() : this(0)
        {
        }

        [Constructable]
        public CeintureCorsaire(int hue) : base(0x2E50, hue)
        {
            Name = "Ceinture de Corsaire";
            Weight = 2.0;
        }

        public CeintureCorsaire(Serial serial) : base(serial)
        {
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

    public class CeintureVoyage : BaseWaist
    {
        [Constructable]
        public CeintureVoyage() : this(0)
        {
        }

        [Constructable]
        public CeintureVoyage(int hue) : base(0x2E51, hue)
        {
            Name = "Ceinture de Voyage";
            Weight = 2.0;
        }

        public CeintureVoyage(Serial serial) : base(serial)
        {
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

    public class CeintureOssuaire : BaseWaist
    {
        [Constructable]
        public CeintureOssuaire() : this(0)
        {
        }

        [Constructable]
        public CeintureOssuaire(int hue) : base(0x2E52, hue)
        {
            Name = "Ceinture d'Ossuaire";
            Weight = 2.0;
        }

        public CeintureOssuaire(Serial serial) : base(serial)
        {
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

    public class CeintureDouble : BaseWaist
    {
        [Constructable]
        public CeintureDouble() : this(0)
        {
        }

        [Constructable]
        public CeintureDouble(int hue) : base(0x2E53, hue)
        {
            Name = "Deinture Double";
            Weight = 2.0;
        }

        public CeintureDouble(Serial serial) : base(serial)
        {
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

    public class CeintureEcharpe : BaseWaist
    {
        [Constructable]
        public CeintureEcharpe() : this(0)
        {
        }

        [Constructable]
        public CeintureEcharpe(int hue) : base(0x2E54, hue)
        {
            Name = "Ceinture en Echarpe";
            Weight = 2.0;
        }

        public CeintureEcharpe(Serial serial) : base(serial)
        {
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

    public class CeintureGitane : BaseWaist
    {
        [Constructable]
        public CeintureGitane() : this(0)
        {
        }

        [Constructable]
        public CeintureGitane(int hue) : base(0x2E55, hue)
        {
            Name = "Ceinture Gitane";
            Weight = 2.0;
        }

        public CeintureGitane(Serial serial) : base(serial)
        {
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

    public class CeintureGuerriere : BaseWaist
    {
        [Constructable]
        public CeintureGuerriere() : this(0)
        {
        }

        [Constructable]
        public CeintureGuerriere(int hue) : base(0x2E56, hue)
        {
            Name = "Ceinture Guerriere";
            Weight = 2.0;
        }

        public CeintureGuerriere(Serial serial) : base(serial)
        {
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

    public class CeintureLacee : BaseWaist
    {
        [Constructable]
        public CeintureLacee() : this(0)
        {
        }

        [Constructable]
        public CeintureLacee(int hue) : base(0x2E57, hue)
        {
            Name = "Ceinture Lacée";
            Weight = 2.0;
        }

        public CeintureLacee(Serial serial) : base(serial)
        {
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

    public class CeintureRenforcee : BaseWaist
    {
        [Constructable]
        public CeintureRenforcee() : this(0)
        {
        }

        [Constructable]
        public CeintureRenforcee(int hue) : base(0x2E58, hue)
        {
            Name = "Ceinture renforcée";
            Weight = 2.0;
        }

        public CeintureRenforcee(Serial serial) : base(serial)
        {
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

    public class CeintureRoublarde : BaseWaist
    {
        [Constructable]
        public CeintureRoublarde() : this(0)
        {
        }

        [Constructable]
        public CeintureRoublarde(int hue) : base(0x2E59, hue)
        {
            Name = "Ceinture Roublarde";
            Weight = 2.0;
        }

        public CeintureRoublarde(Serial serial) : base(serial)
        {
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

    public class Ceinturon : BaseWaist
    {
        [Constructable]
        public Ceinturon() : this(0)
        {
        }

        [Constructable]
        public Ceinturon(int hue) : base(0x2E5A, hue)
        {
            Name = "Ceinturon";
            Weight = 2.0;
        }

        public Ceinturon(Serial serial) : base(serial)
        {
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

    public class EpaulettesCorne : BaseWaist
    {
        [Constructable]
        public EpaulettesCorne() : this(0)
        {
        }

        [Constructable]
        public EpaulettesCorne(int hue) : base(0x2E5B, hue)
        {
            Name = "Epaulettes à Corne";
            Weight = 2.0;
        }

        public EpaulettesCorne(Serial serial) : base(serial)
        {
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

    public class FixationCroisee : BaseWaist
    {
        [Constructable]
        public FixationCroisee() : this(0)
        {
        }

        [Constructable]
        public FixationCroisee(int hue) : base(0x2E5C, hue)
        {
            Name = "Fixation Croisée";
            Weight = 2.0;
        }

        public FixationCroisee(Serial serial) : base(serial)
        {
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

    public class GardeEpeeTransversale : BaseWaist
    {
        [Constructable]
        public GardeEpeeTransversale() : this(0)
        {
        }

        [Constructable]
        public GardeEpeeTransversale(int hue) : base(0x2E5D, hue)
        {
            Name = "Garde d'Epée Transversale";
            Weight = 2.0;
        }

        public GardeEpeeTransversale(Serial serial) : base(serial)
        {
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

    public class VoileProtecteur : BaseWaist
    {
        [Constructable]
        public VoileProtecteur() : this(0)
        {
        }

        [Constructable]
        public VoileProtecteur(int hue) : base(0x2E5E, hue)
        {
            Name = "Voile Protecteur";
            Weight = 2.0;
        }

        public VoileProtecteur(Serial serial) : base(serial)
        {
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
}
