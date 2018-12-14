using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WASTecnologia.Musicas.AcessoDados.EF.Context;
using WASTecnologia.Musicas.Dominio;
using WASTecnologia.Musicas.Web.Identity;

namespace WASTecnologia.Musicas.Web.Controllers
{
    [AllowAnonymous] //permite que o recurso( pode ser usado em Action ou controller) seja acessado de forma anonima, sem login.
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
            if (ModelState.IsValid) //ModelState recebe os parametros, valores, e erros da requisição para ser validados
            {
                //Responsavel pelo armazenamento do usuario
                var userStore = new UserStore<IdentityUser>(new MusicasIdentityDbContext());

                //Responsavel pelo gerenciamento do usuario
                var userManager = new UserManager<IdentityUser>(userStore);


                var identityUser = new IdentityUser()
                {
                    UserName = usuario.Email,
                    Email = usuario.Email
                };
                IdentityResult resultado = userManager.Create(identityUser, usuario.Senha);
                if (resultado.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("erro_identity", resultado.Errors.First()); //Adicionando erro ao ModelState e enviando para View
                    return View(usuario);
                }
                
            }
            return View(usuario);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Usuario usuario)
        {
            if (ModelState.IsValid) //ModelState recebe os parametros, valores, e erros da requisição para ser validados
            {
                //Responsavel pelo armazenamento do usuario
                var userStore = new UserStore<IdentityUser>(new MusicasIdentityDbContext());

                //Responsavel pelo gerenciamento do usuario
                var userManager = new UserManager<IdentityUser>(userStore);

                //Verifica se o usuario existe
                var login = userManager.Find(usuario.Email, usuario.Senha);
                //se nao existir lança o erro
                if (login == null)
                {
                    ModelState.AddModelError("erro_identity", "Usuário e/ou senha incorretos!"); //Adicionando erro ao ModelState e enviando para View
                    return View(usuario);
                }
                //gerencia a autenticação, resgistra que o usuario esta autenticado  para o Owin 
                var authManager = HttpContext.GetOwinContext().Authentication;

                //depois de autenticado cria a uma identidade para o usuario no identity passando o tipo de autenticação suportada pela aplicação,
                //no caso o Cookie que foi configurado na classe Startup.cs
                var identity = userManager.CreateIdentity(login, DefaultAuthenticationTypes.ApplicationCookie);

                //com o objeto que representa o usuario logado(identity), agora solicitar que seja feita o processo de login pelo AuthenticationManager
                authManager.SignIn(new Microsoft.Owin.Security.AuthenticationProperties
                {
                    //diz que a autenticação nao é persistente, nao salva o cookie, nao tem o checkbox de relebra senha
                    IsPersistent = false

                }, identity);

                //redireciona para o index se a auticação tiver sucesso
                return RedirectToAction("Index", "Home");
            }
            return View(usuario);
        }

        [Authorize]
        public ActionResult Logout()
        {
            //gerencia a autenticação, resgistra que o usuario esta autenticado  para o Owin 
            var authManager = HttpContext.GetOwinContext().Authentication;

            //Efetua lougout do usuario que está registrado no contexto GetOwinContext em questão, cada usuario tem um contexto diferente.
            authManager.SignOut();


            return RedirectToAction("Index", "Home");
        }
    }
}