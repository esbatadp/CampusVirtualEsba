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
    
    public partial class Cursos_Alumnos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cursos_Alumnos()
        {
            this.Notas_Alumnos = new HashSet<Notas_Alumnos>();
        }
    
        public int IdCursoAlumno { get; set; }
        public Nullable<int> IdCurso { get; set; }
        public Nullable<int> IdAlumno { get; set; }
    
        public virtual Cursos Cursos { get; set; }
        public virtual Usuarios Usuarios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Notas_Alumnos> Notas_Alumnos { get; set; }
    }
}
