using ClassLibrary1;
using datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace logica
{
    public class usuarioBL
    {
        private usuarioDAL usuarioDAL = new usuarioDAL();

        public void InsertarUsuario(usuario usuario)
        {
            usuarioDAL.InsertarUsuario(usuario);
        }

        public void ActualizarUsuario(usuario usuario)
        {
            usuarioDAL.ActualizarUsuario(usuario);
        }

        public DataTable ListarUsuario(string busqueda)
        {
            return usuarioDAL.ListaUsuario(busqueda);
        }

        public bool ValidarUsuario(string nombreusuario, string clave)
        {
            return usuarioDAL.ValidarUsuario(nombreusuario,clave);
        }
    }
}
