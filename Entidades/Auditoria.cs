using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Auditoria
    {
        #region Propiedades
        public int? IdAuditoria { get; set; }
        public Usuario Usuario { get; set; }
        public string Accion { get; set; }
        public string Tabla { get; set; }
        public DateTime Fecha { get; set; }
        public int IdObjeto { get; set; }
        public string Objeto { get; set; }

        #endregion

        #region Constructores
        public Auditoria()
        {
        }

        public Auditoria(int idauditoria, Entidades.Usuario usuario, string accion, string tabla, DateTime fecha, int idobjeto, string objeto = "")
        {
            IdAuditoria = idauditoria;
            Usuario = usuario;
            Accion = accion;
            Tabla = tabla;
            Fecha = fecha;
            IdObjeto = idobjeto;
            Objeto = objeto;
        }
        #endregion
    }
}
