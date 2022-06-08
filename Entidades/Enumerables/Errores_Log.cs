using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Enumerables.ErroresLog
{
    public enum Tabla
    {
        Usuarios=1,
        Permisos=2,
        Paises=3,
        ErroresLog = 4,
        Ninguna =4
    }
    public enum Acciones
    {
        Alta = 1,
        Baja = 2,
        Modificacion = 3,        
        Consulta = 4,
        Ninguna=5,
        Grabar= 6,
        ArmarDatos = 7,
    }
}
