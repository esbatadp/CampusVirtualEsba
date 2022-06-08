using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class PaisesController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(Negocio.Pais.Listar());
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            Negocio.Pais.Eliminar(id);
            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Edicion(int id=0)
        {

            if(id==0)
                return View(new Entidades.Pais());
            else
                return View(Negocio.Pais.Obtener(id));
        }

        [HttpPost]
        public ActionResult Grabar(Entidades.Pais Pais)
        {
            try
            {
                Negocio.Pais.Grabar(Pais);
                return RedirectToAction("index");
            }
            catch (Exception ex)
            {

                return RedirectToAction("Error","Home");
            }
        }

    }
}
