using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Materia
    {
        #region Propiedades
        public int? IdMateria { get; set; }
        public string Descripcion { get; set; }
        #endregion

        #region Constructores
        public Materia()
        { }
        public Materia(int idMateria,string descripcion)
        {
            Descripcion = descripcion;
            IdMateria = idMateria;
        }
        #endregion
    }
}
