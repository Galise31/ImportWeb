using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace ImportWeb
{
    static class IWMain
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Pour trouver le proxy ailleurs
            AppDomain.CurrentDomain.AssemblyResolve += AssemblyResolveHandler;

            try
            {
                IwTools.loIW = new ImportWeb_Proxy.Proxy();
            }
            catch (Exception loEx)
            {
                MessageBox.Show("Vous devez générer une application 32 bits");
            }

            if (IwTools.loIW == null)
                return;

            Application.Run(new Start());
        }

    
        internal static Assembly AssemblyResolveHandler(object sender, ResolveEventArgs args)
        {
            // This handler is called only when the common language runtime tries to bind to the assembly and fails.

            //Retrieve the list of referenced assemblies in an array of AssemblyName.
            Assembly MyAssembly, objExecutingAssemblies;
            string strTempAssmbPath = "";

            objExecutingAssemblies = Assembly.GetExecutingAssembly();
            AssemblyName[] arrReferencedAssmbNames = objExecutingAssemblies.GetReferencedAssemblies();

            //Loop through the array of referenced assembly names.
            foreach (AssemblyName strAssmbName in arrReferencedAssmbNames)
            {
                //Check for the assembly names that have raised the "AssemblyResolve" event.
                if (strAssmbName.FullName.Substring(0, strAssmbName.FullName.IndexOf(",")) == args.Name.Substring(0, args.Name.IndexOf(",")))
                {
                    IniFile loIni = new IniFile(AppDomain.CurrentDomain.BaseDirectory + "IW_Login.txt");
                    strTempAssmbPath = loIni.Read("ImportWeb", "ProxyPath");

                    if (strTempAssmbPath == string.Empty)
                        strTempAssmbPath = @"C:\Program Files (x86)\Galise\ImportWeb\";

                    if (strTempAssmbPath.EndsWith("\\")) strTempAssmbPath += "\\";

                    strTempAssmbPath += args.Name.Substring(0, args.Name.IndexOf(",")) + ".dll";
                    break;
                }
            }
            //Load the assembly from the specified path.
            MyAssembly = Assembly.LoadFrom(strTempAssmbPath);

            //Return the loaded assembly.
            return MyAssembly;
        }
    }
}
