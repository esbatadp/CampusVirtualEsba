using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Materia
    {
     

        #region Metodos publicos
        public static List<Entidades.Materia> Listar()
        {

            DataTable dt = new DataTable();
            dt = Datos.Materias.Listar();

            List<Entidades.Materia> listaMateriaes = new List<Entidades.Materia>();

            foreach (DataRow item in dt.Rows)
            {
                listaMateriaes.Add(ArmarDatos(item));
            }


            return listaMateriaes;
        }

        public static Entidades.Materia Obtener(int idMateria)
        {
            DataTable dt = new DataTable();
            dt = Datos.Materias.Obtener(idMateria);

            return ArmarDatos(dt.Rows[0]);
        }

        public static List<Entidades.Materia> Buscar(string descripcion)
        {
            DataTable dt = new DataTable();
            dt = Datos.Materias.Buscar(descripcion);
            List<Entidades.Materia> listaMateriaes = new List<Entidades.Materia>();

            foreach (DataRow item in dt.Rows)
            {
                listaMateriaes.Add(ArmarDatos(item));
            }

            return listaMateriaes;
        }          

        public static void Eliminar(int idMateria)
        {
            Datos.Materias.Eliminar(idMateria);
        }

        public static int Grabar(Entidades.Materia materia)
        {
            try
            {
                if (Validar(materia,out string error))
                {
                    if (materia.IdMateria == null)
                    {

                        return Insertar(materia);
                    }
                    else
                    {
                        return Modificar(materia);
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
        private static int Insertar(Entidades.Materia materia)
        {
            return Datos.Materias.Insertar(materia);
        }

        private static int Modificar(Entidades.Materia materia)
        {
            Datos.Materias.Modificar(materia);

            return materia.IdMateria.Value;
        }

        private static bool Validar(Entidades.Materia materia ,out string error)
        {
            error = "";

            if (string.IsNullOrEmpty(materia.Descripcion))
                error += "La Descripcion ingresada se encuentra vacia ";

            if (string.IsNullOrEmpty(error))
                return true;
            else
                return false;
        }

        private static Entidades.Materia ArmarDatos(DataRow item)
        {
            Entidades.Materia Materia = new Entidades.Materia(Convert.ToInt32(item["IdMateria"]), item["Descripcion"].ToString());
            return Materia;
        }
        #endregion
    }
}
