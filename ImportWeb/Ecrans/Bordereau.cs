using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImportWeb
{
    public partial class Bordereau : Form
    {
        public Bordereau()
        {
            InitializeComponent();

            DataTable dt = new DataTable();
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
                dt.Columns.Add(dataGridView1.Columns[i].DataPropertyName);

            string[] laLignes = IwTools.cIW.Split(new[] { Environment.NewLine}, StringSplitOptions.None);
            string[] data_col = null;
            int x = 0;

            foreach (string text_line in laLignes)
            {
                data_col = text_line.Split('\t');
                Array.Resize(ref data_col, 5);
                dt.Rows.Add(data_col);
            }
            dataGridView1.DataSource = dt;
        }
    }
}
