﻿using logica;
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
    public partial class Form_menu : Form
    {
        private usuarioBL usuarioBL;
        public Form_menu()
        {
            InitializeComponent();
            usuarioBL = new usuarioBL();
        }

        private void crearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_CrearUsuario frmusuario = new Form_CrearUsuario();
            frmusuario.Show();
        }

        private void listarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_ListarUsuario frmlistarusuario = new Form_ListarUsuario();
            if (frmlistarusuario.ShowDialog() == DialogResult.OK)
            {
                var usuario = usuarioBL.ObtenerUsuarioPorId(frmlistarusuario.Usuarioid);
                if (usuario != null)
                {

                }
                else
                {
                    MessageBox.Show("El usuario no existe!","Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }
    }
}
