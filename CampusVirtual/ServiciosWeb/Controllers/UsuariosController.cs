using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServiciosWeb.Controllers
{
    public class UsuariosController : ApiController
    {
        [HttpGet]
        [Route("Listar")]
        public Respuesta Listar()
        {
            try
            {
                List<Usuario> ListaUsuarios = Usuario.Listar();

                if (ListaUsuarios.Count == 0)
                    return new Respuesta { Codigo = HttpStatusCode.NoContent, Datos = ListaUsuarios, Mensaje = "No existen usuarios con el nombre indicado" };
                else
                    return new Respuesta { Codigo = HttpStatusCode.OK, Datos = ListaUsuarios, Mensaje = "" };

            }
            catch (Exception ex)
            {

                return new Respuesta { Codigo = HttpStatusCode.InternalServerError, Datos = null, Mensaje = ex.Message };
            }

        }

        [HttpGet]
        [Route("Obtener")]
        public Respuesta Obtener(int idUsuario)
        {
            try
            {
                Usuario Usuario = Usuario.Obtener(idUsuario);

                if (Usuario== null)
                    return new Respuesta { Codigo = HttpStatusCode.NoContent, Datos = Usuario, Mensaje = "No existen usuarios con el nombre indicado" };
                else
                    return new Respuesta { Codigo = HttpStatusCode.OK, Datos = Usuario, Mensaje = "" };

            }
            catch (Exception ex)
            {

                return new Respuesta { Codigo = HttpStatusCode.InternalServerError, Datos = null, Mensaje = ex.Message };
            }
        }

        [HttpGet]
        [Route("BuscarPorNombre")]
        public Respuesta BuscarPorNombre(string nombre)
        {

            try
            {
                List<Usuario> ListaUsuarios = Usuario.BuscarPorNombre(nombre);

                if (ListaUsuarios.Count == 0)
                    return new Respuesta { Codigo = HttpStatusCode.NoContent, Datos = ListaUsuarios, Mensaje = "No existen usuarios con el nombre indicado" };
                else
                    return  new Respuesta { Codigo = HttpStatusCode.OK, Datos = ListaUsuarios, Mensaje = "" };

            }
            catch (Exception ex)
            {

                return new Respuesta { Codigo = HttpStatusCode.InternalServerError, Datos = null, Mensaje = ex.Message };
            }


        }

        [HttpPost]
        [Route("Insertar")]
        public Respuesta Insertar(Usuario usuario)
        {

            try
            {
                int id = usuario.Insertar();

                if (id>0)
                    return new Respuesta { Codigo = HttpStatusCode.Created, Datos = id, Mensaje = "" };
                else
                    return new Respuesta { Codigo = HttpStatusCode.BadRequest, Datos = 0, Mensaje = "Error al grabar el usuario" };
                

            }
            catch (Exception ex)
            {

                return new Respuesta { Codigo = HttpStatusCode.InternalServerError, Datos = null, Mensaje = ex.Message };
            }


        }

    }
}
