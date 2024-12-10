using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParcialPedriño.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AgregarLibros()
        {
            //ViewBag.Message = "Your application description page.";

            return RedirectToAction("Index", "Libros");
        }

        public ActionResult Categoria()
        {
            //ViewBag.Message = "Your contact page.";

            return RedirectToAction("Index", "Categorias");
        }
    }
}