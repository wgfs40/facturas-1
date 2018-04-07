using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using datos;
using System.Windows.Forms;
using System.Data;

namespace logica
{
   public class productoBL
    {

        public DataTable LlenarProductos()
        {
            productoDAL llenar = new productoDAL();
            return llenar.ObtenerProductos();
        }

        public void InsertarProductos(producto entidad)
        {
            productoDAL RegistrarProductos = new productoDAL();
            RegistrarProductos.InsertarProducto(entidad);
        }

        public void ActualizarProductos(producto entidad)
        {
            productoDAL ActualizarProductos = new productoDAL();
            ActualizarProductos.ActualizarProducto(entidad);
        }

        public void EliminarProductos(producto entidad)
        {
            productoDAL EliminarProductos = new productoDAL();
            EliminarProductos.Eliminarproducto(entidad);
        }

        public DataTable BuscarProductos(string param, string opcion)
        {
            productoDAL Buscar = new productoDAL();
            return Buscar.Buscarproducto(param, opcion);
        }

        public bool ComprobarForanea(int ID_PROVEEDOR)
        {
            return new productoDAL().ComprobarForanea(ID_PROVEEDOR);
        }
    }
}
