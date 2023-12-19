using Jog.Api.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Jog.Api.Filter
{
	public class Country_ValidateCountryIDFilterAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			base.OnActionExecuting(context);

			var countryID = context.ActionArguments["id"] as int?;

			if (countryID.HasValue)
			{
				if (countryID.Value <= 0)
				{
					context.ModelState.AddModelError("CountryID", "ID Države nije validan.");
					var problemDetails = new ValidationProblemDetails(context.ModelState)
					{
						Status = StatusCodes.Status400BadRequest
					};
					context.Result = new BadRequestObjectResult(problemDetails);
				}
				else if (!CountryRepository.CountryExist(countryID.Value))
				{
					context.ModelState.AddModelError("CountryID", "Država ne postoji.");
					var problemDetails = new ValidationProblemDetails(context.ModelState)
					{
						Status = StatusCodes.Status404NotFound
					};
					context.Result = new NotFoundObjectResult(problemDetails);
				}
			}
		}
	}
}
