using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WASTecnologia.Musicas.Web.Filtros
{
    public class LogResultFilter : FilterAttribute, IResultFilter
    {
        //excutado apos o termino do metodo abaixo
        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            //[Data/Hora]  Finalizou: [Controller]/[Action]
            string mensagem = string.Format("[{0}] Resultado: {1}/{2} | {3}", DateTime.Now.ToString(),
                                                                        filterContext.RouteData.Values["Controller"].ToString(),
                                                                        filterContext.RouteData.Values["Action"].ToString(),
                                                                        filterContext.Result.ToString());
            Debug.WriteLine(mensagem);
        }
        //processa os resultados gerados pela action(o return da action) após o termino do processamento(inicio e fim da action)
        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            //[Data/Hora]  Finalizou: [Controller]/[Action]
            string mensagem = string.Format("[{0}] Processando resultado: {1}/{2}", DateTime.Now.ToString(),
                                                                        filterContext.RouteData.Values["Controller"].ToString(),
                                                                        filterContext.RouteData.Values["Action"].ToString());
            Debug.WriteLine(mensagem);
        }
    }
}