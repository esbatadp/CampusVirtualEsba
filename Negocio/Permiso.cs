using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Permiso
    {
        #region Metodos publicos
        public static List<Entidades.Permiso> Listar()
        {

            DataTable dt = new DataTable();
            dt = Datos.Permisos.Listar();

            List<Entidades.Permiso> listaPermisos = new List<Entidades.Permiso>();

            foreach (DataRow item in dt.Rows)
            {
                listaPermisos.Add(ArmarDatos(item));
            }


            return listaPermisos;
        }

        public static Entidades.Permiso Obtener(int idPermiso)
        {
            DataTable dt = new DataTable();
            dt = Datos.Permisos.Obtener(idPermiso);

            return ArmarDatos(dt.Rows[0]);
        }

        public static void Desactivar(int idPermiso)
        {
            Datos.Permisos.Desactivar(idPermiso);
        }

        public int Grabar(Entidades.Permiso permiso)
        {
            try
            {
                if (Validar(permiso,out string error))
                {
                    if (permiso.IdPermiso == null)
                    {

                        return Insertar(permiso);
                    }
                    else
                    {
                        return Modificar(permiso);
                    }
                }
                else
                    throw new Exception(error);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }   

        }
        #endregion

        #region Metodos privados
        private int Insertar(Entidades.Permiso permiso)
        {
            return Datos.Permisos.Insertar(permiso.Descripcion);
        }

        private int Modificar(Entidades.Permiso permiso)
        {
            Datos.Permisos.Modificar(permiso);
            return permiso.IdPermiso.Value;
        }

        private bool Validar(Entidades.Permiso permiso,out string error)
        {
            error = "";

            if (string.IsNullOrEmpty(permiso.Descripcion))
                error += "La Descripcion ingresada se encuentra vacia ";

            if (string.IsNullOrEmpty(error))
                return true;
            else
                return false;
        }

        private static Entidades.Permiso ArmarDatos(DataRow item)
        {
            Entidades.Permiso permiso = new Entidades.Permiso();
            permiso.IdPermiso = Convert.ToInt32(item["IdPermiso"]);
            permiso.Descripcion = item["Descripcion"].ToString();
            permiso.Activo= Convert.ToBoolean(item["Activo"] == null ? true : false);

            return permiso;
        }
        #endregion
    }
}
