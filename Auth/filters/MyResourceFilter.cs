using Microsoft.AspNetCore.Mvc.Filters;

namespace Auth.filters
{
    public class MyResourceFilter : Attribute, IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
        }
    }
}
