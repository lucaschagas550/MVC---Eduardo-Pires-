using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Aula1AspNetMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //criando uma nova rota, a mais generia das rotas tem que ser a ultima ser escrita por padrão
            routes.MapRoute(
                name: "Secundaria",
                url: "{controller}/{action}/{id}/{nome}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, nome = UrlParameter.Optional } 
                // primeiro parametro nunca pode ser opcional, se não ele buscaria o id no nome e daria erro
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
