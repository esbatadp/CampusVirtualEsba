using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class UsuarioTipo
    {

        #region Propiedades
        public int IdTipoUsuario { get; private set; }
        public string Descripcion { get; set; }
        #endregion

        #region Constructor
        public UsuarioTipo(string Descripcion)
        {
            this.Descripcion = Descripcion;        
        }
        #endregion

        #region Metodos
        public List<UsuarioTipo> Listar()
        {
            return new List<UsuarioTipo>();
        }

        public UsuarioTipo Obtener(int idTipoUsuario)
        {
            return new UsuarioTipo("UsuarioNuevo");
        }

        #endregion

    }
}
