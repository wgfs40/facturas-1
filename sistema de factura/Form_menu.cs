using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sistema_de_factura
{
    public partial class Form_menu : Form
    {
        public Form_menu()
        {
            InitializeComponent();
        }

        private void crearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_CrearUsuario frmusuario = new Form_CrearUsuario();
            frmusuario.Show();
        }
    }
}
