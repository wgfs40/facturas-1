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

namespace sistema_de_factura
{
    public partial class Form_BuscarProducto : Form
    {
        private productoBL productoBL;
        public Form_BuscarProducto()
        {
            InitializeComponent();
            productoBL = new productoBL();
        }

        private void Form_BuscarProducto_Load(object sender, EventArgs e)
        {
            dataGridViewProducto.DataSource = productoBL.LlenarProductos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DataTable dtproductos;
            if (radioButtonDescripcion.Checked)
            {
                dtproductos = productoBL.BuscarProductos(txtproducto.Text, "Descripcion");

            }
            else
            {
                int codigo = 0;
                if (!int.TryParse(txtproducto.Text,out codigo))
                {
                    MessageBox.Show("la seleccion es codigo y solo se permite valor numerico");
                    return;
                }

                dtproductos = productoBL.BuscarProductos(txtproducto.Text, "ID_PROVEEDOR");
            }

            dataGridViewProducto.DataSource = dtproductos;
            
        }

        private void dataGridViewProducto_DoubleClick(object sender, EventArgs e)
        {
            var productoid = Convert.ToInt32(dataGridViewProducto.CurrentRow.Cells[0].Value);
            Producto = productoBL.ObtenerProductoPorId(productoid);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public producto Producto { get; set; }
    }
}
