using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using datos;
using System.Data;
using ClassLibrary1;

namespace logica
{
   public class facturaBL
    {

        public DataTable ObtenerVentas()
        {
            facturaDAL Obtener = new facturaDAL();
            return Obtener.ObtenerVentas();
        }

        public void Insertarfactura(factura entidad)
        {
            facturaDAL Insertar = new facturaDAL();
            Insertar.Insertarfactura(entidad);
        }

        public void ActualizarVentas(factura entidad, int param)
        {
            facturaDAL Actualizar = new facturaDAL();
            Actualizar.Actualizarfactura(entidad, param);
        }

        public void EliminarVentas(factura entidad, int param)
        {
            facturaDAL Eliminar = new facturaDAL ();
            Eliminar.Eliminarfactura(entidad);
        }

        public DataTable BuscarVentas(string param, string opcion)
        {
            facturaDAL Buscar = new facturaDAL();

            return Buscar.Buscarfactura(param, opcion);
        }

        public DataTable ObtenerfacturaClientes()
        {
            return new facturaDAL().ObtenerfacturaCliente();
        }

    }
}
