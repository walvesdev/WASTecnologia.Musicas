using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WASTecnologia.Musicas.Web.Filtros;

namespace WASTecnologia.Musicas.Web.Controllers
{
    [LogResultFilter]
    public class HomeController : Controller
    {
        [LogActionFilter]
        public ActionResult Index()
        {
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
    }
}