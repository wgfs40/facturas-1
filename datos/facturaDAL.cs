using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Entidades;

namespace datos
{
    public class facturaDAL
    {
        #region "Variables (Clases) de conexión"
        private SqlCommand ComandoSQL;
        private SqlDataAdapter AdaptadorSQL;
        private DataTable Dt;
        #endregion

        //Clase de Acceso a los datos
        private acceso AccesoDatos;

        // Constructor
        public facturaDAL()
        {
            AccesoDatos = new acceso();
        }
        public facturaDAL(acceso accesoDatos)
        {
            AccesoDatos = accesoDatos;
        }
        #region Metodos para factura
        public DataTable ObtenerVentas()
        {
            string query = "Select * From  factura";
            using (AdaptadorSQL = new SqlDataAdapter(query, AccesoDatos.ObtenerConexion()))
            {
                Dt = new DataTable();

                AdaptadorSQL.Fill(Dt);

            }
            return Dt;
        }

        public DataTable ObtenerVentas(int facturaid)
        {
            string query = "Select * From  vFactura where ID_FACTURAS = @facturaid";
            using (AdaptadorSQL = new SqlDataAdapter(query, AccesoDatos.ObtenerConexion()))
            {
                AdaptadorSQL.SelectCommand.Parameters.AddWithValue("@facturaid",facturaid);
                Dt = new DataTable();

                AdaptadorSQL.Fill(Dt);

            }
            return Dt;
        }

        public DataTable ObtenerDetalleFactura(int facturaid)
        {
            string query = "Select * From  vDetalleFactura where facturaid = @facturaid";
            using (AdaptadorSQL = new SqlDataAdapter(query, AccesoDatos.ObtenerConexion()))
            {
                AdaptadorSQL.SelectCommand.Parameters.AddWithValue("@facturaid", facturaid);
                Dt = new DataTable();

                AdaptadorSQL.Fill(Dt);

            }
            return Dt;
        }
        public int Insertarfactura(factura factura)
        {
           
            //AccesoDatos.IniciarTransaction();

            string Query = "proc_FACTURAInsert";

            using (ComandoSQL = new SqlCommand())
            {
                if (AccesoDatos.Transaction != null)
                {
                    ComandoSQL.Transaction = AccesoDatos.Transaction;
                }

                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandType = CommandType.StoredProcedure;
                ComandoSQL.CommandText = Query;
                try
                {                   
                    ComandoSQL.Parameters.AddWithValue("@IdCliente ", factura.ID_CLIENTE);                    
                    ComandoSQL.Parameters.AddWithValue("@IdVendedor", factura.ID_VENDEDOR);
                    ComandoSQL.Parameters.AddWithValue("@Saldoinicial", factura.SALDOINICIAL);
                    ComandoSQL.Parameters.AddWithValue("@SaldoFinal", factura.SALDOFINAL);

                    //Ejecutar Comando
                    var resultado = Convert.ToInt32(ComandoSQL.ExecuteScalar());

                    if (factura.FACTURADETALLE.Count > 0)
                    {
                        foreach (var item in factura.FACTURADETALLE)
                        {
                            item.FACTURAID = resultado;
                            InsetarDetalleFactura(item);
                        }
                    }

                    AccesoDatos.ConfirmarTrasaccion();
                    return resultado;
                }
                catch (Exception)
                {
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

        public void Actualizarfactura(factura factura, int param)
        {
            AccesoDatos.ObtenerConexion().Open();
            string Query = "UPDATE FACTURA SET ID_CLIENTE =@IdCliente, ID_PRODUCTO=@IdProducto, ID_VENDEDOR=@IdVendedor,SALDOINICIAL= @Saldoinicial, SALDO FINAL = @SaldoFinal "
                + "WHERE [ID_FACTURAS] = @IdFacturas";

            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                //ComandoSQL.CommandType = CommandType.StoredProcedure;
                ComandoSQL.CommandText = Query;
                try
                {
                    ComandoSQL.Parameters.AddWithValue("@idfactura", factura.ID_FACTURAS);
                    ComandoSQL.Parameters.AddWithValue("@IdCliente ", factura.ID_CLIENTE);
                    ComandoSQL.Parameters.AddWithValue("@IdProducto", factura.ID_PRODUCTO);
                    ComandoSQL.Parameters.AddWithValue("@IdVendedor", factura.ID_VENDEDOR);
                    ComandoSQL.Parameters.AddWithValue("@Saldoinicial", factura.SALDOINICIAL);
                    ComandoSQL.Parameters.AddWithValue("@SaldoFinal", factura.SALDOFINAL);


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

        public void Eliminarfactura(factura factura)
        {
            AccesoDatos.ObtenerConexion().Open();

            string Query = "DELETE FROM FACTURA WHERE [ID_FACTURAS] = @IdFacturas";


            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.CommandText = Query;
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandType = CommandType.Text;

                try
                {
                    ComandoSQL.Parameters.AddWithValue("@IdFacturas", factura.ID_FACTURAS);
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

        public DataTable Buscarfactura(string param, string opcion)
        {
            AccesoDatos.ObtenerConexion().Open();
            string Query = string.Empty;

            if (opcion.Equals("@IdFacturas"))
            {
                Query = "SELECT * FROM VENTAS WHERE ID_FACTURA LIKE @PARAM";
            }
            else if (opcion.Equals("@IdCliente"))
            {
                Query = "SELECT * FROM CLIENTE WHERE ID_CLIENTE LIKE @PARAM";
            }
            else if (opcion.Equals("@IdVendedor"))
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
        public DataTable ObtenerfacturaCliente()
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
        #endregion

        #region Metodos para Detalle de Factura
        private void InsetarDetalleFactura(facturadetalle detalle)
        {
            string Query = "proc_FACTURADETALLEINSERT";

            using (ComandoSQL = new SqlCommand())
            {
                if (AccesoDatos.Transaction != null)
                {
                    ComandoSQL.Transaction = AccesoDatos.Transaction;
                }

                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandType = CommandType.StoredProcedure;
                ComandoSQL.CommandText = Query;
                try
                {
                    ComandoSQL.Parameters.AddWithValue("@productoid", detalle.PRODUCTOID);
                    ComandoSQL.Parameters.AddWithValue("@facturaid", detalle.FACTURAID);
                    ComandoSQL.Parameters.AddWithValue("@cantidad", detalle.CANTIDAD);
                    ComandoSQL.Parameters.AddWithValue("@precio", detalle.PRECIO);
                    //Ejecutar Comando
                    var resultado = ComandoSQL.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                   
                    throw;

                }
            }
            #endregion
        }
    }
}