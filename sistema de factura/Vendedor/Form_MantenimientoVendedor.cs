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
    public partial class Form_MantenimientoVendedor : Form
    {
        private vendedorBL vendedorBL;
        public Form_MantenimientoVendedor()
        {
            InitializeComponent();
            vendedorBL = new vendedorBL();
        }

        public void Limpiar(params TextBox[] text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                text[i].Clear();
            }
            txtNombre.Focus();
        }

        private bool Validar(string val)
        {
            bool susscess = true;
            if (!float.TryParse(val, out float money))
            {
                MessageBox.Show("La cominision debe de ser numerica");
                return susscess = false;
            }

            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("El Nombre es un campo obligatorio");
                return susscess = false;
            }

            return susscess;
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            Limpiar(txtCodigo,txtComision,txtNombre);
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            if (Validar(txtComision.Text))
            {
                vendedor v = new vendedor
                {
                    NOMB_VENDEDOR = txtNombre.Text,
                    COMISION = float.Parse(txtComision.Text)
                };

                vendedorBL.InsertarVendedores(v);
                MessageBox.Show("El vendedor ha sido insertardo con exito!","informacion",MessageBoxButtons.OK, MessageBoxIcon.Information);
                toolStripLabel1_Click(null, null);
                return;
            }

           

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Form_BuscanVendedor form_Buscan = new Form_BuscanVendedor();
            if (form_Buscan.ShowDialog() == DialogResult.OK)
            {
                var vendedor = form_Buscan.Vendedor;
                txtCodigo.Text = vendedor.ID_VENDEDOR.ToString();
                txtNombre.Text = vendedor.NOMB_VENDEDOR;
                txtComision.Text = vendedor.COMISION.ToString();
            }

        }
    }
}
