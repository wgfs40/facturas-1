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
    public partial class Form_Login : Form
    {
        private usuarioBL usuarioBL = new usuarioBL(); 

        public Form_Login()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtusuario.Text;
            string clave = txtclave.Text;

            if (string.IsNullOrEmpty(txtusuario.Text.Trim()))
            {
                MessageBox.Show("el nombre de usuario no puede estar vacio.");
                txtusuario.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtclave.Text.Trim()))
            {
                MessageBox.Show("la clave de usuario no puede estar vacio.");
                txtusuario.Focus();
                return;
            }

            if (usuarioBL.ValidarUsuario(usuario,clave))
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("el nombre de usuario y/o clave es incorrecto.");
                return;
            }
        }
    }
}
