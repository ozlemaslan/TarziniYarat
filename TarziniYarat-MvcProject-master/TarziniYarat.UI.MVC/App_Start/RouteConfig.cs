using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TarziniYarat.Model;

namespace TarziniYarat.UI.MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Home",
                url: "{controller}/{action}/{Username}/{PersonID}",
                defaults: new { controller = "Home", action = "Index", Username = UrlParameter.Optional, PersonID=UrlParameter.Optional },
                namespaces: new string[] { "TarziniYarat.UI.MVC.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "TarziniYarat.UI.MVC.Controllers" }
            );
        }
    }
}
