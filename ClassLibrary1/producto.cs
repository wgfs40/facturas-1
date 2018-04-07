using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class producto
    {
        public int ID_PRODUCTO { get; set; }
        public string DESC_PRODUCTO { get; set; }
        public int ID_PROVEEDOR { get; set; }

        public float COSTO { get; set; }
        public float PRECIO { get; set; }
    }
}
