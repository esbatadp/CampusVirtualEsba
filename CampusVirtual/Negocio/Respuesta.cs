using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Respuesta
    {
        public HttpStatusCode Codigo { get; set; }
        public string Mensaje { get; set; }
        public object Datos { get; set; }
    }
}
