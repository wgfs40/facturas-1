using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidades;
using datos;


namespace logica
{
    public class clienteBL
    {
        public DataTable LlenarClientes()
        {
            clienteDAL cli = new clienteDAL();

            return cli.ObtenerClientes();
        }

        public void RegClientes(cliente entidad)
        {
            clienteDAL RegistroCliente = new clienteDAL();

            RegistroCliente.InsertarClientes(entidad);

        }

        public void EliminarClientes(cliente entidad)
        {
            clienteDAL EliminacionCliente = new clienteDAL();

            EliminacionCliente.EliminarClientes(entidad);
        }

        public void ActualizarClientes(cliente entidad)
        {
            clienteDAL ActualizacionCliente = new clienteDAL();

            ActualizacionCliente.ActualizarClientes(entidad);

        }

        public DataTable BusquedaClientes(string parametro, string opcion)
        {
            clienteDAL BusquedaCliente = new clienteDAL();

            return BusquedaCliente.BusquedaClientes(parametro, opcion);
        }

    }
}
