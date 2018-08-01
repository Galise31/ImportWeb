using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace ImportWeb
{
    // -------------------------------------------------------------
    // Saisie des paramètres d'un procédure
    // -------------------------------------------------------------
    public partial class Parametres : Form
    {
        private const int LEO_HEIGHT = 25;
        private const int LEO_LEFT = 200;
        private const int LEO_TOP = 10;

        public Parametres(string tcProc)
        {
            InitializeComponent();

            // On appelle la liste des champs de paramètres de la procédure
            this.Text = tcProc;
            string lcData = @"<IW>
	<User>TEST</User>
	<Pwd>TEST</Pwd>
	<Action>FormFields</Action>
	<ActionParam></ActionParam>
	<Cie>" + tcProc + @"</Cie>
	<CieLogin>TEST</CieLogin>
	<CiePwd>TEST</CiePwd>
	<cXMLReponse></cXMLReponse>
	<nOption>0</nOption>
	<CieParam></CieParam>
</IW>";
            string lc = IwTools.loIW.Start(lcData);
            if (IwTools.loIW.cErreur != String.Empty)
            {
                MessageBox.Show(IwTools.loIW.cXMLReponse, "Erreur ImportWeb", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            };

            // On crée les objets à partir de la réponse de l'ImportWeb
            ObjetsCreer(IwTools.loIW.cXMLReponse + @"champ/r");

            // On charge les paramètres dans le formulaire
            LireDonnees();
        }

        // -------------------------------------------------------------
        // Cette méthode crée les objets nécessaires à la saisie des paramètres de la procédure d'ImportWeb
        // -------------------------------------------------------------
        private void ObjetsCreer(string lcFields)
        {
            int lnIndice = 1;       // N de l'Objet
            int lnLargeur = 0;      // Largeur maximale des objet pour redimensionner l'écran
            do
            {
                // Chaque objet a ses propriétés dans un groupe Champ
                string lcData = IwTools.strExtract(lcFields, "Champ\r", "Champ\r");
                if (lcData == string.Empty)
                    break;
                lcFields = lcFields.Replace("Champ\r" + lcData, "");
                // Il y a très ouvent un Label
                Label loLabel = new Label();

                // Chaque classe a ses propres caractéristiques
                switch (IwTools.strExtract(lcData, "Objet=", "\r"))
                {
                    case "leoText":
                        TextBox loText = new TextBox();

                        loText.Name = IwTools.strExtract(lcData, "Nom=", "\r");
                        loText.Location = new System.Drawing.Point(LEO_LEFT, LEO_TOP + (lnIndice * LEO_HEIGHT));
                        loText.Height = TextRenderer.MeasureText(" ", loText.Font).Height;
                        loText.Width = Math.Min(this.Width - loText.Left - 25, Math.Max(100, Int32.Parse(IwTools.strExtract(lcData, "Taille=", "\r")) * 10));
                        lnLargeur = Math.Max(lnLargeur, loText.Width);
                        if (lcData.Contains(".Enabled = .F."))
                        {
                            // Objet grisé
                            loText.Enabled = false;
                            loText.BorderStyle = BorderStyle.None;
                            //loText.Margin = new Padding(10, 10, 0, 0);
                        }
                        if (lcData.Contains(".Urgent = .T."))
                            // Saisie obligatoire
                            loText.BackColor = Color.FromArgb(249, 166, 96);
                        this.Controls.Add(loText);

                        // Etiquette
                        loLabel.Text = IwTools.strExtract(lcData, "Libelle=", "\r");
                        loLabel.Location = new System.Drawing.Point(0, LEO_TOP + (lnIndice * LEO_HEIGHT));
                        loLabel.Width = LEO_LEFT;
                        loLabel.Height = loText.Height;
                        if (loText.Enabled)
                            loLabel.TextAlign = ContentAlignment.MiddleRight;
                        else
                            loLabel.TextAlign = ContentAlignment.TopRight;
                        this.Controls.Add(loLabel);
                        break;

                    case "LeoCombo":
                        ComboBox loCombo = new ComboBox();

                        loCombo.Location = new System.Drawing.Point(LEO_LEFT, LEO_TOP + (lnIndice * LEO_HEIGHT));
                        loCombo.Name = IwTools.strExtract(lcData, "Nom=", "\r");
                        if (lcData.Contains(".Enabled = .F."))
                            // Objet grisé
                            loCombo.Enabled = false;

                        // Liste des Items
                        string lcItems = "," + IwTools.strExtract(lcData, ".RowSource=\"", "\"") + ",";

                        // On remplit les Items de la ComboBox avec un Datatable de 2 colonnes (Code et Libelle)
                        int lnItem = 1;
                        int lnWidth = 0; ;
                        DataTable dt = new DataTable();
                        dt.Columns.Add("Libelle");
                        dt.Columns.Add("Code");
                        do
                        {
                            // On extrait l'Item
                            string lcItem = IwTools.strExtract(lcItems, ",", ",");
                            if (lcItem == string.Empty)
                                break;
                            lcItems = lcItems.Replace("," + lcItem + ",", ",");
                            lnWidth = Math.Max(lnWidth, TextRenderer.MeasureText(lcItem, loCombo.Font).Width);

                            // On extrait s'il y a un code (S'il n'y en a pas : on mémorise le texte)
                            string lcCode = "";
                            if (lcData.Contains(".BoundColumn=2"))
                            {
                                // On mémorise le Code
                                lcCode = IwTools.strExtract(lcItems, ",", ",");
                                lcItems = lcItems.Replace("," + lcCode + ",", ",");
                                loCombo.ValueMember = "Code";
                            }
                            else
                            {
                                // On mémorise le libellé
                                lcCode = lnItem.ToString();
                                lnItem++;
                            }

                            dt.Rows.Add(lcItem, lcCode);
                        } while (true);
                        loCombo.DataSource = dt;
                        loCombo.DisplayMember = "Libelle";
                        loCombo.BindingContext = this.BindingContext;
                        loCombo.Width = Math.Min(this.Width - loCombo.Left - 5, Math.Max(200, (int)Math.Ceiling(lnWidth * 1.2)));
                        lnLargeur = Math.Max(lnLargeur, loCombo.Width);
                        if (lcData.Contains(".Urgent = .T."))
                            // Saisie obligatoire
                            loCombo.BackColor = Color.FromArgb(249, 166, 96);

                        this.Controls.Add(loCombo);

                        loLabel.Location = new System.Drawing.Point(0, LEO_TOP + (lnIndice * LEO_HEIGHT));
                        loLabel.Width = LEO_LEFT;
                        loLabel.Height = loCombo.Height;
                        loLabel.TextAlign = ContentAlignment.MiddleRight;
                        loLabel.Text = IwTools.strExtract(lcData, "Libelle=", "\r");
                        this.Controls.Add(loLabel);
                        break;

                    case "leoCase":
                        CheckBox loCase = new CheckBox();

                        loCase.Location = new System.Drawing.Point(LEO_LEFT, LEO_TOP + (lnIndice * LEO_HEIGHT));
                        loCase.Name = IwTools.strExtract(lcData, "Nom=", "\r");
                        loCase.Text = IwTools.strExtract(lcData, "Libelle=", "\r");
                        loCase.AutoSize = true;
                        lnLargeur = Math.Max(lnLargeur, loCase.Width);
                        if (lcData.Contains(".Enabled = .F."))
                            // Objet grisé
                            loCase.Enabled = false;
                        this.Controls.Add(loCase);

                        break;

                    case "LeoPage":
                        // Non géré ici
                        break;

                    default:
                        MessageBox.Show(IwTools.strExtract(lcData, "Objet=", "\r"));
                        break;
                }
                lnIndice++;
            } while (true);

            // On positionne les autres objets
            cmdValide.Top = 50 + LEO_TOP + (lnIndice * LEO_HEIGHT);
            this.Height = cmdValide.Top + cmdValide.Height + 15 - ClientRectangle.Height + this.Height;
            this.Width = LEO_LEFT + lnLargeur - ClientRectangle.Width + this.Width + 15;
            cmdValide.Left = ClientRectangle.Width - cmdValide .Width - 15;
            lblTitre.Width = ClientRectangle.Width - lblTitre.Left * 2;
        }


        // -------------------------------------------------------------
        // Cette méthode remplit les objest avec les paramètres enregistrés dans IW_Login.txt
        // Vous devez utiliser votre source de données
        // -------------------------------------------------------------
        private void LireDonnees()
        {
            IniFile loIni = new IniFile(AppDomain.CurrentDomain.BaseDirectory + "IW_Login.txt");

            foreach (Control loControl in Controls)
            {
                string lcValeur = loIni.Read(loControl.Name, this.Text);

                if (loControl is TextBox)
                    loControl.Text = lcValeur;
                if (loControl is ComboBox)
                {
                    ComboBox loCombo = (ComboBox)loControl;
                    if (loCombo.ValueMember == string.Empty)
                        loCombo.Text = lcValeur;
                    else
                        loCombo.SelectedValue = lcValeur;
                }
                if (loControl is CheckBox)
                    ((CheckBox)loControl).Checked = (lcValeur == "1");
            }

            // Le contrôle WebbApp cotnient le non de la procédure et n'a pas besoin d'être mémorisé
            Control loAppli;
            loAppli = this.Controls["txtWebbApp"];
            if (loAppli != null)
                loAppli.Text = this.Text;
        }


        // -------------------------------------------------------------
        // Cette méthode écrits les données saisie dans le ficheir IW_Login.txt
        // Vous devez utiliser votre source de données
        // -------------------------------------------------------------
        private void EcrireDonnees()
        {
            IniFile loIni = new IniFile(AppDomain.CurrentDomain.BaseDirectory + "IW_Login.txt");

            foreach (Control loControl in Controls)
            {
                if (loControl is TextBox)
                    loIni.Write(loControl.Name, loControl.Text, this.Text);
                if (loControl is ComboBox)
                {
                    ComboBox loCombo = (ComboBox)loControl;
                    if (loCombo.ValueMember == string.Empty)
                        loIni.Write(loControl.Name, loControl.Text, this.Text);
                    else
                        loIni.Write(loControl.Name, loCombo.SelectedValue.ToString(), this.Text);
                }
                if (loControl is CheckBox)
                {
                    if (((CheckBox)loControl).Checked == true)
                        loIni.Write(loControl.Name, "1", this.Text);
                    else
                        loIni.Write(loControl.Name, "0", this.Text);
                }
            }
        }

        private void cmdValide_Click(object sender, EventArgs e)
        {
            EcrireDonnees();

            // Si la saisie est correcte, on lance RunIW
            string lcAppli = "";
            Control loAppli = this.Controls["txtWebPwd"];
            if (loAppli != null)
                lcAppli = loAppli.Text;

            if ((!this.Modal) && (lcAppli != string.Empty))
            {
                Thread thread = new Thread(delegate () { ThreadRun(this.Text); });
                thread.Start();
            }
            this.Close();
        }

        public static void ThreadRun(string tcProc)
        {
            Application.Run(new RunIW(tcProc));
        }
    }
}
