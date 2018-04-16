using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Entidades;

namespace datos
{
    public class proveedorDAL
    {
        #region "Variables (Clases) de conexión"
        private SqlCommand ComandoSQL;
        private SqlDataAdapter AdaptadorSQL;
        private DataTable Dt;
        #endregion

        //Clase de Acceso a los datos
        private acceso AccesoDatos;

        // Constructor
        public proveedorDAL()
        {
            AccesoDatos = new acceso();
        }

        public DataTable Obtenerproveedor()
        {
            string query = "Select ID_PROVEEDOR,NOMB_PROVEEDOR,DIRECCION,PAIS From PROVEEDOR";
            using (AdaptadorSQL = new SqlDataAdapter(query, AccesoDatos.ObtenerConexion()))
            {
                Dt = new DataTable();

                AdaptadorSQL.Fill(Dt);

            }
            return Dt;
        }

        public void Insertarproveedor(proveedor proveedor)
        {
            //verificamos si hay una transaccion
            if (AccesoDatos.Transaction != null)
            {
                ComandoSQL.Transaction = AccesoDatos.Transaction;
            }

            string Query = "INSERT INTO PROVEEDOR VALUES(@NombProveedor,@Direcciom,@Pais)";

            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
               // ComandoSQL.CommandType = CommandType.StoredProcedure;
                ComandoSQL.CommandText = Query;
                try
                {
                   
                    ComandoSQL.Parameters.AddWithValue("@NombProveedor", proveedor.NOMB_PROVEEDOR);
                    ComandoSQL.Parameters.AddWithValue("@Direcciom", proveedor.DIRECCION);
                    ComandoSQL.Parameters.AddWithValue("@PAIS", proveedor.PAIS);
               


                    //Ejecutar Comando
                    ComandoSQL.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    //verificamos si hay una transaccion
                    if (AccesoDatos.Transaction != null)
                    {
                        AccesoDatos.DevolverTransaccion();
                    }

                    throw;

                }
                finally
                {
                    AccesoDatos.CerrarConexion();
                }
            }

        }

        public void Actualizarproveedor(proveedor proveedor)
        {
            //verificamos si hay una transaccion
            if (AccesoDatos.Transaction != null)
            {
                ComandoSQL.Transaction = AccesoDatos.Transaction;
            }

            string Query = "UPDATE PROVEEDOR SET NOMB_PROVEEDOR= @NombProveedor," +
                            "DIRECCION = @Direcciom," +
                            "PAIS= @Pais " +
                            "WHERE ID_PROVEEDOR =@IdProveedor";


            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.CommandText = Query;
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandType = CommandType.Text;

                try
                {
                    ComandoSQL.Parameters.AddWithValue("@IdProveedor", proveedor.ID_PROVEEDOR);
                    ComandoSQL.Parameters.AddWithValue("@NombProveedor", proveedor.NOMB_PROVEEDOR);
                    ComandoSQL.Parameters.AddWithValue("@Direcciom", proveedor.DIRECCION);
                    ComandoSQL.Parameters.AddWithValue("@PAIS", proveedor.PAIS);

                    ComandoSQL.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    //verificamos si hay una transaccion
                    if (AccesoDatos.Transaction != null)
                    {
                        AccesoDatos.DevolverTransaccion();
                    }
                    throw;
                }

                finally
                {
                    AccesoDatos.CerrarConexion();
                }
            }
        }

        public void EliminarPROVEEDOR(proveedor proveedor)
        {
            //verificamos si hay una transaccion
            if (AccesoDatos.Transaction != null)
            {
                ComandoSQL.Transaction = AccesoDatos.Transaction;
            }

            string Query = "DELETE FROM PROVEEDOR WHERE ID_PROVEEDOR = @IdProveedor";


            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.CommandText = Query;
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandType = CommandType.Text;

                try
                {
                    ComandoSQL.Parameters.AddWithValue("@IdProveedor", proveedor.ID_PROVEEDOR);
                    ComandoSQL.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    //verificamos si hay una transaccion
                    if (AccesoDatos.Transaction != null)
                    {
                        AccesoDatos.DevolverTransaccion();
                    }
                    throw;
                }

                finally
                {
                    AccesoDatos.CerrarConexion();
                }
            }

        }

        public DataTable Buscarproveedor(string param,string option)
        {
            string query = string.Empty;
            if (option.Equals("NOMB_PROVEEDOR"))
            {
                query = "SELECT * FROM PROVEEDOR WHERE NOMB_PROVEEDOR LIKE @IdProveedor";
            }
            else
            {
                query = "SELECT * FROM  PROVEEDOR WHERE PAIS LIKE @IdProveedor";
            }
           
            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.CommandText = query;
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.Parameters.AddWithValue("@IdProveedor", "%" + param + "%");
                try
                {
                    using (AdaptadorSQL = new SqlDataAdapter())
                    {
                        AdaptadorSQL.SelectCommand = ComandoSQL;
                        Dt = new DataTable();

                        AdaptadorSQL.Fill(Dt);

                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {

                    AccesoDatos.CerrarConexion();
                }
            }
            return Dt;

        }

        public proveedor BuscarProveedorPorId(int codigo)
        {
            string query = string.Empty;
        
            query = "SELECT * FROM  PROVEEDOR WHERE ID_PROVEEDOR = @IdProveedor";
       
            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.CommandText = query;
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.Parameters.AddWithValue("@IdProveedor", codigo);

                proveedor p = new proveedor();
                try
                {
                    using (var lector = ComandoSQL.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (lector.Read())
                        {
                            p.ID_PROVEEDOR = lector.GetInt32(0);
                            p.NOMB_PROVEEDOR = lector.GetString(1);                           
                            p.DIRECCION = lector.GetString(2);
                            p.PAIS = lector.GetString(3);
                        }
                    }

                    return p;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {

                    AccesoDatos.CerrarConexion();
                }
            }
           
        }
    }
}
