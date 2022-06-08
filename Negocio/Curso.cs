using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Negocio
{
    public class Curso
    {
     

        #region Metodos publicos
        public static List<Entidades.Curso> Listar()
        {

            DataTable dt = new DataTable();
            dt = Datos.Cursos.Listar();

            List<Entidades.Curso> listaCursos = new List<Entidades.Curso>();

            foreach (DataRow item in dt.Rows)
            {
                listaCursos.Add(ArmarDatos(item));
            }


            return listaCursos;
        }

        public static Entidades.Curso Obtener(int idCurso)
        {
            DataTable dt = new DataTable();
            dt = Datos.Cursos.Obtener(idCurso);

            return ArmarDatos(dt.Rows[0]);
        }

        public static void CambiarEstado(int idCurso,Entidades.Enumerables.Estados Estado)
        {
           Datos.Cursos.CambiarEstado(idCurso, (int)Estado);
        }

        public int Grabar(Entidades.Curso curso)
        {
            try
            {
                if (Validar(curso, out string error))
                {
                    if (curso.IdCurso == null)
                    {
                        return Insertar(curso);
                    }
                    else
                    {
                        return Modificar(curso);
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
        private int Insertar(Entidades.Curso curso)
        {
            using (TransactionScope tran = new TransactionScope())
            {
                return Datos.Cursos.Insertar(curso);
            }
            
        }

        private int Modificar(Entidades.Curso curso)
        {
            Datos.Cursos.Modificar(curso);

            return curso.IdCurso.Value;
        }

        private bool Validar(Entidades.Curso curso,out string error)
        {
            error = "";

            Entidades.Usuario profesor = Usuario.Obtener(Convert.ToInt32(curso.Profesor.IdUsuario.Value));
            Entidades.Materia materia = Materia.Obtener(Convert.ToInt32(curso.Materia.IdMateria.Value));

            if (materia == null)
                error += "la materia que se quiere ingresar es inexistente; ";

            if (profesor == null)
                error += "El usuario que se quiere ingresar es inexistente;";

            if (profesor != null && profesor.TipoUsuario != Entidades.Enumerables.TipoUsuarios.Profesor)
                error += "El usuario que se quiere ingresar no es de tipo profesor;";

            if (curso.Anio < DateTime.Now.Year)
                error += "Error el año ingresado es menor al actual ";

            if (curso.Anio > DateTime.Now.Year && curso.Anio.ToString().Length>4)
                error += "Error el formato del año ingresado es Incorrecto";

            if (curso.Cuatrimestre.ToString().Length > 1)
                error += "Error el formato del Cuatrimestre ingresado es Incorrecto";

            if (string.IsNullOrEmpty(error))
                return true;
            else
                return false;
        }

        private static Entidades.Curso ArmarDatos(DataRow item)
        {
            Entidades.Curso Curso = new Entidades.Curso();
            Curso.IdCurso = Convert.ToInt32(item["IdCurso"]);
            Curso.Materia = Negocio.Materia.Obtener(Convert.ToInt32(item["IdMateria"]));
            Curso.Profesor = Usuario.Obtener(Convert.ToInt32(item["IdProfesor"]));
            Curso.Anio = Convert.ToInt32(item["Anio"]);
            Curso.Cuatrimestre = Convert.ToInt32(item["Cuatrimestre"]);

            return Curso;
        }
        #endregion

    }
}
