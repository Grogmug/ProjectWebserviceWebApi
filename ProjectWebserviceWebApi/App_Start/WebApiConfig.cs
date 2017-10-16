﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ProjectWebserviceWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "default",
                routeTemplate: "api/{controller}/{name}",
                defaults: new { name = RouteParameter.Optional }
            );

            //config.Routes.MapHttpRoute(
            //     name: "GetLogById",
            //     routeTemplate: "api/{controller}/{action}/{id}",
            //     defaults: new { id = RouteParameter.Optional }
            // );
        }
    }
}
