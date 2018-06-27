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
                IwTools.loIW = new importwebvfp.ImportWeb_VFP();
            }
            catch (System.Runtime.InteropServices.COMException loEx)
            {
                MessageBox.Show("Vous devez générer une application 32 bits");
            }
            catch (Exception loEx)
            {
                throw loEx;
            }

            if (IwTools.loIW == null)
                return;

            Application.Run(new Start());
        }
    }
}
