using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Curso_Alumno
    {
     

        #region Metodos publicos
        public static List<Entidades.Curso_Alumno> Listar()
        {

            DataTable dt = new DataTable();
            dt = Datos.Cursos_Alumnos.Listar();

            List<Entidades.Curso_Alumno> listaCurso_Alumnos = new List<Entidades.Curso_Alumno>();

            foreach (DataRow item in dt.Rows)
            {
                listaCurso_Alumnos.Add(ArmarDatos(item));
            }


            return listaCurso_Alumnos;
        }

        public static void Eliminar(int idCurso_Alumno)
        {
            Datos.Cursos_Alumnos.Eliminar(idCurso_Alumno);
        }

        public static int Grabar(Entidades.Curso_Alumno Curso_Alumno)
        {
            try
            {
                if (Validar(Curso_Alumno,out string error))
                {
                    if (Curso_Alumno.IdCursoAlumno == null)
                    {
                        return Insertar(Curso_Alumno);
                    }
                    else
                    {
                        return Modificar(Curso_Alumno);
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
        private static int Insertar(Entidades.Curso_Alumno Curso_Alumno)
        {
            return Datos.Cursos_Alumnos.Insertar(Curso_Alumno);
        }

        private static int Modificar(Entidades.Curso_Alumno Curso_Alumno)
        {
            Datos.Cursos_Alumnos.Modificar(Curso_Alumno);

            return Curso_Alumno.IdCursoAlumno.Value;
        }

        private static bool Validar(Entidades.Curso_Alumno Curso_Alumno ,out string error)
        {
            error = "";

            if (Curso_Alumno.Alumno.TipoUsuario!= Entidades.Enumerables.TipoUsuarios.Alumno)
                error += "El usuario que desea ingresar no es un alumno";

            if (string.IsNullOrEmpty(error))
                return true;
            else
                return false;
        }

        private static Entidades.Curso_Alumno ArmarDatos(DataRow item)
        {
            Entidades.Curso_Alumno Curso_Alumno = new Entidades.Curso_Alumno();
            
            Curso_Alumno.IdCursoAlumno = Convert.ToInt32(item["IdCursoAlumno"]);
            Curso_Alumno.Curso = Negocio.Curso.Obtener(Convert.ToInt32(item["IdCurso"]));
            Curso_Alumno.Alumno= Negocio.Usuario.Obtener(Convert.ToInt32(item["IdAlumno"]));

            return Curso_Alumno;
        }
        #endregion
    }
}
