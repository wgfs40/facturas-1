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
         
           
            string Query = "INSERT INTO VENDEDOR VALUES (@NombVendedor," +
                           "@Comision)"; 


            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.CommandText = Query;
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandType = CommandType.Text;

                try
                {                    
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
                    AccesoDatos.CerrarConexion();
                }
            }

        }

        public void Eliminarvendedor(vendedor vendedor)
        {

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
                    AccesoDatos.CerrarConexion();
                }
            }

        }

        public void Actualizarvendedor(vendedor vendedor)
        {
                      

            string Query = "UPDATE VENDEDOR SET NOMB_VENDEDOR =@NombVendedor," +
                            "COMISION = @Comision " +
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
                catch (Exception ex)
                {

                    throw;
                }

                finally
                {
                        AccesoDatos.CerrarConexion();
                }
            }
        }

        public DataTable BuscarVendedores(string parametro, string opcion)
        {
          
            string Query = string.Empty;

            
           using (ComandoSQL = new SqlCommand())
            {
                if (opcion.Equals("Id"))
                {
                    Query = "SELECT * FROM VENDEDOR WHERE ID_VENDEDOR = @param";
                    ComandoSQL.Parameters.AddWithValue("@param",parametro);
                }
                else if (opcion.Equals("Nombre"))
                {
                    Query = "SELECT * FROM VENDEDOR WHERE NOMB_VENDEDOR LIKE @param";
                    ComandoSQL.Parameters.AddWithValue("@param","%"+parametro+"%");
                }

                ComandoSQL.CommandText = Query;
                ComandoSQL.CommandType = CommandType.Text;
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
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

                return Dt;
            }
        }

        public vendedor ComprobarForanea(int ID_VENDEDOR)
        {
            vendedor v = new vendedor();           

            string Query = "SELECT ID_VENDEDOR,NOMB_VENDEDOR,COMISION FROM VENDEDOR WHERE ID_VENDEDOR= @IdVendedor";


            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.CommandText = Query;
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandType = CommandType.Text;

                try
                {
                    ComandoSQL.Parameters.AddWithValue("@IdVendedor",ID_VENDEDOR);

                    using (var lector = ComandoSQL.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (lector.Read())
                        {
                            v.ID_VENDEDOR = lector.GetInt32(0);
                            v.NOMB_VENDEDOR = lector.GetString(1);
                            v.COMISION = (float)Convert.ToDouble(2);
                        }

                        return v;
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
        }
    }
}
