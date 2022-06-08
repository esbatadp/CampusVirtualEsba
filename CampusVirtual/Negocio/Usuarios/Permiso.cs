using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Permiso
    {

        #region Propiedades
        public int IdPermiso { get; private set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        #endregion

        #region Constructor
        public Permiso(int idPermiso=1,string descripcion="Administrador",bool activo=true)
        {
            this.IdPermiso = idPermiso;
            this.Descripcion = descripcion;
            this.Activo = activo;
        }
        #endregion

        #region Metodos
        public List<Permiso> Listar()
        {
            return new List<Permiso>();
        }

        public Permiso Obtener(int idPermiso)
        {
            return new Permiso();
        }

        #endregion

    }
}
