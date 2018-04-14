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
    public partial class Form_MantenimientoProveedores : Form
    {
        private proveedorBL ProveedorBL;
        public Form_MantenimientoProveedores()
        {
            InitializeComponent();
            ProveedorBL = new proveedorBL();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            Limpiar(txtcodigo,txtnombre,txtdireccion,txtpais);
            txtnombre.Focus();
        }

        public void Limpiar(params TextBox[] text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                text[i].Clear();
            }
            txtnombre.Focus();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Form_BuscarProveedor buscarProveedor = new Form_BuscarProveedor();
            if (buscarProveedor.ShowDialog() == DialogResult.OK)
            {
                var proveedor = buscarProveedor.Proveedor;
                if (proveedor != null)
                {
                    txtcodigo.Text = proveedor.ID_PROVEEDOR.ToString();
                    txtnombre.Text = proveedor.NOMB_PROVEEDOR;
                    txtpais.Text = proveedor.PAIS;
                    txtdireccion.Text = proveedor.DIRECCION;
                }
               
            }
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtcodigo.Text))
            {
                MessageBox.Show("no se puede insertar no esta en modo de insercion");
                return;
            }

            var p = new proveedor();
            p.NOMB_PROVEEDOR = txtnombre.Text;
            p.DIRECCION = txtdireccion.Text;
            p.PAIS = txtpais.Text;

            ProveedorBL.InsertarFabricantes(p);
            MessageBox.Show("Proveedor insertado con exito!");
            toolStripLabel1_Click(null,null);
            return;
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtcodigo.Text))
            {
                MessageBox.Show("no se puede actualizar esta en modo de insercion");
                return;
            }

            var p = new proveedor {
                ID_PROVEEDOR = int.Parse(txtcodigo.Text),
                NOMB_PROVEEDOR = txtnombre.Text,
                DIRECCION = txtdireccion.Text,
                PAIS = txtpais.Text
            };

            ProveedorBL.Actualizarproveedor(p);
            MessageBox.Show("Proveedor actualizado con exito!!");
            toolStripLabel1_Click(null, null);
            return;
        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtcodigo.Text))
            {
                MessageBox.Show("debe tener codigo para eliminar");
                return;
            }

            var message = MessageBox.Show("Desea eliminar este registro?","Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.Yes)
            {
                var p = new proveedor { ID_PROVEEDOR = int.Parse(txtcodigo.Text) };
                ProveedorBL.EliminarPROVEEDOR(p);
                MessageBox.Show("Registro eliminado con exito");
                toolStripLabel1_Click(null, null);
                return;
            }
        }
    }
}
