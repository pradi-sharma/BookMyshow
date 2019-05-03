using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BookMyshow
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
           // routes.MapRoute(
           //    name: "TimingsByTheatre",
           //    url: "UserHome/TimingsByTheatre/{slotId}/{theatreId}/{movieId}",
           //    defaults: new { controller = "UserHome", action = "TimingsByTheatre", slotId = UrlParameter.Optional, theatreId= UrlParameter.Optional, movieId= UrlParameter.Optional }
           //);
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "UserHome", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
