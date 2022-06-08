using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Enumerables.ErroresLog;

namespace Datos
{
    public class Errores_Logs
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
                    SqlCommand cmd = new SqlCommand("SP_Errores_Log_Listar", cn);

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
                throw new Exception("Error al obtener la lista de errores: " + ex.Message);
            }
        }
        public static int Insertar(Entidades.Errores_Log Errores_Log)
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Errores_Log_Insertar", cn);

                    //1.A Agregamos parametros a nuestro SP
                    cmd.Parameters.Add(new SqlParameter("@Descripcion", Errores_Log.Descripcion));
                    cmd.Parameters.Add(new SqlParameter("@Codigo", Errores_Log.Codigo));
                    cmd.Parameters.Add(new SqlParameter("@Tabla", Errores_Log.Tabla.ToString()));
                    cmd.Parameters.Add(new SqlParameter("@Accion", Errores_Log.Accion.ToString()));
                    cmd.Parameters.Add(new SqlParameter("@Objeto", Errores_Log.Objeto.ToString()));
                    cmd.Parameters.Add(new SqlParameter("@Fecha", Errores_Log.Fecha));


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
                throw new Exception("Error al insertar la Errores_Log: " + ex.Message);
            }
        }

    }
}
