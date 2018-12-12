using System.Web;
using System.Web.Mvc;
using WASTecnologia.Musicas.Web.Filtros;

namespace WASTecnologia.Musicas.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            //Adiciona o Filtro globalmente em todos os controller
            //filters.Add(new LogActionFilter());
            //filters.Add(new LogResultFilter());
        }
    }
}
