using Microsoft.AspNetCore.Mvc.Filters;

namespace InterviewTask.API.ActionFilters
{
    public class LogActionFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // implement request logging according requirements
            await next();

            // implement response logging according requirements
        }
    }
}