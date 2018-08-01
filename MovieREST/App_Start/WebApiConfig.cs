using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MovieREST
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {


            // New code
            config.EnableCors();

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}",
                defaults: new { id = RouteParameter.Optional }
                );
            config.Routes.MapHttpRoute(
                name: "WithIdApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );
            config.Routes.MapHttpRoute(
                name: "WithTitleApi",
                routeTemplate: "api/{controller}/title/{title}",
                defaults: new { title = RouteParameter.Optional }
                );

        }
    }
}
