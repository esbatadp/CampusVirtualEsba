using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Auditoria
    {
        #region Metodos publicos
        public static List<Entidades.Auditoria> Listar()
        {

            DataTable dt = new DataTable();
            dt = Datos.Auditoria.Listar();

            List<Entidades.Auditoria> listaAuditoria = new List<Entidades.Auditoria>();

            foreach (DataRow item in dt.Rows)
            {
                listaAuditoria.Add(ArmarDatos(item));
            }


            return listaAuditoria;
        }
        #endregion

        #region Metodos privados
        private static Entidades.Auditoria ArmarDatos(DataRow item)
        {
            Entidades.Auditoria auditoria = new Entidades.Auditoria ();
            auditoria.IdAuditoria = Convert.ToInt32(item["IdAuditoria"]);
            auditoria.Usuario = Usuario.Obtener(Convert.ToInt32(item["IdUsuario"]));
            auditoria.Accion = item["Accion"].ToString();
            auditoria.Tabla = item["Tabla"].ToString();
            auditoria.Fecha = Convert.ToDateTime(item["Fecha"]);
            auditoria.IdObjeto = Convert.ToInt32(item["IdObjeto"]);
            auditoria.Objeto = item["Objeto"].ToString();

            return auditoria;
        }
        #endregion
    }
}
