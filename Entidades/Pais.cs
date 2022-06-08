using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pais
    {
        #region Propiedades
        public int? IdPais { get; set; }
        public string Descripcion { get; set; }
        #endregion

        #region Constructores
        public Pais()
        { }
        public Pais(int idPais,string descripcion)
        {
            Descripcion = descripcion;
            IdPais = idPais;
        }
        #endregion
    }
}
