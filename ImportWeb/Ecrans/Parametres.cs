using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace ImportWeb
{
    public partial class Parametres : Form
    {
        private const int LEO_HEIGHT = 25;
        private const int LEO_LEFT = 200;
        private const int LEO_TOP = 10;

        public Parametres(string tcProc)
        {
            InitializeComponent();

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
            if (IwTools.loIW.CERREUR.ToString() != String.Empty)
            {
                MessageBox.Show(IwTools.loIW.CXMLREPONSE.ToString(), "Erreur ImportWeb", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            };

            ObjetsCreer(IwTools.loIW.CXMLREPONSE.ToString() + @"champ/r");
            LireDonnees();
        }

        private void ObjetsCreer(string lcFields)
        {
            //System.Diagnostics.Debug.Print(lcFields);
            int lnIndice = 1;
            int lnLargeur = 0;
            do
            {
                string lcData = IwTools.strExtract(lcFields, "Champ\r", "Champ\r");
                if (lcData == string.Empty)
                    break;
                lcFields = lcFields.Replace("Champ\r" + lcData, "");
                Label loLabel = new Label();

                switch (IwTools.strExtract(lcData, "Objet=", "\r"))
                {
                    case "leoText":
                        TextBox loText = new TextBox();

                        loText.Name = IwTools.strExtract(lcData, "Nom=", "\r");
                        loText.Location = new System.Drawing.Point(LEO_LEFT, LEO_TOP + (lnIndice * LEO_HEIGHT));
                        //System.Diagnostics.Debug.Print(loText.Left.ToString());
                        loText.Height = TextRenderer.MeasureText(" ", loText.Font).Height;
                        loText.Width = Math.Min(this.Width - loText.Left - 25, Math.Max(100, Int32.Parse(IwTools.strExtract(lcData, "Taille=", "\r")) * 10));
                        lnLargeur = Math.Max(lnLargeur, loText.Width);
                         if (lcData.Contains(".Enabled = .F."))
                        {
                            loText.Enabled = false;
                            loText.BorderStyle = BorderStyle.None;
                            //loText.Margin = new Padding(10, 10, 0, 0);
                        }
                        if (lcData.Contains(".Urgent = .T."))
                            loText.BackColor = Color.FromArgb(249, 166, 96);
                        this.Controls.Add(loText);

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
                            loCombo.Enabled = false;

                        string lcItems = "," + IwTools.strExtract(lcData, ".RowSource=\"", "\"") + ",";

                        int lnItem = 1;
                        int lnWidth = 0; ;
                        DataTable dt = new DataTable();
                        dt.Columns.Add("Libelle");
                        dt.Columns.Add("Code");
                        do
                        {
                            System.Diagnostics.Debug.WriteLine(lcItems);
                            string lcItem = IwTools.strExtract(lcItems, ",", ",");
                            if (lcItem == string.Empty)
                                break;
                            lcItems = lcItems.Replace("," + lcItem + ",", ",");
                            lnWidth = Math.Max(lnWidth, TextRenderer.MeasureText(lcItem, loCombo.Font).Width);

                            string lcCode = "";
                            if (lcData.Contains(".BoundColumn=2"))
                            {
                                lcCode = IwTools.strExtract(lcItems, ",", ",");
                                lcItems = lcItems.Replace("," + lcCode + ",", ",");
                            }
                            else
                            {
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
                            loCase.Enabled = false;
                        this.Controls.Add(loCase);

                        break;

                    case "LeoPage":
                        break;

                    default:
                        MessageBox.Show(IwTools.strExtract(lcData, "Objet=", "\r"));
                        break;
                }
                lnIndice++;
            } while (true);

            cmdValide.Top = 50 + LEO_TOP + (lnIndice * LEO_HEIGHT);
            this.Height = cmdValide.Top + cmdValide.Height + 15 - ClientRectangle.Height + this.Height;
            this.Width = LEO_LEFT + lnLargeur - ClientRectangle.Width + this.Width + 15;
            cmdValide.Left = ClientRectangle.Width - cmdValide .Width - 15;
            lblTitre.Width = ClientRectangle.Width - lblTitre.Left * 2;
        }

        private void LireDonnees()
        {
            IniFile loIni = new IniFile(AppDomain.CurrentDomain.BaseDirectory + "IW_Login.txt");

            foreach (Control loControl in Controls)
            {
                string lcValeur = loIni.Read(loControl.Name, this.Text);

                if (loControl is TextBox)
                    loControl.Text = lcValeur;
                if (loControl is ComboBox)
                    loControl.Text = lcValeur;
                if (loControl is CheckBox)
                    ((CheckBox)loControl).Checked = (lcValeur == "1");
            }

            Control loAppli;
            loAppli = this.Controls["txtWebbApp"];
            if (loAppli != null)
                loAppli.Text = this.Text;
        }

        private void EcrireDonnees()
        {
            IniFile loIni = new IniFile(AppDomain.CurrentDomain.BaseDirectory + "IW_Login.txt");

            foreach (Control loControl in Controls)
            {
                if (loControl is TextBox)
                    loIni.Write(loControl.Name, loControl.Text, this.Text);
                if (loControl is ComboBox)
                    loIni.Write(loControl.Name, loControl.Text, this.Text);
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
