using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using RouteConstraints.Models;
using RouteConstraints.RouteConstraints;

namespace RouteConstraints
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            const string verbUsedAsPatch = "PUT";

            config.Routes.MapHttpRoute(
                "ModelEntityPatch",
                "api/values/{id}",
                new { controller = "Values", action = "Patch" },
                new { foo = new IsPartialUpdate<MyViewModel>(verbUsedAsPatch, m => m.Name == null) }
            );

            config.Routes.MapHttpRoute(
                "ModelEntityPut",
                "api/values/{id}",
                new { controller = "Values", action = "Put" },
                new { foo = new IsVerbConstraint(verbUsedAsPatch) }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.EnableSystemDiagnosticsTracing();
        }
    }
}
