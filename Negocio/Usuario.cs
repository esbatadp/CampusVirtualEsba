using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Enumerables.ErroresLog;
using Newtonsoft.Json;

namespace Negocio
{
    public class Usuario
    {
        #region Metodos publicos

        public static List<Entidades.Usuario> Listar()
        {

            DataTable dt = new DataTable();
            dt =  Datos.Usuarios.Listar();

            List<Entidades.Usuario> listaUsuarios = new List<Entidades.Usuario>();

            foreach (DataRow item in dt.Rows)
            {
                listaUsuarios.Add(ArmarDatos(item));
            }


            return listaUsuarios;
        }

        public static Entidades.Usuario Obtener(int idUsuario)
        {
            DataTable dt = new DataTable();
            dt = Datos.Usuarios.Obtener(idUsuario);

            return ArmarDatos(dt.Rows[0]);
        }

        public static Entidades.Usuario Obtener(string email, string clave)
        {
            DataTable dt = new DataTable();
            //dt = Datos.Usuarios.Obtener(email, Utilidades.Seguridad.Encriptar(clave));
            dt = Datos.Usuarios.Obtener(email, clave);

            if (dt.Rows.Count > 0)
                return ArmarDatos(dt.Rows[0]);
            else
                return null;
        }

        public static Entidades.Usuario Obtener(string email)
        {
            DataTable dt = new DataTable();
            dt = Datos.Usuarios.Obtener(email, "");

            if (dt.Rows.Count > 0)
                return ArmarDatos(dt.Rows[0]);
            else
                return null;
        }

        public static void CambiarEstado(int idUsuario,Entidades.Enumerables.Estados Estado)
        {
           Datos.Usuarios.CambiarEstado(idUsuario, (int)Estado);
        }

        public static void Activar(string codigoVerificacion)
        {
            Datos.Usuarios.Activar(codigoVerificacion);
        }

        public static int Grabar(Entidades.Usuario usuario)
        {
            try
            {
                if (esValida(usuario, out string error))
                {
                    if (usuario.IdUsuario == null)
                        return Insertar(usuario);
                    else
                        return Modificar(usuario);
                }
                else
                    throw new Exception(error);
            }
            catch (Exception ex)
            {

                Negocio.Errores_Log.Grabar(
                    new Entidades.Errores_Log(
                        ex.Message,
                        ex.HResult,
                        Tabla.Usuarios,
                        Acciones.Grabar,
                        JsonConvert.SerializeObject(usuario)
                        )
                    );

                throw new Exception(ex.Message);
            }

        }


        #endregion

        #region Metodos privados        

        private static int Insertar(Entidades.Usuario usuario, bool GeneraToken=true)
        {
            try
            {
                usuario.CodigoActivacion = Utilidades.Seguridad.GenerarToken();
                int id= Datos.Usuarios.Insertar(usuario);

                if (id>0 && GeneraToken)
                {                   

                    Negocio.Utilidades.Email.Enviar
                        (
                           ConfigurationManager.AppSettings["UsuarioCorreo"].ToString(),
                           usuario.Email,
                           "Esba",
                           usuario.Nombre,
                           ConfigurationManager.AppSettings["UsuarioCorreo"].ToString(),
                           ConfigurationManager.AppSettings["Clave"].ToString(),
                           "Codigo de Verificacion",
                           "Tu codigo es: "+ usuario.CodigoActivacion,
                           false,
                           ConfigurationManager.AppSettings["Host"].ToString(),
                           Convert.ToInt32(ConfigurationManager.AppSettings["Puerto"].ToString()),
                           Convert.ToBoolean(ConfigurationManager.AppSettings["UsaSSL"].ToString())
                       );
                }

                return id;

            }
            catch (Exception ex)
            {
                throw new Exception( ex.Message);
            }
        }

        private static int Modificar(Entidades.Usuario usuario)
        {
            Datos.Usuarios.Modificar(usuario);
            
            return usuario.IdUsuario.Value;
        }

        private static bool esValida(Entidades.Usuario usuario, out string error)
        {
            error = "";

            if (string.IsNullOrEmpty(usuario.Nombre))
                error += "El nombre ingresado se encuentra vacio; ";


            if (string.IsNullOrEmpty(usuario.Apellido))
                error += "El Apellido ingresado se encuentra vacio; ";


            if (string.IsNullOrEmpty(usuario.Direccion))
                error += "La Direccion ingresado se encuentra vacia; ";


            if (usuario.Edad <=0)
                error += "La Edad ingresada no es válida. Tiene que ser mayor a 0; ";


            if (string.IsNullOrEmpty(error))
                return true;
            else
                return false;
        }

        private static Entidades.Usuario ArmarDatos(DataRow item)
        {
            try
            {
                Entidades.Usuario Usuario = new Entidades.Usuario();


                Usuario.IdUsuario = Convert.ToInt32(item["IdUsuario"]);
                Usuario.Nombre = item["Nombre"].ToString();
                Usuario.Apellido = item["Apellido"].ToString();
                // Usuario.Permiso = Permiso.Obtener(Convert.ToInt32(item["IdPermiso"]));
                Usuario.Estado = (Entidades.Enumerables.Estados)(Convert.ToInt32(item["IdEstado"]));
                Usuario.Clave = item["Clave"].ToString();
                Usuario.Direccion = item["Direccion"].ToString();
                Usuario.Email = item["Email"].ToString();

                if (item["IdTipoUsuario"] != null)
                    Usuario.TipoUsuario = (Entidades.Enumerables.TipoUsuarios)(Convert.ToInt32(item["IdTipoUsuario"]));
                else
                    Usuario.TipoUsuario = Entidades.Enumerables.TipoUsuarios.SinTipo;

                return Usuario;
            }
            catch (Exception ex)
            {
                Negocio.Errores_Log.Grabar(
                   new Entidades.Errores_Log
                    (
                       ex.Message,
                       ex.HResult,
                       Tabla.Usuarios,
                       Acciones.ArmarDatos,
                       JsonConvert.SerializeObject(item)
                       )
                   );

                throw new Exception(ex.Message);
            }
        }

        #endregion

    }
}
