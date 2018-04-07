using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace sistema_de_factura
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form_Login loginform = new Form_Login();
            if (loginform.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new Form_menu());
            }
           
        }
    }
}
