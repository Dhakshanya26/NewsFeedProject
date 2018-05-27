using NewsFeed.Service.IServices;
using NewsFeed.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace NewsFeed.Service
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();
            container= UnityConfig.RegisterComponents(container);
            config.DependencyResolver = new UnityDependencyResolver(container);


            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
              name: "Getrssfeed",
              routeTemplate: "api/getrssfeeds",
              defaults: new { id = RouteParameter.Optional , controller = "BbcFeed", action = "GetRssFeed" }
          );
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
