using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {
        #region Propiedades
        public int? IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Clave { get; set; }
        public int Edad { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Enumerables.TipoUsuarios TipoUsuario { get; set; }
        public Enumerables.Estados Estado { get; set; }
        public Permiso Permiso { get; set; }
        public string Observaciones { get; set; }
        public string CodigoActivacion { get; set; }
        #endregion

    }
}
