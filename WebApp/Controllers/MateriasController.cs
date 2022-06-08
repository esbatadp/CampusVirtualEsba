using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class MateriasController : Controller
    {
        
        public ActionResult Index()
        {
            return View(Negocio.Materia.Listar());
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            Negocio.Materia.Eliminar(id);
            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Edicion(int id = 0)
        {

            if (id == 0)
                return View(new Entidades.Materia());
            else
                return View(Negocio.Materia.Obtener(id));
        }

        [HttpPost]
        public ActionResult Grabar(Entidades.Materia Materia)
        {
            Negocio.Materia.Grabar(Materia);
            return RedirectToAction("index");
        }

    }
}
