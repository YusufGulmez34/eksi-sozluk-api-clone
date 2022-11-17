using EksiSozlukAPI.Application.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EksiSozlukAPI.Infrastructure.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Where(x => x.Value.Errors.Any())
                                  .ToDictionary(e => e.Key, e => e.Value.Errors.Select(e => e.ErrorMessage))
                                  .ToArray();
                var data = new ResponseData<KeyValuePair<string, IEnumerable<string>>[]>(errors, false, "Expected errors");
                context.Result = new BadRequestObjectResult(data);
                return;
            }
            await next();
        }
    }
}
