using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Usuario
    {
        #region Propiedades
        public int IdUsuario {get;set;}
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Clave { get; set; }
        public int Edad { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Permiso Permiso { get; set; }
        public UsuarioTipo UsuarioTipo { get; set; }
        public EstadoTipo EstadoTipo { get; set; }
        
        #endregion

        #region Constructor
        public Usuario()
        { }

        public Usuario(int idUsuario, string nombre, string apellido, string email, string direccion, string clave, UsuarioTipo usuarioTipo, int edad, bool activo, Permiso permiso, DateTime fechaNacimiento, EstadoTipo estadoTipo)
        {

            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Email = email;
            this.Direccion = direccion;
            this.Clave = clave;
            this.UsuarioTipo = usuarioTipo;
            this.Edad = edad;
            this.Activo = _Activo;
            this.Permiso = permiso;
            this.FechaNacimiento = fechaNacimiento;
            this.EstadoTipo = estadoTipo;
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Metodo que lista la tabla usuarios de la base datos
        /// </summary>
        /// <returns></returns>
        public static List<Usuario> Listar()
        {
            List<Usuario> ListaUsuario = new List<Usuario>();

            DataTable dt = Datos.Usuarios.Listar();

            foreach (DataRow dr in dt.Rows)
            {
                ListaUsuario.Add(ArmarDatos(dr));
            }


            return ListaUsuario;
        }

        public static List<Usuario> BuscarPorNombre(string nombre)
        {
            List<Usuario> ListaUsuario = new List<Usuario>();

            DataTable dt = Datos.Usuarios.BuscarPorNombre(nombre);

            foreach (DataRow dr in dt.Rows)
            {
                ListaUsuario.Add(ArmarDatos(dr));
            }


            return ListaUsuario;
        }

        public static Usuario Obtener(int IdUsuario)
        {
            return new Usuario();
        }

        private static Usuario ArmarDatos(DataRow dr)
        {

            Usuario u = new Usuario();
            u.Activo = Convert.ToBoolean(dr["Activo"]);
            u.Apellido = dr["Apellido"].ToString();
            u.Nombre = dr["Nombre"].ToString();

            return u;
        }

        public int Insertar()
        {
            try
            {
                int id=Datos.Usuarios.Insertar(Nombre, Apellido, Email, Direccion, Clave, UsuarioTipo.IdTipoUsuario, Edad, true, Permiso.IdPermiso, FechaNacimiento);

                return id;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al Insertar el usuario " + ex.Message);
            }
        
        }
        #endregion

    }
}
