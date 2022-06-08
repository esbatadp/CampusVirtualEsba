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
    public class Materias
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
                    SqlCommand cmd = new SqlCommand("Materias_Listar", cn);

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
                throw new Exception("Error al obtener la lista de personas: " + ex.Message);
            }
        }

        public static DataTable Obtener(int idMateria)
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Materias_Obtener", cn);

                    //1.A Agregamos parametros a nuestro SP
                    cmd.Parameters.Add(new SqlParameter("@IdMateria", idMateria));

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
                throw new Exception("Error al obtener la lista de personas: " + ex.Message);
            }
        }

        public static DataTable Buscar(string descripcion)
        {
            return Listar();
        }

        public static int Insertar(Entidades.Materia materia)
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Materias_Insertar", cn);

                    //1.A Agregamos parametros a nuestro SP
                    cmd.Parameters.Add(new SqlParameter("@Descripcion", materia.Descripcion));

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
                throw new Exception("Error al insertar la Materia: " + ex.Message);
            }
        }

        public static void Modificar(Entidades.Materia materia)
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Materias_Modificar", cn);

                    //1.A Agregamos parametros a nuestro SP
                    cmd.Parameters.Add(new SqlParameter("@IdMateria", materia.IdMateria));
                    cmd.Parameters.Add(new SqlParameter("@Descripcion", materia.Descripcion));

                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Ejecuto el comando y asigo el valor al DataReader
                    var dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Actualizar la Materia: " + ex.Message);
            }
        }

        public static void Eliminar(int idMateria)
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Materias_Eliminar", cn);

                    //1.A Agregamos parametros a nuestro SP
                    cmd.Parameters.Add(new SqlParameter("@IdMateria", idMateria));

                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Ejecuto el comando y asigo el valor al DataReader
                    var dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Eliminar la Materia: " + ex.Message);
            }
        }

    }
}
