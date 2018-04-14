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

namespace sistema_de_factura.Proveedor
{
    public partial class Form_BuscarProveedor : Form
    {
        private proveedorBL proveedorBL;
        public Form_BuscarProveedor()
        {
            InitializeComponent();
            proveedorBL = new proveedorBL();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (radioButtonID.Checked)
            {
               var listaproveedores = proveedorBL.Buscarproveedor(txtNombre.Text, "Codigo");
                dataGridViewProveedor.DataSource = listaproveedores;
            }
            else
            {
                var listaproveedores = proveedorBL.Buscarproveedor(txtNombre.Text, "NOMB_PROVEEDOR");
                dataGridViewProveedor.DataSource = listaproveedores;
            }
        }

        private void dataGridViewProveedor_DoubleClick(object sender, EventArgs e)
        {
            var codigo = Convert.ToInt32(dataGridViewProveedor.CurrentRow.Cells[0].Value);
            Proveedor = proveedorBL.ObtenerProveedorPorId(codigo);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public proveedor Proveedor { get; set; }
    }
}
