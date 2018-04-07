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
    public partial class Form_Mantenimiento_Cliente : Form
    {
        private clienteBL clienteBL;
        public Form_Mantenimiento_Cliente()
        {
            InitializeComponent();
            clienteBL = new clienteBL();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            //nuevo
            Limpiar(txtNombre, txtPais, txtDireccion);
            txtNombre.Focus();

        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            //agregar

            if (ValidarMonto(txtSaldoInicial.Text) == false)
            {
                MessageBox.Show("El campo sueldo inicial es solo numerico");
                txtSaldoInicial.Focus();
                return;
            }

            if (ValidarMonto(txtSaldoFinal.Text) == false)
            {
                MessageBox.Show("El campo sueldo actual es solo numerico");
                txtSaldoFinal.Focus();
                return;
            }

            cliente cliente = new cliente
            {
                NOMB_CLIENTE = txtNombre.Text,
                PAIS = txtPais.Text,
                DIRECCION = txtDireccion.Text,
                SALDO_INI = float.Parse(txtSaldoInicial.Text.Replace("$RD ", "").Trim()),
                SALDO_FINAL = float.Parse(txtSaldoFinal.Text.Replace("$RD ", "").Trim())
            };

            clienteBL.RegClientes(cliente);
            MessageBox.Show("Cliente insertado con exito","Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            toolStripLabel1_Click(null, null); // limpiamos lo campos de pues de grabar.
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            //actualizar
            Form_listaCliente form_ListaCliente = new Form_listaCliente();
            if (form_ListaCliente.ShowDialog() == DialogResult.OK)
            {

            }

        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {
            //eliminar
        }

        public void Limpiar(params TextBox[] text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                text[i].Clear();
            }

            txtSaldoFinal.Clear();
            txtSaldoInicial.Clear();

        }
        private bool ValidarMonto(string val)
        {
            val = val.Replace("$RD ", "").Trim(); 
            bool susscess = true;
            if (!float.TryParse(val, out float money))
            {
                susscess = false;                
            }

            return susscess;
        }
    }
}
