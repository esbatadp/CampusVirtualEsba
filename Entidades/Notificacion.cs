using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Notificacion
    {
        #region Propiedades
        public int? IdNotificacion { get; set; }
        public Usuario UsuarioReceptor { get; set; }
        public Usuario UsuarioEmisor { get; set; }
        public string Descripcion { get; set; }
        public bool Vista { get; set; }
        public DateTime Fecha { get; set; }
        #endregion


        #region Constructores
        public Notificacion()
        { }
        public Notificacion(int? idNotificacion, Usuario usuarioReceptor, Usuario usuarioEmisor, string descripcion, bool vista, DateTime fecha)
        {
            IdNotificacion = idNotificacion;
            UsuarioReceptor = usuarioReceptor;
            UsuarioEmisor = usuarioEmisor;
            Descripcion = descripcion;
            Vista = vista;
            Fecha = fecha;
        }
        #endregion

    }
}
