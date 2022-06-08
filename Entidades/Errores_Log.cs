using Entidades.Enumerables.ErroresLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Errores_Log
    {
        #region Propiedades
        public int? IdError_Log { get; set; }
        public string Descripcion { get; set; }
        public int? Codigo { get; set; }
        public Tabla Tabla { get; set; }
        public Acciones Accion { get; set; }
        public string Objeto { get; set; }
        public DateTime  Fecha { get; set; }
        #endregion

        #region Constructores
        public Errores_Log(string descripcion, int codigo=0, Tabla tabla= Tabla.Ninguna , Acciones accion= Acciones.Ninguna , string objeto=null, int idError_Log=0)
        {
            Descripcion = descripcion;
            Codigo = codigo;
            Tabla = tabla;
            Accion = accion;
            Objeto = objeto;
            IdError_Log = idError_Log;
            Fecha = DateTime.Now;
        }
        #endregion
    }
}
