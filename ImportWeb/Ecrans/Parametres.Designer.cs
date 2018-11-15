namespace ImportWeb
{
    partial class Parametres
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Parametres));
            this.lblTitre = new System.Windows.Forms.Label();
            this.cmdHelp = new System.Windows.Forms.Button();
            this.cmdValide = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitre
            // 
            this.lblTitre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitre.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblTitre.Location = new System.Drawing.Point(12, 12);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(644, 24);
            this.lblTitre.TabIndex = 1;
            this.lblTitre.Text = "Paramètres";
            this.lblTitre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdHelp
            // 
            this.cmdHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdHelp.Image = global::ImportWeb.Properties.Resources.Help;
            this.cmdHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdHelp.Location = new System.Drawing.Point(72, 39);
            this.cmdHelp.Name = "cmdHelp";
            this.cmdHelp.Padding = new System.Windows.Forms.Padding(5);
            this.cmdHelp.Size = new System.Drawing.Size(101, 44);
            this.cmdHelp.TabIndex = 3;
            this.cmdHelp.Text = "Aide";
            this.cmdHelp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdHelp.UseVisualStyleBackColor = true;
            this.cmdHelp.Click += new System.EventHandler(this.cmdHelp_Click);
            // 
            // cmdValide
            // 
            this.cmdValide.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdValide.Image = ((System.Drawing.Image)(resources.GetObject("cmdValide.Image")));
            this.cmdValide.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdValide.Location = new System.Drawing.Point(432, 39);
            this.cmdValide.Name = "cmdValide";
            this.cmdValide.Padding = new System.Windows.Forms.Padding(5);
            this.cmdValide.Size = new System.Drawing.Size(132, 44);
            this.cmdValide.TabIndex = 2;
            this.cmdValide.Text = "Valider";
            this.cmdValide.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdValide.UseVisualStyleBackColor = true;
            this.cmdValide.Click += new System.EventHandler(this.cmdValide_Click);
            // 
            // Parametres
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 419);
            this.Controls.Add(this.cmdHelp);
            this.Controls.Add(this.cmdValide);
            this.Controls.Add(this.lblTitre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Parametres";
            this.Text = "Parametres";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Button cmdValide;
        private System.Windows.Forms.Button cmdHelp;
    }
}