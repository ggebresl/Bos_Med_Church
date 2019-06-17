using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace EOTC.Boston.MedhaneAlem.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "Audio Operations",
               url: "{api}/Audio/{action}",
               defaults: new { controller = "Audio" }
           );
            routes.MapRoute(
              name: "Akuakuam Operations",
              url: "{api}/Akuakuam/{action}",
              defaults: new { controller = "Akuakuam" }
          );
            routes.MapRoute(
                name: "Kebero Operations",
                url: "{api}/Kebero/{action}",
                defaults: new { controller = "Kebero"}
            );
            routes.MapRoute(
               name: "Kidase Operations",
               url: "{api}/Kidase/{action}",
               defaults: new { controller = "Kidase" }
           );
            routes.MapRoute(
                name: "Mewaset Operations",
                url: "{api}/Mewaset/{action}",
                defaults: new { controller = "Mewaset" }
            );

            routes.MapRoute(
                name: "Mezmur Operations",
                url: "{api}/Mezmur/{action}",
                defaults: new { controller = "Mezmur"}
            );
            routes.MapRoute(
                name: "Video Operations",
                url: "{api}/Video/{action}",
                defaults: new { controller = "Video"}
            );
            routes.MapRoute(
                name: "Zmare Operations",
                url: "{api}/Zmare/{action}",
                defaults: new { controller = "Zmare" }
            );
            routes.MapRoute(
              name: "Default",
              url: "{api}/{controller}/{action}/{id}",
              defaults: new { controller = "Admin", action = "Index", id = UrlParameter.Optional }
            //defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
