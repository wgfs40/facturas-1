using Entidades;
using logica;
using sistema_de_factura.Proveedor;
using sistema_de_factura.Vendedor;
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
        private productoBL productoBL;
        private facturaBL facturaBL;

        public Form_MantenimientoFactura()
        {
            InitializeComponent();
            clienteBL = new clienteBL();
            proveedorBL = new proveedorBL();
            productoBL = new productoBL();
            facturaBL = new facturaBL();
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            Form_listaCliente listaCliente = new Form_listaCliente(); 

            if (listaCliente.ShowDialog() == DialogResult.OK)
            {
                var cliente = clienteBL.ObtenerClientePorId(listaCliente.ClienteID);
                txtCodCliente.Text = cliente.ID_CLIENTE.ToString();
                txtClienteNombre.Text = cliente.NOMB_CLIENTE;
                txtSaldoInicial.Text = cliente.SALDO_INI.ToString("n");
                txtSaldoFinal.Text = cliente.SALDO_FINAL.ToString("n");
            }
           
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            Form_BuscanVendedor buscanVendedor = new Form_BuscanVendedor();
            if (buscanVendedor.ShowDialog() == DialogResult.OK)
            {
                var v = buscanVendedor.Vendedor;
                txtCodVendedor.Text = v.ID_VENDEDOR.ToString();
                txtVendedorNombre.Text = v.NOMB_VENDEDOR;
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
                Limpiar(txtCodProducto,txtNombreProducto,txtCantidad,txtPrecio);
                txtCodProducto.Focus();
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
        private void Limpiar(params TextBox[] text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                text[i].Clear();
            }

        }

        private void txtCodProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (int.TryParse(txtCodProducto.Text, out int productoid))
                {
                    var producto = productoBL.ObtenerProductoPorId(productoid);
                    txtCodProducto.Text = producto.ID_PRODUCTO.ToString();
                    txtNombreProducto.Text = producto.DESC_PRODUCTO;
                    txtPrecio.Text = producto.PRECIO.ToString();
                    txtCantidad.Focus();
                }
                else
                {
                    MessageBox.Show("el codigo del producto es solo numerico");
                    txtCodProducto.Focus();
                    return;
                }


            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var fact = new factura();
            fact.ID_CLIENTE = int.Parse(txtCodCliente.Text);
            fact.ID_VENDEDOR = 1;

            foreach (DataGridViewRow row in DataGridViewDetalleFactura.Rows)
            {
                var detallefact = new facturadetalle();
                detallefact.PRODUCTOID = int.Parse(row.Cells["ColumnCodProducto"].Value.ToString());
                detallefact.CANTIDAD = int.Parse(row.Cells["ColumnCantidad"].Value.ToString());
                detallefact.PRECIO = float.Parse(row.Cells["ColumnPrecio"].Value.ToString());

                fact.FACTURADETALLE.Add(detallefact);
            }

            facturaBL.Insertarfactura(fact);

        }

       
        private void DataGridViewDetalleFactura_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            switch (DataGridViewDetalleFactura.CurrentCell.ColumnIndex)
            {
                case 2:
                    DataGridViewDetalleFactura.BeginEdit(true);
                    break;
                default:
                    DataGridViewDetalleFactura.CurrentCell.ReadOnly = true;
                    break;
            }

           
        }

        private void DataGridViewDetalleFactura_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (DataGridViewDetalleFactura.CurrentCell.ColumnIndex)
            {               
                case 4:
                    DataGridViewDetalleFactura.Rows.RemoveAt(e.RowIndex);
                    //MessageBox.Show((e.RowIndex + 1) + "  Row  " + (e.ColumnIndex + 1) + "  Column button clicked ");
                    break;
                default:
                    DataGridViewDetalleFactura.CurrentCell.ReadOnly = true;
                    break;
            }
        }
    }
}
