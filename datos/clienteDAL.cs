using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace datos
{
    public class clienteDAL
    {
        #region "Variables (Clases) de conexión"
        private SqlCommand ComandoSQL;
        private SqlDataAdapter AdaptadorSQL;
        private DataTable Dt;
        #endregion

        //Clase de Acceso a los datos
        private acceso AccesoDatos;

        // Constructor
        public clienteDAL()
        {
            AccesoDatos = new acceso();
        }

        public DataTable ObtenerClientes()
        {
            string query = "Select * From cliente";
            using (AdaptadorSQL = new SqlDataAdapter(query, AccesoDatos.ObtenerConexion()))
            {
                Dt = new DataTable();

                AdaptadorSQL.Fill(Dt);

            }
            return Dt;
        }

        public void InsertarClientes(cliente cliente)
        {           
            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandType = CommandType.StoredProcedure;
                ComandoSQL.CommandText = "proc_CLIENTEInsert";
                try
                {
                    //ComandoSQL.Parameters.AddWithValue("@IdCliente", cliente.ID_CLIENTE);
                    ComandoSQL.Parameters.AddWithValue("@NombCliente", cliente.NOMB_CLIENTE);
                    ComandoSQL.Parameters.AddWithValue("@Direccion", cliente.DIRECCION);
                    ComandoSQL.Parameters.AddWithValue("@Pais", cliente.PAIS);
                    ComandoSQL.Parameters.AddWithValue("@SaldoIni", cliente.SALDO_INI);
                    ComandoSQL.Parameters.AddWithValue("@SaldoFinal", cliente.SALDO_FINAL);

                    //Ejecutar Comando
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

        public void EliminarClientes(int clienteid)
        {
           
            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandType = CommandType.Text;
                ComandoSQL.CommandText = "DELETE FROM CLIENTE WHERE ID_CLIENTE = @IdCliente";
                try
                {
                    ComandoSQL.Parameters.AddWithValue("@IdCliente", clienteid);
                  

                    //Ejecutar Comando
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

        public void ActualizarClientes(cliente cliente)
        {
            string query = "UPDATE CLIENTE SET NOMB_CLIENTE =@NombCliente," +
                           "DIRECCION =@Direccion, PAIS = @Pais," +
                           "SALDO_INI = @SaldoIni," +
                           "SALDO_FINAL = @SaldoFinal WHERE ID_CLIENTE = @IdCliente";

            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandType = CommandType.Text;
                ComandoSQL.CommandText = query;
                try
                {
                    ComandoSQL.Parameters.AddWithValue("@IdCliente", cliente.ID_CLIENTE);
                    ComandoSQL.Parameters.AddWithValue("@NombCliente", cliente.NOMB_CLIENTE);
                    ComandoSQL.Parameters.AddWithValue("@Direccion", cliente.DIRECCION);
                    ComandoSQL.Parameters.AddWithValue("@Pais", cliente.PAIS);
                    ComandoSQL.Parameters.AddWithValue("@SaldoIni", cliente.SALDO_INI);
                    ComandoSQL.Parameters.AddWithValue("@SaldoFinal", cliente.SALDO_FINAL);

                    //Ejecutar Comando
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

        public DataTable BusquedaClientes(string parametro, string opcion)
        {           
            string query = string.Empty;

            if (opcion.Equals("Nombre"))
            {
                query = "SELECT * FROM CLIENTE WHERE NOMB_CLIENTE LIKE @param";
            }
            else if (opcion.Equals("Pais"))
            {
                query = "SELECT * FROM CLIENTE WHERE PAIS LIKE @param";
            }

            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandText = query;
                ComandoSQL.CommandType = CommandType.Text;
                
                try
                {
                    ComandoSQL.Parameters.AddWithValue("@param", "%" + parametro + "%");
                   

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

        public bool ComprobarForanea(int id_jefe)
        {
            bool valor = false;          

            string Query = "SELECT ID_JEFE FROM VENDEDOR WHERE ID_JEFE = @ID";


            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.CommandText = Query;
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandType = CommandType.Text;

                try
                {
                    ComandoSQL.Parameters.AddWithValue("@ID", id_jefe);

                    if (ComandoSQL.ExecuteScalar() != null)
                        valor = true;
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
            return valor;

        }

        public cliente ObtenerClientePorID(int clienteid)
        {
            try
            {
                cliente cliente = new cliente();               
                ComandoSQL = new SqlCommand();
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandText = "proc_CLIENTELoadByPrimaryKey";
                ComandoSQL.CommandType = CommandType.StoredProcedure;

                ComandoSQL.Parameters.AddWithValue("@IdCliente", clienteid);

                using (var lector = ComandoSQL.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (lector.Read())
                    {
                        cliente.ID_CLIENTE = lector.GetInt32(0);
                        cliente.NOMB_CLIENTE = lector.GetString(1);
                        cliente.DIRECCION = lector.GetString(2);
                        cliente.PAIS = lector.GetString(3);
                        cliente.SALDO_INI = (float)Convert.ToDouble(lector["SALDO_INI"]);
                        cliente.SALDO_FINAL =(float)Convert.ToDouble(lector["SALDO_FINAL"]);
                    }

                }


                return cliente;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error en el acceso a datos: " + ex.Message);

            }
            finally
            {
                AccesoDatos.CerrarConexion();
            }

        }
    }
}
