using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using datos;
using System.Data;
using Entidades;

namespace logica
{
   public class facturaBL
    {
        private acceso AccesoDatos;
        private productoBL productoBL;

        public facturaBL()
        {
            AccesoDatos = new acceso();
            productoBL = new productoBL();
        }

        public DataTable ObtenerVentas()
        {
            facturaDAL Obtener = new facturaDAL();
            return Obtener.ObtenerVentas();
        }

        public void Insertarfactura(factura entidad)
        {
            AccesoDatos.IniciarTransaction();

            facturaDAL Insertar = new facturaDAL(AccesoDatos);           
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
