using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace FStudent
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "Login",
                routeTemplate: "api/{controller}/login",
                defaults: new { controller = "custom" }
            );
          /*  config.Routes.MapHttpRoute(
                name: "GetStudentByID",
                routeTemplate: "api/{controller}/GetStudentByID",
                defaults: new { controller = "custom" }
            );*/
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
        }
    }
}
