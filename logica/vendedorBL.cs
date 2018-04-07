using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using datos;
using System.Data;
using Entidades;

namespace logica
{
   public class vendedorBL
    {
        public DataTable ObtenerVendedor()
        {
            vendedorDAL ObtenerVendedor = new vendedorDAL();
            return ObtenerVendedor.Obtenervendedor();
        }

        public void InsertarVendedores(vendedor entidad)
        {
            vendedorDAL Insertar = new vendedorDAL();
            Insertar.InsertarVendedores(entidad);
        }

        public void EliminarVendedores(vendedor entidad)
        {
            vendedorDAL Eliminar = new vendedorDAL();
            Eliminar.Eliminarvendedor(entidad);
        }

        public void ActualizarVendedores(vendedor entidad)
        {
            vendedorDAL Actualizar = new vendedorDAL();
            Actualizar.Actualizarvendedor(entidad);
        }

        public DataTable BuscarVendedores(string parametro, string opcion)
        {
            vendedorDAL Buscar = new vendedorDAL();
            return Buscar.BuscarVendedores(parametro, opcion);
        
        }
    }
}
