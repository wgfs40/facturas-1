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
            string query = "Select ID_PROVEEDOR,NOMB_PROVEEDOR,DIRECCIOM,PAIS From PROVEEDOR";
            using (AdaptadorSQL = new SqlDataAdapter(query, AccesoDatos.ObtenerConexion()))
            {
                Dt = new DataTable();

                AdaptadorSQL.Fill(Dt);

            }
            return Dt;
        }

        public void Insertarproveedor(proveedor proveedor)
        {
            AccesoDatos.ObtenerConexion().Open();
            string Query = "INSERT INTO PROVEEDOR VALUES(@IdProveedor,@NombProveedor,@Direcciom,@Pais)";

            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
               // ComandoSQL.CommandType = CommandType.StoredProcedure;
                ComandoSQL.CommandText = Query;
                try
                {
                    ComandoSQL.Parameters.AddWithValue("@IdProveedor", proveedor.ID_PROVEEDOR);
                    ComandoSQL.Parameters.AddWithValue("@NombProveedor", proveedor.NOMB_PROVEEDOR);
                    ComandoSQL.Parameters.AddWithValue("@Direcciom", proveedor.DIRECCIOM);
                    ComandoSQL.Parameters.AddWithValue("@PAIS", proveedor.PAIS);
               


                    //Ejecutar Comando
                    ComandoSQL.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;

                }
                finally
                {
                    AccesoDatos.ObtenerConexion().Close();
                }
            }

        }

        public void Actualizarproveedor(proveedor proveedor)
        {

            AccesoDatos.ObtenerConexion().Open();

            string Query = "UPDATE PROVEEDOR SET NOMB_PROVEEDOR= @NombProveedor," +
                            "DIRECCIOM = @Direcciom," +
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
                    ComandoSQL.Parameters.AddWithValue("@Direcciom", proveedor.DIRECCIOM);
                    ComandoSQL.Parameters.AddWithValue("@PAIS", proveedor.PAIS);

                    ComandoSQL.ExecuteNonQuery();
                }
                catch (Exception)
                {

                    throw;
                }

                finally
                {
                    AccesoDatos.ObtenerConexion().Close();
                }
            }
        }

        public void EliminarPROVEEDOR(proveedor proveedor)
        {

            AccesoDatos.ObtenerConexion().Open();

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

                    throw;
                }

                finally
                {
                    AccesoDatos.ObtenerConexion().Close();
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
            AccesoDatos.ObtenerConexion().Open();
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

                    AccesoDatos.ObtenerConexion().Close();
                }
            }
            return Dt;

        }
    }
}
