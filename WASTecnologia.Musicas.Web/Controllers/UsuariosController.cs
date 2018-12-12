using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WASTecnologia.Musicas.Dominio;

namespace WASTecnologia.Musicas.Web.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        public ActionResult CriarUsuario()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CriarUsuario(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                 
            }
            return View(usuario);
        }
    }
}