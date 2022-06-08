using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class EstadoTipo
    {

        #region Propiedades

        public int IdEstado { get; private set; }
        public string Descripcion { get; set; }

        #endregion

        #region Constructor

        public EstadoTipo(string Descripcion)
        {
            this.Descripcion = Descripcion;
        }

        #endregion

        #region Metodos

        public List<EstadoTipo> Listar()
        {
            return new List<EstadoTipo>();
        }

        public EstadoTipo Obtener(int idEstado)
        {
            return new EstadoTipo("EstadoNuevo");
        }

        #endregion

    }
}
