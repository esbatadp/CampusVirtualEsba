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
    public class Usuarios
    {

        public static DataTable Listar()
        {
            try
            {

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    DataTable dt = new DataTable();

                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Usuarios_Listar", cn);

                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Ejecuto el comando y asigo el valor al DataReader
                    var dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);

                    return dt;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error al Guardar el usuario: " + ex.Message);
            }
        }

        public static DataTable BuscarPorNombre(string nombre)
        {
            try
            {

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    DataTable dt = new DataTable();

                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Usuarios_Buscar", cn);

                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;

                    //3. Especifico los parámetros
                    cmd.Parameters.Add(new SqlParameter("@Nombre", nombre));

                    // Ejecuto el comando y asigo el valor al DataReader
                    var dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);

                    return dt;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error al Obtener la lista de usuarios: " + ex.Message);
            }
        }

        public static int Insertar(string nombre, string apellido, string email, string direccion, string clave, int idTipoUsuario, int edad, bool activo, int idPermiso, DateTime fechaNacimiento)
        {

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
            {
                DataTable dt = new DataTable();

                cn.Open();

                // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                SqlCommand cmd = new SqlCommand("SP_Usuarios_Insertar", cn);

                // 2. Especifico el tipo de Comando
                cmd.CommandType = CommandType.StoredProcedure;

                //3. Especifico los parámetros
                cmd.Parameters.Add(new SqlParameter("@Nombre", nombre));
                cmd.Parameters.Add(new SqlParameter("@Apellido", apellido));
                cmd.Parameters.Add(new SqlParameter("@Email", email));
                cmd.Parameters.Add(new SqlParameter("@Direccion", direccion));
                cmd.Parameters.Add(new SqlParameter("@Clave", clave));
                cmd.Parameters.Add(new SqlParameter("@IdTipoUsuario", idTipoUsuario));
                cmd.Parameters.Add(new SqlParameter("@Edad", edad));
                cmd.Parameters.Add(new SqlParameter("@Activo", activo));
                cmd.Parameters.Add(new SqlParameter("@IdPermiso", idPermiso));
                cmd.Parameters.Add(new SqlParameter("@FechaNacimiento", fechaNacimiento));

                // Ejecuto el comando y asigo el valor al DataReader
                var dataReader = cmd.ExecuteReader();

                dt.Load(dataReader);

                return Convert.ToInt32(dt.Rows[0][0]);

            }
        }
    
    }
}
