//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiciosEntityFramework.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Usuarios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuarios()
        {
            this.Cursos = new HashSet<Cursos>();
            this.Cursos_Alumnos = new HashSet<Cursos_Alumnos>();
        }
    
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Clave { get; set; }
        public Nullable<int> IdTipoUsuario { get; set; }
        public Nullable<int> edad { get; set; }
        public Nullable<bool> Activo { get; set; }
        public Nullable<int> IdPermiso { get; set; }
        public Nullable<System.DateTime> FechaNacimiento { get; set; }
        public Nullable<int> IdUsuarioLog { get; set; }
        public Nullable<int> IdEstado { get; set; }
        public string Observaciones { get; set; }
        public string CodigoActivacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cursos> Cursos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cursos_Alumnos> Cursos_Alumnos { get; set; }
        public virtual Estados_Tipos Estados_Tipos { get; set; }
        public virtual Permisos Permisos { get; set; }
        public virtual Usuarios_Tipos Usuarios_Tipos { get; set; }
    }
}
