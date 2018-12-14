using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(WASTecnologia.Musicas.Web.Startup))]

namespace WASTecnologia.Musicas.Web
{

    //Classe para configuração da Autenticação na Aplicação, configurações o Framework Owin
    

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Para obter mais informações sobre como configurar seu aplicativo, visite https://go.microsoft.com/fwlink/?LinkID=316888


            //Configuaração do Owin para trabalhar com autenticação baseada em Cookies
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                //Definindo tipo de autenticação
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,

                //Caminho para onde o usuario será redirecionado caso não esteja Autenticado.
                LoginPath = new PathString("/Usuarios/Login")
            });
        }
    }
}
