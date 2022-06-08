using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Cursos
    {
        public static DataTable Listar()
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("Cursos_Listar", cn);

                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Ejecuto el comando y asigo el valor al DataReader
                    var dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de Cursos: " + ex.Message);
            }
        }

        public static DataTable Obtener(int idCurso)
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Cursos_Obtener", cn);

                    //1.A Agregamos parametros a nuestro SP
                    cmd.Parameters.Add(new SqlParameter("@IdCurso", idCurso));

                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;


                    // Ejecuto el comando y asigo el valor al DataReader
                    var dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de Cursos: " + ex.Message);
            }
        }

        public static DataTable Buscar(int anio)
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("Cursos_Buscar", cn);

                    cmd.Parameters.Add(new SqlParameter("@Anio", anio));
                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Ejecuto el comando y asigo el valor al DataReader
                    var dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de Cursos: " + ex.Message);
            }
        }

        public static int Insertar(Entidades.Curso curso)
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Cursos_Insertar", cn);

                    //1.A Agregamos parametros a nuestro SP
                    cmd.Parameters.Add(new SqlParameter("@IdMateria", curso.Materia.IdMateria));
                    cmd.Parameters.Add(new SqlParameter("@IdProfesor", curso.Profesor.IdUsuario));
                    cmd.Parameters.Add(new SqlParameter("@Cuatrimestre", curso.Cuatrimestre));
                    cmd.Parameters.Add(new SqlParameter("@Anio", curso.Anio));

                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;


                    // Ejecuto el comando y asigo el valor al DataReader
                    var dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);
                }

                return Convert.ToInt32(dt.Rows[0][0]);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar un Curso: " + ex.Message);
            }
        }

        public static void Modificar(Entidades.Curso curso)
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Cursos_Modificar", cn);

                    //1.A Agregamos parametros a nuestro SP
                    cmd.Parameters.Add(new SqlParameter("@IdCurso", curso.IdCurso));
                    cmd.Parameters.Add(new SqlParameter("@IdMateria", curso.Materia.IdMateria));
                    cmd.Parameters.Add(new SqlParameter("@IdProfesor", curso.Profesor.IdUsuario));
                    cmd.Parameters.Add(new SqlParameter("@Cuatrimestre", curso.Cuatrimestre));
                    cmd.Parameters.Add(new SqlParameter("@Anio", curso.Anio));

                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;


                    // Ejecuto el comando y asigo el valor al DataReader
                    var dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar un Curso: " + ex.Message);
            }
        }

        public static void CambiarEstado(int idCurso, int idEstado)
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Cursos_ModificarEstado", cn);

                    //1.A Agregamos parametros a nuestro SP
                    cmd.Parameters.Add(new SqlParameter("@idCurso", idCurso));
                    cmd.Parameters.Add(new SqlParameter("@IdEstado", idEstado));
                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Ejecuto el comando y asigo el valor al DataReader
                    var dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Desactivar el Curso: " + ex.Message);
            }
        }

    }
}
