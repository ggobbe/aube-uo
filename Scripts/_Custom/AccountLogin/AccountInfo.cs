using System;
using Server;
using Server.Commands;
using Server.Network;
using Server.Mobiles;
using Server.Accounting;
using System.Collections;
//using Server.Scripts.Commands;
using Server.Gumps;

namespace Server.Gumps
{
	public class AccountInfo : Gump
	{
		private Mobile m_From;

		private int m_PassLength = 6;

		public AccountInfo( Mobile from ) : base( 0, 0 )
		{
			m_From = from;

                        Account acct = (Account)from.Account;
			PlayerMobile pm = (PlayerMobile)from;
			NetState ns = from.NetState;
			ClientVersion v = ns.Version;

			TimeSpan totalTime = (DateTime.Now - acct.Created);

			Closable=true;
			Disposable=true;
			Dragable=true;
			Resizable=false;
			AddPage(0);
			AddPage(1);
			AddBackground(39, 29, 447, 276, 5120);
			AddLabel(49, 33, 1160, @"Information principale du compte");
			AddButton(52, 67, 4005, 4006, 1, GumpButtonType.Page, 2);
			AddLabel(85, 68, 1149, @"Changer le mot de passe");
			AddImageTiled(52, 159, 423, 131, 9254);
			AddAlphaRegion(52, 158, 423, 131);
			AddLabel(56, 136, 1160, @"Information du compte:");
			AddLabel(60, 165, 1149, @"Nom du compte:");
			AddLabel(60, 185, 1149, @"Version de UO:");
			AddLabel(60, 205, 1149, @"Adresse IP:");
			AddLabel(60, 225, 1149, @"Compte créer le:");
			AddLabel(60, 245, 1149, @"Temps en-jeu (IG):");
			AddLabel(60, 265, 1149, @"Age du compte:");
			AddImage(414, 39, 5523);
			AddLabel(167, 165, 64, acct.Username.ToString() );
			AddLabel(156, 185, 64, v == null ? "(null)" : v.ToString() );
			AddLabel(134, 205, 64, ns.ToString() );
			AddLabel(167, 225, 64, acct.Created.ToString() );
			
			string gt = pm.GameTime.Days + " Jours, " + pm.GameTime.Hours + " Heures, " + pm.GameTime.Minutes + " Minutes, " + pm.GameTime.Seconds + " Secondes.";
			AddLabel(176, 245, 64, gt.ToString() );

			string tt = totalTime.Days + " Jours, " + totalTime.Hours + " Heures, " + totalTime.Minutes + " Minutes, " + totalTime.Seconds + " Secondes.";
			AddLabel(158, 265, 64, tt.ToString() );
			AddPage(2);
			AddBackground(39, 29, 262, 240, 5120);
			AddLabel(50, 30, 1160, @"Menu de changement du mot de passe");
			AddImageTiled(50, 75, 238, 29, 9304);
			AddImageTiled(50, 135, 238, 29, 9304);
			AddImageTiled(50, 195, 238, 29, 9304);
			AddLabel(50, 55, 1149, @"Mot de passe présent:");
			AddLabel(50, 115, 1149, @"Nouveau mot de passe:");
			AddLabel(50, 175, 1149, @"Confirmer le mot de passe:");
			AddButton(50, 233, 4023, 4024, 1, GumpButtonType.Reply, 0);
			AddLabel(85, 234, 1160, @"Soumettre le mot de passe");
			AddTextEntry(50, 75, 238, 29, 0, 1, @"");
			AddTextEntry(50, 135, 238, 29, 0, 2, @"");
			AddTextEntry(50, 195, 238, 29, 0, 3, @"");

		}
      		public override void OnResponse( NetState state, RelayInfo info ) 
      		{ 

        		if ( info.ButtonID == 1 ) // Add Email
         		{ 
                        	Mobile from = state.Mobile;
                        	Account acct = (Account)from.Account; 
            			string cpass = (string)info.GetTextEntry( 1 ).Text;
            			string newpass = (string)info.GetTextEntry( 2 ).Text;
            			string newpass2 = (string)info.GetTextEntry( 3 ).Text;

				if ( acct.CheckPassword( cpass ) )
				{
					if ( newpass == null || newpass2 == null )
					{
						from.SendMessage( 38, "Vous devez saisir un nouveau mot de passe et le confirmer." );
					}
					else if ( newpass.Length <= m_PassLength )
					{
						from.SendMessage( 38, "Votre nouveau mot de passe doit être d'au moins {0} caractères de long.", m_PassLength );
					}
					else if ( newpass == newpass2 )
					{
						from.SendMessage( "Votre mot de passe a été changé pour {0}.", newpass );
						acct.SetPassword( newpass );
						CommandLogging.WriteLine( from, "{0} {1} has changed thier password for account {2} using the [accountlogin command", from.AccessLevel, CommandLogging.Format( from ), acct.Username );
					}
					else
					{
						from.SendMessage( 38, "Votre nouveau mot de passe ne correspond pas à votre confirmation. S'il vous plaît vérifier votre orthographe et essayez à nouveau." );
						from.SendMessage( 38, "Juste un rappel. Les mots de passe sont sensibles à la case." );
					}
				}
				else
				{
					from.SendMessage( 38, "Le mot de passe actuel que vous avez saisi ne correspond à votre mot de passe actuel. S'il vous plaît vérifier votre orthographe et essayez à nouveau." );
					from.SendMessage( 38, "Juste un rappel. Les mots de passe sont sensibles à la case." );
				}
			}
        	} 
	}
} 