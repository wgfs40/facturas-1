using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using System.Data;
using datos;


namespace logica
{
   public class proveedorBL
    {
        public DataTable Obtenerproveedor()
        {
            proveedorDAL Obtener = new proveedorDAL();

            return Obtener.Obtenerproveedor();
        }

        public void InsertarFabricantes(proveedor entidad)
        {
            proveedorDAL Insertar = new proveedorDAL();

            Insertar.Insertarproveedor(entidad);
        }

        public void Actualizarproveedor(proveedor entidad)
        {
            proveedorDAL Actualizar = new proveedorDAL();

            Actualizar.Actualizarproveedor(entidad);
        }

        public void EliminarPROVEEDOR(proveedor entidad)
        {
            proveedorDAL Eliminar = new proveedorDAL();

            Eliminar.EliminarPROVEEDOR(entidad);
        }

        public DataTable Buscarproveedor(string param, string option)
        {
            proveedorDAL Buscar = new proveedorDAL();

            return Buscar.Buscarproveedor(param, option);
        }
    }
}
