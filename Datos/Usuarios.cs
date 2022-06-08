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
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Usuarios_Listar", cn);

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

        public static DataTable Obtener(int idUsuario)
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Usuarios_Obtener", cn);

                    //1.A Agregamos parametros a nuestro SP
                    cmd.Parameters.Add(new SqlParameter("@idUsuario", idUsuario));

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

        public static DataTable Obtener(string email, string clave)
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Usuarios_Obtener", cn);

                    //1.A Agregamos parametros a nuestro SP
                    cmd.Parameters.Add(new SqlParameter("@Email", email));
                    cmd.Parameters.Add(new SqlParameter("@Clave", clave));

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

        public static int Insertar(Entidades.Usuario usuario)
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Usuarios_Insertar", cn);

                    //1.A Agregamos parametros a nuestro SP
                    cmd.Parameters.Add(new SqlParameter("@Nombre", usuario.Nombre));
                    cmd.Parameters.Add(new SqlParameter("@Apellido", usuario.Apellido));
                    cmd.Parameters.Add(new SqlParameter("@Email", usuario.Email));
                    cmd.Parameters.Add(new SqlParameter("@Direccion", usuario.Direccion));
                    cmd.Parameters.Add(new SqlParameter("@Clave", usuario.Clave));
                    cmd.Parameters.Add(new SqlParameter("@IdTipoUsuario", (int)usuario.TipoUsuario));
                    cmd.Parameters.Add(new SqlParameter("@Edad", usuario.Edad));
                    cmd.Parameters.Add(new SqlParameter("@Activo", usuario.Activo));
                    cmd.Parameters.Add(new SqlParameter("@IdPermiso", usuario.Permiso.IdPermiso));
                    cmd.Parameters.Add(new SqlParameter("@FechaNacimiento", usuario.FechaNacimiento));
                    cmd.Parameters.Add(new SqlParameter("@CodigoActivacion", usuario.CodigoActivacion));
                    cmd.Parameters.Add(new SqlParameter("@Observaciones", usuario.Observaciones));
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
                throw new Exception("Error al insertar un usuario: " + ex.Message);
            }
        }

        public static void Modificar(Entidades.Usuario usuario)
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Usuarios_Modificar", cn);

                    //1.A Agregamos parametros a nuestro SP
                    cmd.Parameters.Add(new SqlParameter("@IdUsuario", usuario.IdUsuario));
                    cmd.Parameters.Add(new SqlParameter("@Nombre", usuario.Nombre));
                    cmd.Parameters.Add(new SqlParameter("@Apellido", usuario.Apellido));
                    cmd.Parameters.Add(new SqlParameter("@Email", usuario.Email));
                    cmd.Parameters.Add(new SqlParameter("@Direccion", usuario.Direccion));
                    cmd.Parameters.Add(new SqlParameter("@Clave", usuario.Clave));
                    cmd.Parameters.Add(new SqlParameter("@IdTipoUsuario", (int)usuario.TipoUsuario));
                    cmd.Parameters.Add(new SqlParameter("@Edad", usuario.Edad));
                    cmd.Parameters.Add(new SqlParameter("@Activo", usuario.Activo));
                    cmd.Parameters.Add(new SqlParameter("@IdPermiso", usuario.Permiso.IdPermiso));
                    cmd.Parameters.Add(new SqlParameter("@CodigoActivacion", usuario.CodigoActivacion));
                    cmd.Parameters.Add(new SqlParameter("@FechaNacimiento", usuario.FechaNacimiento));

                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;


                    // Ejecuto el comando y asigo el valor al DataReader
                    var dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Modificar el Permiso: " + ex.Message);
            }
        }

        public static void CambiarEstado(int idUsuario, int idEstado)
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Usuarios_ModificarEstado", cn);

                    //1.A Agregamos parametros a nuestro SP
                    cmd.Parameters.Add(new SqlParameter("@IdUsuario", idUsuario));
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
                throw new Exception("Error al Desactivar el Permiso: " + ex.Message);
            }
        }

        public static void Activar(string codigoActivacion)
        {
            try
            {
                 DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Usuarios_Activar", cn);

                    //1.A Agregamos parametros a nuestro SP
                    cmd.Parameters.Add(new SqlParameter("@CodigoActivacion", codigoActivacion));                    
                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Ejecuto el comando y asigo el valor al DataReader
                    var dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al activar el usuario: " + ex.Message);
            }
        }

    }
}
