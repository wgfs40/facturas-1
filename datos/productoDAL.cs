using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Entidades;


namespace datos
{
   public class productoDAL
    {
        #region "Variables (Clases) de conexión"
        private SqlCommand ComandoSQL;
        private SqlDataAdapter AdaptadorSQL;
        private DataTable Dt;
        #endregion

        //Clase de Acceso a los datos
        private acceso AccesoDatos;

        // Constructor
        public productoDAL()
        {
            AccesoDatos = new acceso();
        }

        public DataTable ObtenerProductos()
        {
            string query = "select p.ID_PRODUCTO,p.DESC_PRODUCTO,pr.NOMB_PROVEEDOR,p.COSTO,p.PRECIO from PRODUCTO p " +
                        "inner join PROVEEDOR pr on p.ID_PROVEEDOR = pr.ID_PROVEEDOR";
            using (AdaptadorSQL = new SqlDataAdapter(query, AccesoDatos.ObtenerConexion()))
            {
                Dt = new DataTable();

                AdaptadorSQL.Fill(Dt);

            }
            return Dt;
        }

        public void InsertarProducto(producto producto)
        {
            //verificamos si hay una transaccion
            if (AccesoDatos.Transaction != null)
            {
                ComandoSQL.Transaction = AccesoDatos.Transaction;
            }
            string Query = "INSERT INTO PRODUCTO VALUES(@DescProducto,@IdProveedor,@Costo,@Precio)";

            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                //ComandoSQL.CommandType = CommandType.StoredProcedure;
                ComandoSQL.CommandText = Query;
                try
                {                  
                    ComandoSQL.Parameters.AddWithValue("@DescProducto", producto.DESC_PRODUCTO);
                    ComandoSQL.Parameters.AddWithValue("@IdProveedor", producto.ID_PROVEEDOR);
                    ComandoSQL.Parameters.AddWithValue("@Costo", producto.COSTO);
                    ComandoSQL.Parameters.AddWithValue("@Precio", producto.PRECIO);
                    

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

        public void Actualizarproducto(producto producto)
        {

            //verificamos si hay una transaccion
            if (AccesoDatos.Transaction != null)
            {
                ComandoSQL.Transaction = AccesoDatos.Transaction;
            }

            string Query = "UPDATE PRODUCTO SET DESC_PRODUCTO =@DescProducto," +
                            "ID_PROVEEDOR = @IdProveedor," +
                            "COSTO = @Costo," +
                            "PRECIO = @Precio " +
                            "WHERE ID_PRODUCTO = @IdProducto";


            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.CommandText = Query;
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandType = CommandType.Text;

                try
                {
                    ComandoSQL.Parameters.AddWithValue("@IdProducto", producto.ID_PRODUCTO);
                    ComandoSQL.Parameters.AddWithValue("@DescProducto", producto.DESC_PRODUCTO);
                    ComandoSQL.Parameters.AddWithValue("@IdProveedor", producto.ID_PROVEEDOR);
                    ComandoSQL.Parameters.AddWithValue("@Costo", producto.COSTO);
                    ComandoSQL.Parameters.AddWithValue("@Precio", producto.PRECIO);

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

        public void Eliminarproducto (producto productos)
        {
            //verificamos si hay una transaccion
            if (AccesoDatos.Transaction != null)
            {
                ComandoSQL.Transaction = AccesoDatos.Transaction;
            }

            string Query = "DELETE FROM PRODUCTO WHERE ID_PRODUCTO =@IdProducto";


            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.CommandText = Query;
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandType = CommandType.Text;

                try
                {
                    ComandoSQL.Parameters.AddWithValue("@IdProducto", productos.ID_PRODUCTO);
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

        public DataTable BuscarProductos(string param, string opcion)
        {
            string query = string.Empty;
            using (ComandoSQL = new SqlCommand())
            {
                if (opcion.Equals("Descripcion"))
                {
                    query = "select p.ID_PRODUCTO,p.DESC_PRODUCTO,pr.NOMB_PROVEEDOR,p.COSTO,p.PRECIO from PRODUCTO p " +
                            "inner join PROVEEDOR pr on p.ID_PROVEEDOR = pr.ID_PROVEEDOR WHERE p.DESC_PRODUCTO LIKE @PARAM";
                    ComandoSQL.Parameters.AddWithValue("@PARAM", "%" + param + "%");
                }
                else
                {
                    query = "select p.ID_PRODUCTO,p.DESC_PRODUCTO,pr.NOMB_PROVEEDOR,p.COSTO,p.PRECIO from PRODUCTO p " +
                            "inner join PROVEEDOR pr on p.ID_PROVEEDOR = pr.ID_PROVEEDOR WHERE p.ID_PRODUCTO in(@PARAM)";
                    ComandoSQL.Parameters.AddWithValue("@PARAM",int.Parse(param));
                }

                ComandoSQL.Connection =  AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandText = query;
               
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

        public bool ComprobarForanea(int ID_PROVEEDOR)
        {
            bool valor = false;
            AccesoDatos.ObtenerConexion().Open();

            string Query = "SELECT ID_PROVEEDOR FROM PROVEEDOR WHERE ID_PROVEEDOR =@IdProveedor";


            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.CommandText = Query;
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandType = CommandType.Text;

                try
                {
                    ComandoSQL.Parameters.AddWithValue("@IdProveedor", ID_PROVEEDOR);

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

        public producto ObtenerproductoPorId(int productoid)
        {
            string query = "SELECT * FROM PRODUCTO WHERE ID_PRODUCTO =@IdProducto";
            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.CommandText = query;
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandType = CommandType.Text;
                ComandoSQL.Parameters.AddWithValue("@IdProducto", productoid);
               
                try
                {
                    producto p = new producto();
                    using (var lector = ComandoSQL.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (lector.Read())
                        {
                            p = new producto {
                                ID_PRODUCTO = lector.GetInt32(0),
                                DESC_PRODUCTO = lector.GetString(1),
                                ID_PROVEEDOR = lector.GetInt32(2),
                                COSTO = (float)Convert.ToDouble(lector[3]),
                                PRECIO = (float)Convert.ToDouble(lector[4]),
                            };
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
