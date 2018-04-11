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

namespace sistema_de_factura.Producto
{
    public partial class Form_MantenimientoProducto : Form
    {
        private proveedorBL proveedorBL;
        private productoBL productoBL;
        public Form_MantenimientoProducto()
        {
            InitializeComponent();
            proveedorBL = new proveedorBL();
            productoBL = new productoBL();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            Limpiar(txtCodigo,txtCodigo,txtDescripcion,txtCosto,txtPrecio);
            cboProveedor.SelectedItem = -1;
        }

       
        private void Form_MantenimientoProducto_Load(object sender, EventArgs e)
        {
            llenarproveedor();
            llenargridproducto();
            txtDescripcion.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_BuscarProducto form_Buscar = new Form_BuscarProducto();
            if (form_Buscar.ShowDialog() == DialogResult.OK)
            {
                var producto = form_Buscar.Producto;
                txtCodigo.Text = producto.ID_PRODUCTO.ToString();
                txtDescripcion.Text = producto.DESC_PRODUCTO;
                txtCosto.Text = producto.COSTO.ToString();
                txtPrecio.Text = producto.PRECIO.ToString();
            }

        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                if (string.IsNullOrEmpty(txtCodigo.Text))
                {
                    var p = new producto();
                    p.DESC_PRODUCTO = txtDescripcion.Text;
                    p.ID_PROVEEDOR = Convert.ToInt32(cboProveedor.SelectedValue);
                    p.COSTO = float.Parse(txtCosto.Text);
                    p.PRECIO = float.Parse(txtPrecio.Text);

                    productoBL.InsertarProductos(p);
                    toolStripLabel1_Click(null, null);
                    MessageBox.Show("Producto ha sido insertado con exito!.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    llenargridproducto();
                    return;
                }
                else
                {
                    MessageBox.Show("No se puede insertar puesta en modo de actualizar.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;

                }

               
            }
        }
        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                var codigoproducto = int.Parse(txtCodigo.Text);
                var p = new producto
                {
                    ID_PRODUCTO = codigoproducto,
                    ID_PROVEEDOR = Convert.ToInt32(cboProveedor.SelectedValue),
                    DESC_PRODUCTO = txtDescripcion.Text,
                    COSTO = float.Parse(txtCosto.Text),
                    PRECIO = float.Parse(txtPrecio.Text)
                };

                if (validar())
                {
                    productoBL.ActualizarProductos(p);
                    MessageBox.Show("Producto actualizado con exito!.", "informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    toolStripLabel1_Click(null, null);
                    llenargridproducto();
                    return;
                }

            }
        }


        #region Metodos privados

        private bool validar()
        {
            bool sucess = true;
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                MessageBox.Show("La descripcion del producto no puede estar vacia!");
                txtDescripcion.Focus();
                return sucess = false;
            }

            if (string.IsNullOrEmpty(txtCosto.Text))
            {                
                MessageBox.Show("El Costo no puede estar Vacio");
                txtCosto.Focus();
                return sucess = false;
            }

            var costo = (float)0.0;
            if (!float.TryParse(txtCosto.Text, out costo))
            {
                MessageBox.Show("El costo el solo numerico!");
                txtCosto.Focus();
                return sucess = false;
            }

            if (string.IsNullOrEmpty(txtCosto.Text))
            {                
                MessageBox.Show("El precio no puede estar Vacio");
                txtPrecio.Focus();
                return sucess = false;
            }

            var precio = (float)0.0;
            if (!float.TryParse(txtPrecio.Text, out precio))
            {
                MessageBox.Show("El precio el solo numerico!");
                txtPrecio.Focus();
                return sucess = false;
            }


            return sucess;
        }

        private void llenarproveedor()
        {
            var listaproveedores = proveedorBL.Obtenerproveedor();
            cboProveedor.ValueMember = "ID_PROVEEDOR";
            cboProveedor.DisplayMember = "NOMB_PROVEEDOR";
            cboProveedor.DataSource = proveedorBL.Obtenerproveedor();
        }

        private void llenargridproducto()
        {
            var listaproducto = productoBL.LlenarProductos();
            dataGridViewProducto.DataSource = listaproducto;
        }

        private void Limpiar(params TextBox[] text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                text[i].Clear();
            }
        }


        #endregion

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                var codigoproducto = int.Parse(txtCodigo.Text);
                var p = new producto
                {
                    ID_PRODUCTO = codigoproducto
                };

                if (validar())
                {
                    if (MessageBox.Show("Desea eliminar el producto?","Aviso",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        productoBL.EliminarProductos(p);
                        MessageBox.Show("Producto Eliminado con exito!.", "informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        toolStripLabel1_Click(null, null);
                        llenargridproducto();
                        return;
                    }
                    
                }

            }
        }
    }
}
