using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
  public  class cliente
  {
        public int ID_CLIENTE { get; set; }

        public string NOMB_CLIENTE { get; set; }
        public string DIRECCION { get; set; }
        public string PAIS { get; set; }

        public float SALDO_INI { get; set; }
        public float SALDO_FINAL { get; set; }

  }
}
