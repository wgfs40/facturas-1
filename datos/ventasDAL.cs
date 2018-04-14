using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace datos
{
    public class ventasDAL
    {
        

        #region "Variables (Clases) de conexión"
        private SqlCommand ComandoSQL;
        private SqlDataAdapter AdaptadorSQL;
        private DataTable Dt;
        #endregion

        //Clase de Acceso a los datos
        private acceso AccesoDatos;

        // Constructor
        public ventasDAL()
        {
            AccesoDatos = new acceso();
        }

        public DataTable ObtenerVentas()
        {
            string query = "Select * From  ventas";
            using (AdaptadorSQL = new SqlDataAdapter(query, AccesoDatos.ObtenerConexion()))
            {
                Dt = new DataTable();
                AdaptadorSQL.Fill(Dt);

            }
            return Dt;
        }

        public void InsertarVentas(ventas ventas)
        {
            AccesoDatos.ObtenerConexion().Open();
            string Query = "INSERT INTO VENTAS VALUES (@fecha,@idcliente,@idvendedor,@idproducto,@cantidad)";

            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                //ComandoSQL.CommandType = CommandType.StoredProcedure;
                ComandoSQL.CommandText = Query;
                try
                {
                    ComandoSQL.Parameters.AddWithValue("@fecha", Convert.ToDateTime(ventas.FECHA.ToShortDateString()));
                    ComandoSQL.Parameters.AddWithValue("@idcliente", ventas.ID_CLIENTE);
                    ComandoSQL.Parameters.AddWithValue("@idvendedor", ventas.ID_VENDEDOR);
                    ComandoSQL.Parameters.AddWithValue("@idproducto", ventas.ID_PRODUCTO);
                    ComandoSQL.Parameters.AddWithValue("@cantidad", ventas.Cantidad);


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

        public void ActualizarVentas(ventas ventas,int param)
        {
            AccesoDatos.ObtenerConexion().Open();
            string Query = "UPDATE VENTAS SET FECHA = @fecha, ID_CLIENTE=@idcliente, ID_VENDEDOR=@idvendedor, ID_PROD = @idproducto, CANTIDAD = @cantidad"
                + "WHERE ID_CLIENTE = @idcliente";

            using (ComandoSQL = new SqlCommand()) 
            {
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                //ComandoSQL.CommandType = CommandType.StoredProcedure;
                ComandoSQL.CommandText = Query;
                try
                {
                    ComandoSQL.Parameters.AddWithValue("@idcliente", param);
                    ComandoSQL.Parameters.AddWithValue("@fecha", Convert.ToDateTime(ventas.FECHA.ToShortDateString()));
                    ComandoSQL.Parameters.AddWithValue("@idcliente", ventas.ID_CLIENTE);
                    ComandoSQL.Parameters.AddWithValue("@idvendedor", ventas.ID_VENDEDOR);
                    ComandoSQL.Parameters.AddWithValue("@idproducto", ventas.ID_PRODUCTO);
                    ComandoSQL.Parameters.AddWithValue("@cantidad", ventas.Cantidad);


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

        public void EliminarVentas(ventas ventas)
        {
            AccesoDatos.ObtenerConexion().Open();

            string Query = "DELETE FROM VENTAS WHERE ID_CLIENTE = @idcliente";


            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.CommandText = Query;
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandType = CommandType.Text;

                try
                {
                    ComandoSQL.Parameters.AddWithValue("@idcliente", ventas.ID_CLIENTE);
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

        public DataTable BuscarVentas(string param, string opcion)
        {
            AccesoDatos.ObtenerConexion().Open();
            string Query = string.Empty;

            if (opcion.Equals("IDCli"))
            {
                Query = "SELECT * FROM VENTAS WHERE ID_CLIENTE LIKE @PARAM";
            }
            else if (opcion.Equals("ID_PRODUCTO"))
            {
                Query = "SELECT * FROM VENTAS WHERE ID_PRODUCTO LIKE @PARAM";
            }
            else if (opcion.Equals("ID_VENDEDOR"))
            {
                Query = "SELECT * FROM VENTAS WHERE ID_VENDEDOR LIKE @PARAM";
            }

            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandText = Query;
                ComandoSQL.Parameters.AddWithValue("@PARAM", "%" + param + "%");
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

                return Dt;

            }
        }
        public DataTable ObtenerVentasClientes()
        {
            string query = "Select FECHA,CANTIDAD,C.NOMB_CLIENTE,C.ID_CLIENTE,V.NOMB_VENDEDOR,V.ID_VENDEDOR,P.DESC_PRODUCTO,P.ID_PRODUCTO, " +
            "P.DESC_PRODUCTO FROM VENTAS INNER JOIN CLIENTES C " +
            "ON VENTAS.ID_CLIENTE = C.ID_CLIENTE INNER JOIN VENDEDOR V ON VENTAS.ID_VENDEDOR = V.ID_VENDEDOR " +
            "INNER JOIN PRODUCTOS P ON VENTAS.ID_PROD = P.ID_PRODUCTO";
            using (AdaptadorSQL = new SqlDataAdapter(query, AccesoDatos.ObtenerConexion()))
            {
                Dt = new DataTable();

                AdaptadorSQL.Fill(Dt);

            }
            return Dt;
        }

    }
}
