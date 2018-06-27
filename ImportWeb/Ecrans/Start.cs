using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ImportWeb
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();

            cboProc.DataSource = IwTools.IW_Liste();
            cboProc.DisplayMember = "Proc";
            cboProc.BindingContext = this.BindingContext;
            cboProc.DropDownStyle = ComboBoxStyle.DropDown;
            cboProc.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboProc.AutoCompleteMode = AutoCompleteMode.Suggest;
            
            this.ActiveControl = cboProc;
        }

        private void txtNPoliceCie_TextChanged(object sender, EventArgs e)
        {
            frmPage_SelectedIndexChanged(sender, e);
        }

        private void frmPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdValide.Enabled = ((frmPage.SelectedIndex == 1) || (txtNPoliceCie.Text != string.Empty)) && (cboProc.Text != string.Empty);
        }

        private void cboProc_SelectedIndexChanged(object sender, EventArgs e)
        {
            frmPage_SelectedIndexChanged(sender, e);
        }

        private void cboProc_Leave(object sender, EventArgs e)
        {
            frmPage_SelectedIndexChanged(sender, e);
        }

        private void cmdParam_Click(object sender, EventArgs e)
        {
            string lcProc = cboProc.Text.Replace(" ", "").ToUpper();
            if (lcProc.Contains("-"))
                lcProc = lcProc.Substring(0, lcProc.IndexOf("-"));

            //this.Hide();
            Parametres loForm = new Parametres(lcProc);
            loForm.ShowDialog();
        }

        private void cmdValide_Click(Object sender, EventArgs e)
        {
            string lcProc = cboProc.Text.Replace(" ", "").ToUpper();
            if (lcProc.Contains("-"))
                lcProc = lcProc.Substring(0, lcProc.IndexOf("-"));
            IwTools.cIWUser = txtIWUser.Text;
            IwTools.cIWPwd = txtIWPwd.Text;
            if (IwTools.cIWUser == "TEST")
            {
                MessageBox.Show("Le compte TEST ne renvoie qu'un seul exemple", "ImportWeb", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            IwTools.cAppli = lcProc;
            if (frmPage.SelectedIndex == 0)
            {
                IwTools.cAction = "Contrat_Creer";
                IwTools.cActionParam = txtNPoliceCie.Text;
            }
            else
            {
                IwTools.cAction = "Regle_Cie";
                IwTools.cActionParam = txtDate.Text;
            }

            IniFile loIni = new IniFile(AppDomain.CurrentDomain.BaseDirectory + "IW_Login.txt");
            Thread thread;
            if (loIni.Read("txtWebbApp", lcProc) == string.Empty) 
                thread = new Thread(delegate () { ThreadParam(lcProc); });
            else
                thread = new Thread(delegate () { ThreadRun(lcProc); });
            thread.Start();
            this.Close();
        }

        public static void ThreadParam(string tcProc)
        {
            Application.Run(new Parametres(tcProc));
        }

        public static void ThreadRun(string tcProc)
        {
            Application.Run(new RunIW(tcProc));
        }
    }
}
