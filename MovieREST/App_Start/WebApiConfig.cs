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
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );

            config.Routes.MapHttpRoute(
                name: "NimelläApi",
                routeTemplate: "api/{controller}/name/{hakuehto}",
                defaults: new { hakuehto = RouteParameter.Optional }
                );

        }
    }
}
