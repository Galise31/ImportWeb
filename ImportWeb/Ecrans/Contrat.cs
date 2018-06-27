using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Xsl;

namespace ImportWeb
{
    public partial class Contrat : Form
    {
        public Contrat()
        {
            InitializeComponent();

            using (XmlReader loFile = XmlReader.Create(new StringReader(IwTools.cIW)))
            {
                string xslFile = new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + ".xsl").FullName.ToString();
                if (!File.Exists(xslFile))
                {
                    MessageBox.Show("Fichier " + xslFile + " introuvable", "ImportWeb", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                XslCompiledTransform xslDocument = new XslCompiledTransform();
                xslDocument.Load(xslFile);
                StringWriter stringWriter = new StringWriter();
                XmlWriter xmlWriter = new XmlTextWriter(stringWriter);

                xslDocument.Transform(loFile, xmlWriter);
                webBrowser.DocumentText = stringWriter.ToString();
                webBrowser.Visible = true;
            }
        }
    }
}
