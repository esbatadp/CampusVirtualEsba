using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Curso_Alumno
    {
        public int? IdCursoAlumno { get; set; }
        public Curso Curso { get; set; }
        public Usuario Alumno { get; set; }
    }
}
