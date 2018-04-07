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
            string query = "Select * From PRODUCTO";
            using (AdaptadorSQL = new SqlDataAdapter(query, AccesoDatos.ObtenerConexion()))
            {
                Dt = new DataTable();

                AdaptadorSQL.Fill(Dt);

            }
            return Dt;
        }

        public void InsertarProducto(producto producto)
        {
            AccesoDatos.ObtenerConexion().Open();
            string Query = "INSERT INTO PRODUCTO VALUES(@IdProducto,@DescProducto,@IdProveedor,@Costo,@Precio)";

            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                //ComandoSQL.CommandType = CommandType.StoredProcedure;
                ComandoSQL.CommandText = Query;
                try
                {
                    ComandoSQL.Parameters.AddWithValue("@IdProducto", producto.ID_PRODUCTO);
                    ComandoSQL.Parameters.AddWithValue("@DescProducto", producto.DESC_PRODUCTO);
                    ComandoSQL.Parameters.AddWithValue("@IdProveedor", producto.ID_PROVEEDOR);
                    ComandoSQL.Parameters.AddWithValue("@Costo", producto.COSTO);
                    ComandoSQL.Parameters.AddWithValue("@Precio", producto.PRECIO);
                    

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

        public void Actualizarproducto(producto producto)
        {

            AccesoDatos.ObtenerConexion().Open();

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

                    throw;
                }

                finally
                {
                    AccesoDatos.ObtenerConexion().Close();
                }
            }
        }

        public void Eliminarproducto (producto productos)
        {

            AccesoDatos.ObtenerConexion().Open();

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

                    throw;
                }

                finally
                {
                    AccesoDatos.ObtenerConexion().Close();
                }
            }

        }

        public DataTable BuscarProductos(string param, string opcion)
        {
            string query = string.Empty;

            if (opcion.Equals("Descripcion"))
            {
                query = "SELECT * FROM PRODUCTO WHERE DESC_PRODUCTO LIKE @PARAM";
            }
            else
            {
                query = "SELECT * FROM PRODUCTO WHERE ID_PROVEEDOR LIKE @PARAM";
            }
            AccesoDatos.ObtenerConexion().Open();
            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.Connection =  AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandText = query;
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
                    AccesoDatos.ObtenerConexion().Close();
                }
            }
            return valor;

        }

        public void ActualizarProducto(producto entidad)
        {
            throw new NotImplementedException();
        }

        public DataTable Buscarproducto(string param, string opcion)
        {
            throw new NotImplementedException();
        }
    }
}
