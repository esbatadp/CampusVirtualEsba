using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Permiso
    {
        #region Propiedades
        public int? IdPermiso { get;  set; }
        public string Descripcion { get;  set; }
        public bool Activo { get;  set; }
        #endregion

        #region Constructores
        public Permiso()
        {
        }

        public Permiso(string descripcion, bool activo = true)
        {
            Descripcion = descripcion;
            Activo = activo;
        }
        #endregion
    }
}
