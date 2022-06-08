using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class MenuController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edicion(int? id)
        {
            Entidades.Menu menu = new Entidades.Menu();
            if (id != null)
                menu = Negocio.Menu.Buscar(1008).Where(x => x.IdMenu == id).FirstOrDefault();
            
            return View(menu);
        }


        public JsonResult Guardar(Entidades.Menu menu)
        {
            try
            {
                Negocio.Menu.Grabar(menu);
                return Json(new Entidades.Respuesta());
            }
            catch (Exception ex)
            {
                return Json(new Entidades.Respuesta(ex.Message,501));
            }
        
        }

    }
}
