using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
namespace EducationalPlatform1._0
{
    public class AuthConstraint : IRouteConstraint
    {
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            bool isAuthenticated = httpContext.User.Identity.IsAuthenticated;

            // Adjust the default action based on authentication status
            if (isAuthenticated)
            {
                // If user is authenticated, set the default action to "Months"
                values["action"] = "Months";
            }
            else
            {
                // If user is not authenticated, keep the default action as "Welcome"
                values["action"] = "Welcome";
            }

            return true; // Always return true as this constraint is just for setting the default action
        }
    }
}


