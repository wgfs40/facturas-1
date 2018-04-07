using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using datos;
using System.Data;
using ClassLibrary1;

namespace logica
{
   public class ventasBL
    {

        public DataTable ObtenerVentas()
        {
            ventasDAL Obtener = new ventasDAL();
            return Obtener.ObtenerVentas();
        }

        public void InsertarVentas(ventas entidad)
        {
            ventasDAL Insertar = new ventasDAL();
            Insertar.InsertarVentas(entidad);
        }

        public void ActualizarVentas(ventas entidad, int param)
        {
            ventasDAL Actualizar = new ventasDAL();
            Actualizar.ActualizarVentas(entidad, param);
        }

        public void EliminarVentas(ventas entidad, int param)
        {
            ventasDAL Eliminar = new ventasDAL();
            Eliminar.EliminarVentas(entidad);
        }

        public DataTable BuscarVentas(string param, string opcion)
        {
            ventasDAL Buscar = new ventasDAL();

            return Buscar.BuscarVentas(param, opcion);
        }

        public DataTable ObtenerventasClientes()
        {
            return new ventasDAL().ObtenerVentasClientes();
        }
    }
}
