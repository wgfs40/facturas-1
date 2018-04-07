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
            Conexion.Open();
            return Conexion;
        }

        public void CerrarConexion()
        {
            Conexion.Close();
            Conexion.Dispose();
        }
    }
}
