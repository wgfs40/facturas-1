using logica;
using sistema_de_factura.Proveedor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sistema_de_factura.Factura
{
    public partial class Form_MantenimientoFactura : Form
    {
         private clienteBL clienteBL;
        private proveedorBL proveedorBL;
        public Form_MantenimientoFactura()
        {
            InitializeComponent();
            clienteBL = new clienteBL();
            proveedorBL = new proveedorBL();
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            Form_listaCliente listaCliente = new Form_listaCliente(); 

            if (listaCliente.ShowDialog() == DialogResult.OK)
            {
                var cliente = clienteBL.ObtenerClientePorId(listaCliente.ClienteID);
                txtCodCliente.Text = cliente.ID_CLIENTE.ToString();
                txtClienteNombre.Text = cliente.NOMB_CLIENTE;
            }
           
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            Form_BuscarProveedor buscarProveedor = new Form_BuscarProveedor();
            if (buscarProveedor.ShowDialog() == DialogResult.OK)
            {
                var proveedor = buscarProveedor.Proveedor;
                txtCodProveedor.Text = proveedor.ID_PROVEEDOR.ToString();
                txtProveedorNombre.Text = proveedor.NOMB_PROVEEDOR;
            }
        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            Form_BuscarProducto form_Buscar = new Form_BuscarProducto();
            if (form_Buscar.ShowDialog() == DialogResult.OK)
            {
                var producto = form_Buscar.Producto;
                txtCodProducto.Text = producto.ID_PRODUCTO.ToString();
                txtNombreProducto.Text = producto.DESC_PRODUCTO;
                txtPrecio.Text = producto.PRECIO.ToString();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarDetalleFactura())
            {
                DataGridViewDetalleFactura.Rows.Add(txtCodProducto.Text, txtNombreProducto.Text, txtCantidad.Text, txtPrecio.Text);
            }
            else
            {
                MessageBox.Show($"el producto {txtNombreProducto.Text} ya esta en detalle de factura");
                return;
            }
            
        }

        private bool ValidarDetalleFactura()
        {
            bool success = true;

            foreach (DataGridViewRow row in DataGridViewDetalleFactura.Rows)
            {
                var productoid = row.Cells[0].Value.ToString();
                if (txtCodProducto.Text.Equals(productoid))
                {
                    return success = false;
                }
            }



            return success;
        }
    }
}
