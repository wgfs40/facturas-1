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
    public partial class Form_listaCliente : Form
    {
        private clienteBL clienteBL;
        public Form_listaCliente()
        {
            InitializeComponent();
            clienteBL = new clienteBL();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dataGridViewCliente.DataSource = 
                clienteBL.BusquedaClientes(txtBuscarCliente.Text, cboOpcion.Text);
        }

        private void dataGridViewCliente_DoubleClick(object sender, EventArgs e)
        {
            UsuarioId = Convert.ToInt32(dataGridViewCliente.CurrentRow.Cells[0].Value);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public int UsuarioId { get; set; }
    }
}
