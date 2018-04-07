using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public class factura
    {
        public int ID_FACTURAS { get; set; }
        public int ID_CLIENTE { get; set; }
        public int ID_PRODUCTO { get; set; }
        public int ID_VENDEDOR { get; set; }
        public float SALDOINICIAL { get; set; }
        public float SALDOFINAL { get; set; }
    }
}
