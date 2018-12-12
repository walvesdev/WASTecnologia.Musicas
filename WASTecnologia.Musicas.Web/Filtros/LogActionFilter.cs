using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WASTecnologia.Musicas.Web.Filtros
{
    public class LogActionFilter : FilterAttribute, IActionFilter
    {
        //Executa quando termina a execução da action
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //[Data/Hora]  Finalizou: [Controller]/[Action]
            string mensagem = string.Format("[{0}] Finalizou: {1}/{2}", DateTime.Now.ToString(),
                                                                        filterContext.RouteData.Values["Controller"].ToString(),
                                                                        filterContext.RouteData.Values["Action"].ToString());
            Debug.WriteLine(mensagem);
        }

        //Executa quando inicia a execução da action
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //[Data/Hora]  Iniciou: [Controller]/[Action]
            string mensagem = string.Format("[{0}] Iniciou: {1}/{2}", DateTime.Now.ToString(),
                                                                        filterContext.RouteData.Values["Controller"].ToString(),
                                                                        filterContext.RouteData.Values["Action"].ToString());
            Debug.WriteLine(mensagem);
        }
    }
}