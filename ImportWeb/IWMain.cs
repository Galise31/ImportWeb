using System;
using System.Collections.Generic;
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
    }
}
