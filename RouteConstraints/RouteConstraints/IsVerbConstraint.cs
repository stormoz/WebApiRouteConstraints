using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace RouteConstraints.RouteConstraints
{
    public class IsVerbConstraint : IRouteConstraint
    {
        private readonly string _verb;

        public IsVerbConstraint(string verb)
        {
            _verb = verb;
        }

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            return HttpContext.Current.Request.HttpMethod.Equals(_verb, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}