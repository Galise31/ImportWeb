using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Xsl;

namespace ImportWeb
{
    // -------------------------------------------------------------
    // Affiche le résultat de l'ImportWeb d'un contrat dans une page Web
    // -------------------------------------------------------------
    public partial class Contrat : Form
    {
        public Contrat()
        {
            InitializeComponent();

            // On transforme le flux XMl avec une feuille XSL
            using (XmlReader loFile = XmlReader.Create(new StringReader(IwTools.cIW)))
            {
               //string xslFile = new FileInfo(System.Reflection.Assembly.GetEntryAssembly().GetName().Name + ".xsl").FullName.ToString();
               string xslFile = System.Reflection.Assembly.GetEntryAssembly().Location.Replace("ImportWeb.exe", "ImportWeb.xsl");
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
