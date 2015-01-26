using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vrooms.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                null,
                "",
                new
                {
                    controller = "Book",
                    action = "List",
                    langId = (int?)null,
                    pageNum = 1
                }
            );

            routes.MapRoute(
                null,
                "Page{pageNum}",
                new
                {
                    controller = "Book",
                    action = "List",
                    langId = (int?)null
                },
                new
                {
                    pageNum = @"\d+"
                }
            );

            routes.MapRoute(
                null,
                "{langId}",
                new 
                { 
                    controller = "Book", 
                    action = "List", 
                    pageNum = 1 
                }
            );

            routes.MapRoute(
                null,
                "{langId}/Page{pageNum}",
                new 
                { 
                    controller = "Book", 
                    action = "List" 
                },
                new
                {
                    pageNum = @"\d+"
                }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Book", action = "List", id = UrlParameter.Optional }
            );
        }
    }
}
