using Chirpel2._0_Common.Models.DataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Chirpel2._0_Common.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AuthenticatedAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            UserModel user = (UserModel)filterContext.HttpContext.Items["User"];

            if (user == null)
                filterContext.Result = new UnauthorizedObjectResult("user is not authorized") { StatusCode = 403 };
        }
    }
}
