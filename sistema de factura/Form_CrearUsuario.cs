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
        private int usuarioid;

        public Form_CrearUsuario()
        {
            InitializeComponent();
        }

        public Form_CrearUsuario(usuario usuario)
        {
            InitializeComponent();            
            if (usuario != null)
            {
                usuarioid = usuario.UsuarioId;
                txtusuario.Text = usuario.Usuario;                
                
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtClave.Text != txtConfirmarClave.Text)
            {
                MessageBox.Show("la clave coincide");
                return;
            }

            if (usuarioid > 0)
            {
                usuario actulizarusuario = new usuario
                {
                    UsuarioId = usuarioid,
                    Usuario = txtusuario.Text,
                    Clave = txtClave.Text
                };

                usuarioBL.ActualizarUsuario(actulizarusuario);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                usuario usuariocrear = new usuario
                {
                    Usuario = txtusuario.Text,
                    Clave = txtClave.Text
                };
                usuarioBL.InsertarUsuario(usuariocrear);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
