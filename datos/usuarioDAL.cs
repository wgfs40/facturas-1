using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace datos
{
    public class usuarioDAL
    {
        #region "Variables (Clases) de conexión"
        private SqlCommand ComandoSQL;
        private SqlDataAdapter AdaptadorSQL;
        private DataTable Dt;
        #endregion

        //Clase de Acceso a los datos
        private acceso AccesoDatos;

        public usuarioDAL()
        {
            AccesoDatos = new acceso();
        }

        public void InsertarUsuario(usuario usuario)
        {
            AccesoDatos.ObtenerConexion().Open();
            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandType = CommandType.StoredProcedure;
                ComandoSQL.CommandText = "proc_CREARUSUARIO";
                try
                {
                    ComandoSQL.Parameters.AddWithValue("@nombreusuario", usuario.Usuario);
                    ComandoSQL.Parameters.AddWithValue("@clave", usuario.Clave);
                    ComandoSQL.Parameters.AddWithValue("@estatus", "A");

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

        public void ActualizarUsuario(usuario usuario)
        {
            AccesoDatos.ObtenerConexion().Open();
            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandType = CommandType.StoredProcedure;
                ComandoSQL.CommandText = "proc_ACTUALIZARUAURIO";
                try
                {
                    ComandoSQL.Parameters.AddWithValue("@usuarioid", usuario.UsuarioId);
                    ComandoSQL.Parameters.AddWithValue("@nombreusuario", usuario.Usuario);
                    ComandoSQL.Parameters.AddWithValue("@clave", usuario.Clave);

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

        public bool ValidarUsuario(string nombreusuario, string clave)
        {
            AccesoDatos.ObtenerConexion().Open();
            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandType = CommandType.StoredProcedure;
                ComandoSQL.CommandText = "UspValidarUsuario";
                try
                {
                    
                    ComandoSQL.Parameters.AddWithValue("@usu", nombreusuario);
                    ComandoSQL.Parameters.AddWithValue("@cla", clave);

                    using (SqlDataReader reader = ComandoSQL.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw;

                }
                finally
                {
                    AccesoDatos.ObtenerConexion().Close();
                }
            }
        }

        public DataTable ListaUsuario(string busqueda)
        {
            string sql = "select usuarioid,usuario,estatus from usuario where usuario like '%"+busqueda+"%'";
            using ( AdaptadorSQL = new SqlDataAdapter(sql,AccesoDatos.ObtenerConexion()))
            {
                Dt = new DataTable();
                AdaptadorSQL.Fill(Dt);
            }
            return Dt;
        }

        public usuario ObtenerUsuario(int usuarioid)
        {
            try
            {
                usuario usuario = new usuario();
                string sql = "select usuarioid,usuario,estatus from usuario where usuarioid = @usuid";
                ComandoSQL = new SqlCommand();
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandText = sql;
                ComandoSQL.CommandType = CommandType.Text;

                ComandoSQL.Parameters.AddWithValue("@usuid", usuarioid);

                using (var lector = ComandoSQL.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (lector.Read())
                    {
                        usuario.UsuarioId = lector.GetInt32(0);
                        usuario.Usuario = lector.GetString(1);
                        usuario.Estatus = lector.GetString(2);
                    }

                }


                return usuario;
            }
            catch (Exception ex)
            {


            }
            finally {
                
            }
           


        }
    }
}
