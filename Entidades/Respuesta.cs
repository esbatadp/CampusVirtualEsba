using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Respuesta
    {
        public int Codigo { get; set; }
        public bool EsCorrecta { get; set; }
        public string Mensaje { get; set; }
        public Object Datos { get; set; }

        public Respuesta(string mensaje = "", int codigo = 0,Object datos=null)
        {
            Codigo = codigo;
            EsCorrecta = mensaje == "";
            Mensaje = mensaje;
            Datos = datos;
        }
    }
}
