using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace datos
{
   public class vendedorDAL
    { 
       #region "Variables (Clases) de conexión"
        private SqlCommand ComandoSQL;
        private SqlDataAdapter AdaptadorSQL;
        private DataTable Dt;
        #endregion

        //Clase de Acceso a los datos
        private acceso AccesoDatos;

        // Constructor 
        public vendedorDAL()
        {
            AccesoDatos = new acceso();
        }

        public DataTable Obtenervendedor()
        {
      

            using (AdaptadorSQL = new SqlDataAdapter("SELECT * FROM VENDEDOR",AccesoDatos.ObtenerConexion()))
            {
                Dt = new DataTable();
                AdaptadorSQL.Fill(Dt);
            }
            return Dt;
        }

        public void InsertarVendedores(vendedor vendedor)
        {
         
            AccesoDatos.ObtenerConexion().Open();

            string Query = "INSERT INTO VENDEDOR VALUES (@IdVendedor ,@NombVendedor," +
                           "@Comision)"; 


            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.CommandText = Query;
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandType = CommandType.Text;

                try
                {
                    ComandoSQL.Parameters.AddWithValue("@IdVendedor", vendedor.ID_VENDEDOR);
                    ComandoSQL.Parameters.AddWithValue("@NombVendedor", vendedor.NOMB_VENDEDOR);
                    ComandoSQL.Parameters.AddWithValue("@Comision", vendedor.COMISION);
                   
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

        public void Eliminarvendedor(vendedor vendedor)
        {

            AccesoDatos.ObtenerConexion().Open();

            string Query = "DELETE FROM VENDEDOR WHERE ID_VENDEDOR = @IdVendedor";


            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.CommandText = Query;
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandType = CommandType.Text;

                try
                {
                    ComandoSQL.Parameters.AddWithValue("@IdVendedor", vendedor.ID_VENDEDOR);
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

        public void Actualizarvendedor(vendedor vendedor)
        {
           
            AccesoDatos.ObtenerConexion().Open();

            string Query = "UPDATE VENDEDOR SET NOMB_VENDEDOR =@NombVendedor," +
                            "COMISION = @Comision," +
                            "WHERE ID_VENDEDOR = @IdVendedor";


            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.CommandText = Query;
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandType = CommandType.Text;

                try
                {
                    ComandoSQL.Parameters.AddWithValue("@IdVendedor", vendedor.ID_VENDEDOR);
                    ComandoSQL.Parameters.AddWithValue("@NombVendedor", vendedor.NOMB_VENDEDOR);
                    ComandoSQL.Parameters.AddWithValue("@Comision", vendedor.COMISION);

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

        public DataTable BuscarVendedores(string parametro, string opcion)
        {
          
            AccesoDatos.ObtenerConexion().Open();
            string Query = string.Empty;

            if (opcion.Equals("@IdVendedor"))
            {
                Query = "SELECT * FROM VENDEDOR WHERE ID_VENDEDOR = @param";
            }
            else if (opcion.Equals("Nombre"))
            {
                Query = "SELECT * FROM VENDEDOR WHERE NOMB_VENDEDOR = @param";
                
            
            }
          
           using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.CommandText = Query;
                ComandoSQL.CommandType = CommandType.Text;
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                try
                {
                    ComandoSQL.Parameters.AddWithValue("@param", parametro);

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

                return Dt;
            }
        }

        public bool ComprobarForanea(int ID_VENDEDOR)
        {
            bool valor = false;
            AccesoDatos.ObtenerConexion().Open();

            string Query = "SELECT ID_VENDEDOR FROM VENDEDOR WHERE ID_VENDEDOR= @IdVendedor";


            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.CommandText = Query;
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandType = CommandType.Text;

                try
                {
                    ComandoSQL.Parameters.AddWithValue("@IdVendedor",ID_VENDEDOR);

                    if (ComandoSQL.ExecuteScalar() != null)
                        valor = true;
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
            return valor;

        }
    }
}
