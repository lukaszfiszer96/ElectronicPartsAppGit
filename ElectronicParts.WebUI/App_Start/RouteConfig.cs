using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ElectronicParts.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");



            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{category}/{resistance}",
                defaults: new { controller = "ElectronicPart", action = "List", category = UrlParameter.Optional, resistance = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: null,
                url: "{controller}/{action}/{ElectronicPartID}",
                defaults: new { controller = "ElectronicPart", action = "List", ElectronicPartID = UrlParameter.Optional}

            );
        }
    }
}
