using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Enumerables.ErroresLog;
using Newtonsoft.Json;

namespace Negocio
{
    public class Errores_Log
    {
     

        #region Metodos publicos
        public static List<Entidades.Errores_Log> Listar()
        {

            DataTable dt = new DataTable();
            dt = Datos.Errores_Logs.Listar();

            List<Entidades.Errores_Log> listaErrores_Loges = new List<Entidades.Errores_Log>();

            foreach (DataRow item in dt.Rows)
            {
                listaErrores_Loges.Add(ArmarDatos(item));
            }


            return listaErrores_Loges;
        }

        public static List<Entidades.Errores_Log> Buscar(Tabla tabla, Acciones accion)
        {

            if (tabla != Tabla.Ninguna)
                return Listar().Where(x => x.Tabla == tabla).OrderBy(x=>x.IdError_Log).ToList();

            if (accion != Acciones.Ninguna)
                return Listar().Where(x => x.Accion == accion).ToList();
            else
                return Listar();

        }

        public static int Grabar(Entidades.Errores_Log Errores_Log)
        {
            return Datos.Errores_Logs.Insertar(Errores_Log);
        }
        #endregion

        #region Metodos privados

        private static Entidades.Errores_Log ArmarDatos(DataRow item)
        {
            Enum.TryParse(item["Tabla"].ToString(), out Tabla tabla);
            Enum.TryParse(item["Accion"].ToString(), out Acciones accion);

            try
            {
                Entidades.Errores_Log Errores_Log = new Entidades.Errores_Log(
                        item["Descripcion"].ToString(),
                         Convert.ToInt32(item["Codigo"]),
                         tabla,
                         accion,
                         item["Objeto"].ToString(),
                         Convert.ToInt32(item["IdError_Log"])
                        );

                return Errores_Log;
            }
            catch (Exception ex)
            {

                Negocio.Errores_Log.Grabar(
                   new Entidades.Errores_Log
                    (
                       ex.Message,
                       ex.HResult,
                       Tabla.ErroresLog,
                       Acciones.ArmarDatos,
                       JsonConvert.SerializeObject(item)
                       )
                   );

                throw new Exception (ex.Message);
            }
        }
        #endregion
    }
}
