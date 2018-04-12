using Entidades;
using logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sistema_de_factura.Vendedor
{
    public partial class Form_BuscanVendedor : Form
    {
        private vendedorBL vendedorBL;
        public Form_BuscanVendedor()
        {
            InitializeComponent();
            vendedorBL = new vendedorBL();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (radioButtonID.Checked)
            {
                var listavendedor = vendedorBL.BuscarVendedores(txtBuscar.Text, "Id");
                dataGridViewVendedor.DataSource = listavendedor;
            }
            else
            {
                var listavendedor = vendedorBL.BuscarVendedores(txtBuscar.Text, "Nombre");
                dataGridViewVendedor.DataSource = listavendedor;
            }
        }

        public vendedor Vendedor { get; set; }

        private void dataGridViewVendedor_DoubleClick(object sender, EventArgs e)
        {
            int vendedorid = Convert.ToInt32(dataGridViewVendedor.CurrentRow.Cells[0].Value);
            Vendedor = vendedorBL.ObtenerVendedorPorId(vendedorid);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
