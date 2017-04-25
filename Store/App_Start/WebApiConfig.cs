﻿using Store.App_Start;
using Store.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Store
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Filters.Add(new ApiSecurityFilter());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}