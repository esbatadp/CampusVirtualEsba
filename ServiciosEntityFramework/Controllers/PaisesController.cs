using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ServiciosEntityFramework.Models;

namespace ServiciosEntityFramework.Controllers
{
    public class PaisesController : ApiController
    {
        private CampusVirtualEntities db = new CampusVirtualEntities();

        // GET: api/Paises
        /// <summary>
        /// Este es un comentario
        /// </summary>
        /// <returns></returns>
        public IQueryable<Paises> GetPaises()
        {
            return db.Paises;
        }

        public IQueryable<Vw_UsuariosMenu> GetPaises3()
        {
            return db.Vw_UsuariosMenu;
        }

        // GET: api/Paises/5
        [ResponseType(typeof(Paises))]
        public async Task<IHttpActionResult> GetPaises(int id)
        {
            Paises paises = await db.Paises.FindAsync(id);
            if (paises == null)
            {
                return NotFound();
            }

            return Ok(paises);
        }

        // PUT: api/Paises/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPaises(int id, Paises paises)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != paises.IdPais)
            {
                return BadRequest();
            }


            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaisesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Paises
        [ResponseType(typeof(Paises))]
        public async Task<IHttpActionResult> PostPaises(Paises paises)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Paises.Add(paises);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = paises.IdPais }, paises);
        }

        // DELETE: api/Paises/5
        [ResponseType(typeof(Paises))]
        public async Task<IHttpActionResult> DeletePaises(int id)
        {
            Paises paises = await db.Paises.FindAsync(id);
            if (paises == null)
            {
                return NotFound();
            }

            db.Paises.Remove(paises);
            await db.SaveChangesAsync();

            return Ok(paises);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PaisesExists(int id)
        {
            return db.Paises.Count(e => e.IdPais == id) > 0;
        }
    }
}