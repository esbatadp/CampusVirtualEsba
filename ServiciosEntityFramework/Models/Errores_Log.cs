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
    
    public partial class Errores_Log
    {
        public int IdError_Log { get; set; }
        public string Descripcion { get; set; }
        public Nullable<int> Codigo { get; set; }
        public string Tabla { get; set; }
        public string Accion { get; set; }
        public string Objeto { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
    }
}