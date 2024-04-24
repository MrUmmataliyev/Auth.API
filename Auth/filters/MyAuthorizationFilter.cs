using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace Auth.filters
{
    public class MyAuthorizationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {

        }
    }
}
