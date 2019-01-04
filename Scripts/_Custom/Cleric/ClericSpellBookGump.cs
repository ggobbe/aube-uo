using Server.Items.Cleric;
using Server.Network;
using Server.Spells;
using Server.Spells.Cleric;

namespace Server.Gumps.Cleric
{
    public class ClericSpellBookGump : Gump
    {
        private ClericSpellbook m_Book;

        int gth = 0x903;
        private void AddBackground()
        {
            AddPage(0);
            AddImage(0, 0, 0x89B, 0);
            AddLabel(60, 10, gth, "Holy Magic");
        }

        public bool HasSpell(Mobile from, int spellID)
        {
            return (m_Book.HasSpell(spellID));
        }


        public ClericSpellBookGump(Mobile from, ClericSpellbook book) : base(PropsConfig.GumpOffsetX, PropsConfig.GumpOffsetY)
        {
            m_Book = book;
            AddBackground();

            var sbtn = 0x93A;
            var page = 1;

            for (var i = 0; i < m_Book.BookCount; i++)
            {
                if (i % 14 == 0)
                {
                    AddPage(page++);
                    if (page > 2)
                        AddButton(23, 5, 0x89D, 0x89D, m_Book.BookCount + 1, GumpButtonType.Page, page - 2);

                    AddButton(296, 4, 0x89E, 0x89E, m_Book.BookCount + 2, GumpButtonType.Page, page);
                }

                if (HasSpell(from, i + m_Book.BookOffset))
                {
                    var spell = SpellRegistry.NewSpell(i + m_Book.BookOffset, from, null);

                    AddLabel((i / 7) % 2 == 0 ? 45 : 215, 30 + (22 * (i % 7)), gth, spell.Name);
                    AddButton((i / 7) % 2 == 0 ? 28 : 195, 33 + (22 * (i % 7)), sbtn, sbtn, i + 1, GumpButtonType.Reply, 1);
                }
            }

            for (var i = 0; i < m_Book.BookCount; i++)
            {
                if (HasSpell(from, i + m_Book.BookOffset))
                {
                    var spell = SpellRegistry.NewSpell(i + m_Book.BookOffset, from, null);

                    AddPage(page++);
                    AddButton(23, 5, 0x89D, 0x89D, m_Book.BookCount + 1, GumpButtonType.Page, page - 2);

                    if (i < m_Book.BookCount - 1)
                        AddButton(296, 4, 0x89E, 0x89E, m_Book.BookCount + 2, GumpButtonType.Page, page);

                    AddLabel(50, 27, gth, spell.Info.Name);

                    AddLabel(195, 27, gth, "Reagents:");
                    for (var r = 0; r < spell.Reagents.Length; r++)
                    {
                        AddLabel(195, 47 + (r * 20), gth, spell.Reagents[r].Name);
                    }

                    var dspell = spell as ClericSpell;
                    if (dspell != null)
                    {
                        AddHtml(30, 49, 123, 132, dspell.SpellDescription, false, false);
                        AddLabel(195, 157, gth, "Required Skill: " + dspell.RequiredSkill);
                        AddLabel(195, 177, gth, "Tithing Cost: " + dspell.RequiredTithing);
                    }
                }
            }
        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
            Mobile from = state.Mobile;
            if (info.ButtonID == 0)
                return;

            var spell = SpellRegistry.NewSpell(info.ButtonID - 1 + m_Book.BookOffset, from, null);
            if (spell != null)
                spell.Cast();
        }
    }
}
