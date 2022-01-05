﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace web_api
    {
    public static class WebApiConfig
        {
        public static void Register(HttpConfiguration config)
            {
            // Web API configuration and services

            var cors = new System.Web.Http.Cors.EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            }
        }
    }
