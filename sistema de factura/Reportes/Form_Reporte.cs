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
        public Form_Reporte()
        {
            InitializeComponent();
            facturaBL = new facturaBL();
        }

        private void Form_Reporte_Load(object sender, EventArgs e)
        {
            ReportParameter parameterFactura = new ReportParameter("FacturaId", "6");
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parameterFactura });

            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSetFactura", facturaBL.ObtenerVentas(6)));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSetDetalle", facturaBL.ObtenerDetalleFactura(6)));
            this.reportViewer1.RefreshReport();           
        }
    }
}
