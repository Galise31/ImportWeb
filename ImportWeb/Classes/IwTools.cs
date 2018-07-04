using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace ImportWeb
{
    // -------------------------------------------------------------
    // Classe u(ilisée pour mémoriser les paramètres de l'ImportWeb demandé
    // -------------------------------------------------------------
    public class IwTools
    {
        public static importwebvfp.ImportWeb_VFP loIW { get; set; }
        public static string cAppli { get; set; }
        public static string cAction { get; set; }
        public static string cActionParam { get; set; }
        public static string cIW { get; set; }
        public static string cIWUser { get; set; }
        public static string cIWPwd { get; set; }

        // -------------------------------------------------------------
        // Charge la liste des procédures disponiblres dans votre ImportWeb
        // -------------------------------------------------------------
        public static DataTable IW_Liste()
        {
            DataTable dtProc = new DataTable();

            string lcData = @"<IW>
	<User>TEST</User>
	<Pwd>TEST</Pwd>
	<Action>ListeProc</Action>
	<ActionParam></ActionParam>
	<Cie>compagnie</Cie>
	<CieLogin>TEST</CieLogin>
	<CiePwd>TEST</CiePwd>
	<cXMLReponse></cXMLReponse>
	<nOption>0</nOption>
	<CieParam></CieParam>
</IW>";
            lcData = loIW.Start(lcData);
            if (loIW.CERREUR.ToString() != String.Empty)
            {
                MessageBox.Show(IwTools.loIW.CXMLREPONSE.ToString(), "Erreur ImportWeb", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dtProc;
            };

            // On remplit la DataTable
            DataColumn dcProc = new DataColumn("Proc");
            dcProc.DataType = System.Type.GetType("System.String");

            dtProc.Columns.Add(dcProc);

            lcData = loIW.CXMLREPONSE.ToString();
            string[] lines = lcData.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            foreach (string line in lines)
            {
                if (line != string.Empty)
                {
                    DataRow row = dtProc.NewRow();
                    row[dcProc] = line;
                    dtProc.Rows.Add(row);
                }
            }
            dtProc.DefaultView.Sort = "Proc";

            return dtProc;
        }

        
        // -------------------------------------------------------------
        // Fonction d'extraction entre 2 délimiteurs
        // -------------------------------------------------------------
        public static string strExtract(string content, string startString, string endString)
        {
            int Start = 0, End = 0;
            if (content.Contains(startString) && content.Contains(endString))
            {
                Start = content.IndexOf(startString, 0) + startString.Length;
                End = content.IndexOf(endString, Start);
                if (End == -1)
                    return string.Empty;
                return content.Substring(Start, End - Start);
            }
            else
                return string.Empty;
        }
    }

    // -------------------------------------------------------------
    // Classe de gestion des fichiers INI
    // -------------------------------------------------------------
    public class IniFile   // revision 11
    {
        string Path;
        string EXE = Assembly.GetExecutingAssembly().GetName().Name;

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

        public IniFile(string IniPath = null)
        {
            Path = new FileInfo(IniPath ?? EXE + ".ini").FullName.ToString();
        }

        public string Read(string Key, string Section = null)
        {
            if (!File.Exists(Path))
                return "";
            var RetVal = new StringBuilder(255);
            GetPrivateProfileString(Section ?? EXE, Key, "", RetVal, 255, Path);
            return RetVal.ToString();
        }

        public void Write(string Key, string Value, string Section = null)
        {
            if (!File.Exists(Path))
                File.CreateText(Path);
            WritePrivateProfileString(Section ?? EXE, Key, Value, Path);
        }
    }
}
