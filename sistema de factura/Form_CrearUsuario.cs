using ClassLibrary1;
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
    public partial class Form_CrearUsuario : Form
    {
        private usuarioBL usuarioBL = new usuarioBL();

        public Form_CrearUsuario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtClave.Text != txtConfirmarClave.Text)
            {
                MessageBox.Show("la clave coincide");
                return;
            }

            usuario usuario = new usuario {
                Usuario = txtusuario.Text,
                Clave = txtClave.Text
            };

            usuarioBL.InsertarUsuario(usuario);
            MessageBox.Show("el usuario ha sido creado.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
