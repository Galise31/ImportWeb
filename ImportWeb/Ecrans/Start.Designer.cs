namespace ImportWeb
{
    partial class Start
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Start));
            this.cmdValide = new System.Windows.Forms.Button();
            this.cboProc = new System.Windows.Forms.ComboBox();
            this.lblProc = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.frmPage = new System.Windows.Forms.TabControl();
            this.leoPage1 = new System.Windows.Forms.TabPage();
            this.txtNPoliceCie = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.leoPage2 = new System.Windows.Forms.TabPage();
            this.txtDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdParam = new System.Windows.Forms.Button();
            this.txtIWUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIWPwd = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.frmPage.SuspendLayout();
            this.leoPage1.SuspendLayout();
            this.leoPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdValide
            // 
            this.cmdValide.Enabled = false;
            this.cmdValide.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdValide.Location = new System.Drawing.Point(277, 342);
            this.cmdValide.Name = "cmdValide";
            this.cmdValide.Size = new System.Drawing.Size(83, 38);
            this.cmdValide.TabIndex = 0;
            this.cmdValide.Text = "Suivant";
            this.cmdValide.UseVisualStyleBackColor = true;
            this.cmdValide.Click += new System.EventHandler(this.cmdValide_Click);
            // 
            // cboProc
            // 
            this.cboProc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(166)))), ((int)(((byte)(96)))));
            this.cboProc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProc.FormattingEnabled = true;
            this.cboProc.Location = new System.Drawing.Point(36, 117);
            this.cboProc.Name = "cboProc";
            this.cboProc.Size = new System.Drawing.Size(183, 28);
            this.cboProc.TabIndex = 1;
            this.cboProc.SelectedIndexChanged += new System.EventHandler(this.cboProc_SelectedIndexChanged);
            this.cboProc.Leave += new System.EventHandler(this.cboProc_Leave);
            // 
            // lblProc
            // 
            this.lblProc.AutoSize = true;
            this.lblProc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProc.Location = new System.Drawing.Point(36, 90);
            this.lblProc.Name = "lblProc";
            this.lblProc.Size = new System.Drawing.Size(192, 20);
            this.lblProc.TabIndex = 2;
            this.lblProc.Text = "Choisissez une procédure";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Image = global::ImportWeb.Properties.Resources.ImportWeb;
            this.pictureBox2.Location = new System.Drawing.Point(73, 26);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(179, 42);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::ImportWeb.Properties.Resources.IW;
            this.pictureBox1.Location = new System.Drawing.Point(16, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(51, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // frmPage
            // 
            this.frmPage.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.frmPage.Controls.Add(this.leoPage1);
            this.frmPage.Controls.Add(this.leoPage2);
            this.frmPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frmPage.Location = new System.Drawing.Point(12, 164);
            this.frmPage.Name = "frmPage";
            this.frmPage.SelectedIndex = 0;
            this.frmPage.Size = new System.Drawing.Size(329, 126);
            this.frmPage.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.frmPage.TabIndex = 6;
            this.frmPage.SelectedIndexChanged += new System.EventHandler(this.frmPage_SelectedIndexChanged);
            // 
            // leoPage1
            // 
            this.leoPage1.Controls.Add(this.txtNPoliceCie);
            this.leoPage1.Controls.Add(this.label1);
            this.leoPage1.Location = new System.Drawing.Point(4, 32);
            this.leoPage1.Name = "leoPage1";
            this.leoPage1.Padding = new System.Windows.Forms.Padding(3);
            this.leoPage1.Size = new System.Drawing.Size(321, 90);
            this.leoPage1.TabIndex = 0;
            this.leoPage1.Text = "Contrat";
            this.leoPage1.UseVisualStyleBackColor = true;
            // 
            // txtNPoliceCie
            // 
            this.txtNPoliceCie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(166)))), ((int)(((byte)(96)))));
            this.txtNPoliceCie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNPoliceCie.Location = new System.Drawing.Point(20, 49);
            this.txtNPoliceCie.Name = "txtNPoliceCie";
            this.txtNPoliceCie.Size = new System.Drawing.Size(212, 26);
            this.txtNPoliceCie.TabIndex = 3;
            this.txtNPoliceCie.TextChanged += new System.EventHandler(this.txtNPoliceCie_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Quel N° de contrat à télécharger";
            // 
            // leoPage2
            // 
            this.leoPage2.Controls.Add(this.txtDate);
            this.leoPage2.Controls.Add(this.label2);
            this.leoPage2.Location = new System.Drawing.Point(4, 32);
            this.leoPage2.Name = "leoPage2";
            this.leoPage2.Padding = new System.Windows.Forms.Padding(3);
            this.leoPage2.Size = new System.Drawing.Size(321, 90);
            this.leoPage2.TabIndex = 1;
            this.leoPage2.Text = "Bordereau";
            this.leoPage2.UseVisualStyleBackColor = true;
            // 
            // txtDate
            // 
            this.txtDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDate.Location = new System.Drawing.Point(20, 49);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(114, 26);
            this.txtDate.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Quelle date du bordereau";
            // 
            // cmdParam
            // 
            this.cmdParam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdParam.Location = new System.Drawing.Point(254, 107);
            this.cmdParam.Name = "cmdParam";
            this.cmdParam.Size = new System.Drawing.Size(106, 51);
            this.cmdParam.TabIndex = 7;
            this.cmdParam.Text = "Paramètres de connexion";
            this.cmdParam.UseVisualStyleBackColor = true;
            this.cmdParam.Click += new System.EventHandler(this.cmdParam_Click);
            // 
            // txtIWUser
            // 
            this.txtIWUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(166)))), ((int)(((byte)(96)))));
            this.txtIWUser.Location = new System.Drawing.Point(142, 321);
            this.txtIWUser.Name = "txtIWUser";
            this.txtIWUser.Size = new System.Drawing.Size(84, 20);
            this.txtIWUser.TabIndex = 9;
            this.txtIWUser.Text = "TEST";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 292);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Compte ImportWeb";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(57, 319);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Utilisateur";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(32, 345);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Mot de passe";
            // 
            // txtIWPwd
            // 
            this.txtIWPwd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(166)))), ((int)(((byte)(96)))));
            this.txtIWPwd.Location = new System.Drawing.Point(142, 347);
            this.txtIWPwd.Name = "txtIWPwd";
            this.txtIWPwd.Size = new System.Drawing.Size(84, 20);
            this.txtIWPwd.TabIndex = 11;
            this.txtIWPwd.Text = "TEST";
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 388);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtIWPwd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtIWUser);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmdParam);
            this.Controls.Add(this.frmPage);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblProc);
            this.Controls.Add(this.cboProc);
            this.Controls.Add(this.cmdValide);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Start";
            this.Text = "Tester l\'ImportWeb";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.frmPage.ResumeLayout(false);
            this.leoPage1.ResumeLayout(false);
            this.leoPage1.PerformLayout();
            this.leoPage2.ResumeLayout(false);
            this.leoPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdValide;
        private System.Windows.Forms.ComboBox cboProc;
        private System.Windows.Forms.Label lblProc;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TabControl frmPage;
        private System.Windows.Forms.TabPage leoPage1;
        private System.Windows.Forms.TabPage leoPage2;
        private System.Windows.Forms.TextBox txtNPoliceCie;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker txtDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdParam;
        private System.Windows.Forms.TextBox txtIWUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIWPwd;
    }
}

