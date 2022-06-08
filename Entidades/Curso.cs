using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Curso
    {
        #region Propiedades

        public int? IdCurso { get; set; }
        public Materia Materia { get; set; }
        public Usuario Profesor { get; set; }
        public int Cuatrimestre { get; set; }
        public int Anio { get; set; }  

        #endregion


    }
}
