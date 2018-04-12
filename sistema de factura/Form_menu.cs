using logica;
using sistema_de_factura.Producto;
using sistema_de_factura.Vendedor;
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
            frmusuario.MdiParent = this;
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
                    Form_CrearUsuario actualizarusuario = new Form_CrearUsuario(usuario);                    
                    if(actualizarusuario.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("el usuario ha sido Guardado con exito.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                }
                else
                {
                    MessageBox.Show("El usuario no existe!","Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private void mantenimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Mantenimiento_Cliente mantenimiento_Cliente = new Form_Mantenimiento_Cliente();
            mantenimiento_Cliente.MdiParent = this;
            mantenimiento_Cliente.Show();
        }

        private void Form_menu_Load(object sender, EventArgs e)
        {
            statusStrip1.Items[1].Text = Global.nombreusuario;
        }

        private void mantenimientoDeProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_MantenimientoProducto mantenimientoProducto = new Form_MantenimientoProducto();
            mantenimientoProducto.MdiParent = this;
            mantenimientoProducto.Show();
        }

        private void mantenimientoDeVendedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_MantenimientoVendedor vendedorform = new Form_MantenimientoVendedor();
            vendedorform.MdiParent = this;
            vendedorform.Show();
        }
    }
}
