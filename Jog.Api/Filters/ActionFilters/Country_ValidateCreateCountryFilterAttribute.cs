using Jog.Api.Models.Repositories;
using Jog.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Jog.Api.Data;

namespace Jog.Api.Filters.ActionFilters
{
	public class Country_ValidateCreateCountryFilterAttribute : ActionFilterAttribute
	{
		private readonly ApplicationDbContext _db;

		public Country_ValidateCreateCountryFilterAttribute(ApplicationDbContext db)
		{
			_db = db;
		}

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
				var existingCountry = _db.Countries.FirstOrDefault(x =>
					!string.IsNullOrWhiteSpace(country.Alpha) &&
					!string.IsNullOrWhiteSpace(x.Alpha) &&
					x.Alpha.ToLower() == country.Alpha.ToLower() &&
					!string.IsNullOrWhiteSpace(country.Country) &&
					!string.IsNullOrWhiteSpace(x.Country) &&
					x.Country.ToLower() == country.Country.ToLower() &&
					country.Continent.HasValue &&
					x.Continent.HasValue &&
					country.Continent.Value == x.Continent.Value);
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
