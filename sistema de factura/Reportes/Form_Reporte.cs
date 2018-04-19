using logica;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sistema_de_factura.Reportes
{
    public partial class Form_Reporte : Form
    {
        private facturaBL facturaBL;
        private int Facturaid = 0;
        public Form_Reporte()
        {
            InitializeComponent();
            facturaBL = new facturaBL();
        }

        public Form_Reporte(int facturaid)
        {
            InitializeComponent();
            facturaBL = new facturaBL();
            Facturaid = facturaid;
        }

        private void Form_Reporte_Load(object sender, EventArgs e)
        {
            if (Facturaid > 0)
            {
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSetFactura", facturaBL.ObtenerVentas(Facturaid)));
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSetDetalle", facturaBL.ObtenerDetalleFactura(Facturaid)));
                this.reportViewer1.RefreshReport();
            }
                 
        }
    }
}
