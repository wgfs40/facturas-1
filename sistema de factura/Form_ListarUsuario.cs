using logica;
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
    public partial class Form_ListarUsuario : Form
    {
        private usuarioBL usuarioBL;
        public Form_ListarUsuario()
        {
            InitializeComponent();
            usuarioBL = new usuarioBL();
            dataGridViewUsuario.AutoGenerateColumns = false;
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            dataGridViewUsuario.DataSource =
                usuarioBL.ListarUsuario(txtBusqueda.Text);
                
        }

        private void dataGridViewUsuario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Usuarioid = Convert.ToInt32(dataGridViewUsuario.CurrentRow.Cells["ColumncodUsuario"].Value);
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        public int Usuarioid { get; set; }

    }
}
