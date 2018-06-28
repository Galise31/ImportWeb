using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ImportWeb
{
    // -------------------------------------------------------------
    // Exécute un ImportWeb
    // -------------------------------------------------------------
    public partial class RunIW : Form
    {
        public RunIW(string tcProc)
        {
            InitializeComponent();
            lblTitre.Text = tcProc + " - " + IwTools.cActionParam;
        }

        public static void ThreadContrat()
        {
            Application.Run(new Contrat());
        }

        public static void ThreadBordereau()
        {
            Application.Run(new Bordereau());
        }

        // -------------------------------------------------------------
        // On lance l'ImportWeb
        // -------------------------------------------------------------
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            string lcData = "";
            IniFile loIni = new IniFile(AppDomain.CurrentDomain.BaseDirectory + "IW_Login.txt");

            // Si compte TEST, pas de fichier IW_Login.txt
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "IW_Login.txt"))
            {
                // On charge les paramètres de la procédure
                // Vous devez utiliser votre source de données
                int lnIndice = 0;
                foreach (var line in File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "IW_Login.txt"))
                {
                    if (lnIndice == 0)
                    {
                        if (line.Contains("[" + IwTools.cAppli + "]"))
                            lnIndice = 1;
                    }
                    else if (line.StartsWith("["))
                        break;
                    else
                        lcData = lcData + line + Environment.NewLine;
                }
            }

            // Appel de l'ImportWeb
            lcData = @"<IW>
	<User>" + IwTools.cIWUser + @"</User>
	<Pwd>" + IwTools.cIWPwd + @"</Pwd>
	<Action>" + IwTools.cAction + @"</Action>
	<ActionParam>" + IwTools.cActionParam + @"</ActionParam>
	<Cie>" + IwTools.cAppli + @"</Cie>
	<CieLogin>" + loIni.Read("txtWebLogin", IwTools.cAppli) + @"</CieLogin>
	<CiePwd>" + loIni.Read("txtWebPwd", IwTools.cAppli) + @"</CiePwd>
	<cXMLReponse></cXMLReponse>
	<nOption></nOption>
	<CieParam>" + lcData + @"</CieParam>
</IW>";

            string lc = IwTools.loIW.Start(lcData);
            if (IwTools.loIW.CERREUR.ToString() != String.Empty)
            {
                MessageBox.Show(IwTools.loIW.CERREUR.ToString(), "Erreur ImportWeb", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            };
            IwTools.cIW = IwTools.loIW.CXMLREPONSE.ToString();

            // Selon l'action, on appelle Contrat.cs ou Bordereau.cs
            Thread thread;
            if (IwTools.cAction == "Contrat_Creer")
                thread = new Thread(delegate () { ThreadContrat(); });
            else
                thread = new Thread(delegate () { ThreadBordereau(); });
            thread.SetApartmentState(ApartmentState.STA);     // Pour le WebBrowser
            thread.Start();

            this.Close();
        }
    }
}
