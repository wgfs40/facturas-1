using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;


namespace datos
{
   public class acceso
    {// Clase de acceso a datos.

        #region "Variables (Clases) de Conexion"
        private SqlConnection Conexion;
        #endregion

        //Constructor
        public acceso()
        {
            Conexion = new SqlConnection(CadenaConexion);
            
        }
        private string CadenaConexion
        {
            get
            {
                return @"Data Source=DESKTOP-6IMEUUJ;Initial Catalog=SISTEMAFACTURAS;Integrated Security=True";
                //@"Data Source=DESKTOP-H16CF5S\SQLEXPRESS;Initial Catalog=&quot;SISTEMA FACTURAS&quot;;Integrated Security=True";
            }

        }

        public SqlConnection ObtenerConexion()
        {
            if (Conexion.State == System.Data.ConnectionState.Closed)
            {
                Conexion.ConnectionString = CadenaConexion;
                Conexion.Open();
            }
           
            return Conexion;
        }

        public void IniciarTransaction()
        {
            if (Conexion.State == System.Data.ConnectionState.Open)
            {               
                Transaction = Conexion.BeginTransaction();
            }
            else
            {
                if (Conexion.State == System.Data.ConnectionState.Closed)
                {
                    Conexion.Open();
                    Transaction = Conexion.BeginTransaction();
                }
            }
        }

        public void ConfirmarTrasaccion()
        {
            if (Transaction != null)
            {
                Transaction.Commit();
            }
        }

        public void DevolverTransaccion()
        {
            if (Transaction != null)
            {
                Transaction.Rollback();
            }
        }

        public void CerrarConexion()
        {
            Conexion.Close();
            Conexion.Dispose();
        }

        public SqlTransaction Transaction { get; private set; }
    }
}
