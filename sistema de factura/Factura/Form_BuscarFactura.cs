using logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sistema_de_factura.Factura
{
    public partial class Form_BuscarFactura : Form
    {
        private facturaBL facturaBL;
        public Form_BuscarFactura()
        {
            InitializeComponent();
            facturaBL = new facturaBL();
        }

        private void Form_BuscarFactura_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = facturaBL.ObtenerVentas(null);
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int facturaid = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            FacturaID = facturaid;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public int FacturaID { get; set; }
    }
}
