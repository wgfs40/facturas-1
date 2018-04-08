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
        private int clienteid = 0;
        public Form_Mantenimiento_Cliente()
        {
            InitializeComponent();
            clienteBL = new clienteBL();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            //nuevo
            Limpiar(txtNombre, txtPais, txtDireccion,txtSaldoInicial,txtSaldoFinal);
            txtNombre.Focus();
            clienteid = 0;

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

            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("el nombre no puede estar vacio.!");
                txtNombre.Focus();
                return;
            }

            //if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                MessageBox.Show("la direccion es un campo obligatorio");
                txtDireccion.Focus();
                return;
            }

            var cliente = new cliente
            {
                NOMB_CLIENTE = txtNombre.Text,
                PAIS = txtPais.Text,
                DIRECCION = txtDireccion.Text,
                SALDO_INI = float.Parse(txtSaldoInicial.Text),
                SALDO_FINAL = float.Parse(txtSaldoFinal.Text)
            };

            clienteBL.RegClientes(cliente);
            MessageBox.Show("Cliente insertado con exito","Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            toolStripLabel1_Click(null, null); // limpiamos lo campos de pues de grabar.
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            //actualizar
            Form_listaCliente form_ListaCliente = new Form_listaCliente();

            if (clienteid == 0)
            {
                if (form_ListaCliente.ShowDialog() == DialogResult.OK)
                {
                    var cliente = clienteBL.ObtenerClientePorId(form_ListaCliente.ClienteID);
                    if (cliente != null)
                    {
                        clienteid = cliente.ID_CLIENTE;
                        txtNombre.Text = cliente.NOMB_CLIENTE;
                        txtPais.Text = cliente.PAIS;
                        txtDireccion.Text = cliente.DIRECCION;
                        txtSaldoInicial.Text = cliente.SALDO_INI.ToString("n");
                        txtSaldoFinal.Text = cliente.SALDO_FINAL.ToString("n");
                        return;
                    }
                }
            }

            if (clienteid > 0)
            {
                var client = new cliente();
                client.ID_CLIENTE = clienteid;
                client.NOMB_CLIENTE = txtNombre.Text;
                client.PAIS = txtPais.Text;
                client.DIRECCION = txtDireccion.Text;
                client.SALDO_INI = float.Parse(txtSaldoInicial.Text);
                client.SALDO_FINAL = float.Parse(txtSaldoFinal.Text);

                clienteBL.ActualizarClientes(client);
                MessageBox.Show("El cliente ha sido actualizado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                toolStripLabel1_Click(null, null); // limpiamos lo campos de pues de grabar.
                return;
            }

            
            

        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {
            //eliminar
            Form_listaCliente form_ListaCliente = new Form_listaCliente();
            if (form_ListaCliente.ShowDialog() == DialogResult.OK)
            {
                if (MessageBox.Show("Desea eliminar el registro?","Importante", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    clienteBL.EliminarClientes(form_ListaCliente.ClienteID);
                    MessageBox.Show("El registro ha sido eliminado.!");
                    return;
                }
                
            }
        }

        public void Limpiar(params TextBox[] text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                text[i].Clear();
            }

            clienteid = 0;

        }

        private bool ValidarMonto(string val)
        {            
            bool susscess = true;
            if (!float.TryParse(val, out float money))
            {
                susscess = false;                
            }

            return susscess;
        }
    }
}
