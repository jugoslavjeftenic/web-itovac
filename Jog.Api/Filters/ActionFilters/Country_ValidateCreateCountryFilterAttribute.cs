using Jog.Api.Models.Repositories;
using Jog.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Jog.Api.Filters.ActionFilters
{
    public class Country_ValidateCreateCountryFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var country = context.ActionArguments["country"] as CountryModel;
            if (country == null)
            {
                context.ModelState.AddModelError("Country", "Država je null.");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
            else
            {
                var existingCountry = CountryRepository.GetCountryByProperties(country?.Alpha,
                    country?.Country, country?.Continent);
                if (existingCountry != null)
                {
                    context.ModelState.AddModelError("Country", "Država već postoji.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                }
            }
        }
    }
}
