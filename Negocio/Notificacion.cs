using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Notificacion
    {
     

        #region Metodos publicos
        public static List<Entidades.Notificacion> Listar()
        {

            DataTable dt = new DataTable();
            dt = Datos.Notificaciones.Listar();

            List<Entidades.Notificacion> listaNotificaciones = new List<Entidades.Notificacion>();

            foreach (DataRow item in dt.Rows)
            {
                listaNotificaciones.Add(ArmarDatos(item));
            }


            return listaNotificaciones;
        }

        public static List<Entidades.Notificacion> ListarporUsuarioEmisor(int idUsuarioEmisor)
        {

            DataTable dt = new DataTable();
            dt = Datos.Notificaciones.ListarporUsuarioEmisor(idUsuarioEmisor);

            List<Entidades.Notificacion> listaNotificaciones = new List<Entidades.Notificacion>();

            foreach (DataRow item in dt.Rows)
            {
                listaNotificaciones.Add(ArmarDatos(item));
            }


            return listaNotificaciones;
        }

        public static List<Entidades.Notificacion> ListarporUsuarioReceptor(int idUsuarioReceptor)
        {

            DataTable dt = new DataTable();
            dt = Datos.Notificaciones.ListarporUsuarioEmisor(idUsuarioReceptor);

            List<Entidades.Notificacion> listaNotificaciones = new List<Entidades.Notificacion>();

            foreach (DataRow item in dt.Rows)
            {
                listaNotificaciones.Add(ArmarDatos(item));
            }

            foreach (DataRow item in dt.Rows) //cuando el alumno lee sus notificaciones, se marcan todas como leidas
            {
                int id = Convert.ToInt32(item["IdNotificacion"]);
                Datos.Notificaciones.ModificarEstado(id);
            }


            return listaNotificaciones;
        }

        public static void Eliminar(int idNotificacion)
        {
            Datos.Notificaciones.Eliminar(idNotificacion);
        }

        public static int Grabar(Entidades.Notificacion Notificacion)
        {
            try
            {
                if (Validar(Notificacion,out string error))
                {
                    if (Notificacion.IdNotificacion == null)
                    {

                        return Insertar(Notificacion);
                    }
                    else
                    {
                        return Modificar(Notificacion);
                    }
                }
                else
                    throw new Exception(error);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        #endregion

        #region Metodos privados
        private static int Insertar(Entidades.Notificacion Notificacion)
        {
            return Datos.Notificaciones.Insertar(Notificacion);
        }

        private static int Modificar(Entidades.Notificacion Notificacion)
        {
            Datos.Notificaciones.Modificar(Notificacion);

            return Notificacion.IdNotificacion.Value;
        }

        private static bool Validar(Entidades.Notificacion Notificacion ,out string error)
        {
            error = "";

            Entidades.Usuario Emisor = Usuario.Obtener(Convert.ToInt32(Notificacion.UsuarioEmisor.IdUsuario.Value));
            Entidades.Usuario Receptor = Usuario.Obtener(Convert.ToInt32(Notificacion.UsuarioReceptor.IdUsuario.Value));

            if (Emisor == null)
                error += "El emisor que se quiere ingresar es inexistente;";

            if (Emisor != null && Emisor.TipoUsuario != Entidades.Enumerables.TipoUsuarios.Profesor)
                error += "El emisor que se quiere ingresar no es de tipo profesor;";

            if (Receptor == null)
                error += "El receptor que se quiere ingresar es inexistente;";

            if (Receptor != null && Receptor.TipoUsuario != Entidades.Enumerables.TipoUsuarios.Alumno)
                error += "El receptor que se quiere ingresar no es de tipo alumno;";

            if (string.IsNullOrEmpty(Notificacion.Descripcion))
                error += "La Descripcion ingresada se encuentra vacia ";

            if (Notificacion.Fecha == null)
                error += "La Fecha ingresada se encuentra vacia ";

            if (Notificacion.Fecha != null && Notificacion.Fecha > DateTime.Now)
                error += "La Fecha ingresada es mayor a la fecha actual";

            if (string.IsNullOrEmpty(error))
                return true;
            else
                return false;
        }

        private static Entidades.Notificacion ArmarDatos(DataRow item)
        {
            Entidades.Notificacion Notificacion = new Entidades.Notificacion();
            Notificacion.IdNotificacion = Convert.ToInt32(item["IdNotificacion"]);
            Notificacion.UsuarioReceptor = Negocio.Usuario.Obtener(Convert.ToInt32(item["IdUsuarioReceptor"]));
            Notificacion.UsuarioEmisor = Negocio.Usuario.Obtener(Convert.ToInt32(item["IdUsuarioEmisor"]));
            Notificacion.Descripcion = item["Descripcion"].ToString();
            Notificacion.Vista = Convert.ToBoolean(item["Vista"]);
            Notificacion.Fecha = Convert.ToDateTime(item["Fecha"]);
            return Notificacion;
        }
        #endregion
    }
}
