using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Servicios.Controllers
{
    public class PaisesController : ApiController
    {
        [HttpGet]
        public Entidades.Respuesta Get()
        {
            try
            {

                return new Entidades.Respuesta("", (int)HttpStatusCode.OK, Negocio.Pais.Listar());

            }
            catch (Exception ex)
            {

                return new Entidades.Respuesta(ex.Message, (int)HttpStatusCode.BadRequest, null);
            }
            
        }

        [HttpGet]
        public Entidades.Respuesta Get(int id)
        {

            try
            {

                return new Entidades.Respuesta("", (int)HttpStatusCode.OK, Negocio.Pais.Obtener(id));

            }
            catch (Exception ex)
            {

                return new Entidades.Respuesta(ex.Message, (int)HttpStatusCode.BadRequest, null);
            }
        }

        [HttpPost]
        public Entidades.Respuesta Post(Entidades.Pais pais)
        {
            try
            {

                return new Entidades.Respuesta("", (int)HttpStatusCode.OK, Negocio.Pais.Grabar(pais));

            }
            catch (Exception ex)
            {

                return new Entidades.Respuesta(ex.Message, (int)HttpStatusCode.BadRequest, null);
            }
        }

        [HttpPut]
        public Entidades.Respuesta Put(Entidades.Pais pais)
        {
            try
            {

                return new Entidades.Respuesta("", (int)HttpStatusCode.OK, Negocio.Pais.Grabar(pais));

            }
            catch (Exception ex)
            {

                return new Entidades.Respuesta(ex.Message, (int)HttpStatusCode.BadRequest, null);
            }
        }
        
        [HttpDelete]
        public Entidades.Respuesta Delete(int id)
        {
            try
            {
                Negocio.Pais.Eliminar(id);
                return new Entidades.Respuesta("", (int)HttpStatusCode.OK,null);
            }
            catch (Exception ex)
            {
                return new Entidades.Respuesta(ex.Message, (int)HttpStatusCode.BadRequest, null);
            }
            
        }
    }
}
