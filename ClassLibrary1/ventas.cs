using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
  public  class ventas
  {
      public DateTime FECHA { get; set; }
      public int ID_CLIENTE { get; set; }
      public int ID_FACTURA { get; set; }
      public int ID_VENDEDOR { get; set; }
      public int ID_PRODUCTO { get; set; }
      public int Cantidad { get; set; }
   
    }
}
