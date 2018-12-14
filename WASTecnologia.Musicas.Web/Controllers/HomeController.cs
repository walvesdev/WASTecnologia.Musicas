using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WASTecnologia.Musicas.Web.Filtros;

namespace WASTecnologia.Musicas.Web.Controllers
{
    [LogResultFilter]
    [Authorize] 
    public class HomeController : Controller
    {
        [LogActionFilter]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "ADMIN")]
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