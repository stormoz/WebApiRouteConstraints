using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Routing;
using Newtonsoft.Json;

namespace RouteConstraints.RouteConstraints
{
    public class IsPartialUpdate<T> : IRouteConstraint
    {
        private readonly string _verb;
        private readonly Predicate<T> _predicate;

        public IsPartialUpdate(string verb, Predicate<T> predicate)
        {
            _verb = verb;
            _predicate = predicate;
        }

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            var request = HttpContext.Current.Request;

            if (!request.HttpMethod.Equals(_verb, StringComparison.InvariantCultureIgnoreCase))
                return false;

            var json = new StreamReader(request.InputStream).ReadToEnd();
            request.InputStream.Position = 0;

            if (string.IsNullOrEmpty(json))
                return false;

            var model = JsonConvert.DeserializeObject<T>(json);

            var matched = model != null && _predicate(model);
            return matched;
        }
    }
}