using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SolIntermedio.Utiles;
namespace SolIntermedio.ClienteMVC.Controllers
{
    
    public class HomeController : ControladoraBase
    {
        public ActionResult Index()
        {
            string algo = Extensor.Contar();
            int cantidad = algo.ContarCaracteres();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult NoAutorizado() {

            return View();
        }
    }
}