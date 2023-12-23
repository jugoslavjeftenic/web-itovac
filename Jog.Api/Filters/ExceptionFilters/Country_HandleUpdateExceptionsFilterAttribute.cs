using Jog.Api.Data;
using Jog.Api.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Jog.Api.Filters.ExceptionFilters
{
	public class Country_HandleUpdateExceptionsFilterAttribute : ExceptionFilterAttribute
	{
		private readonly ApplicationDbContext _db;

		public Country_HandleUpdateExceptionsFilterAttribute(ApplicationDbContext db)
		{
			_db = db;
		}

		public override void OnException(ExceptionContext context)
		{
			base.OnException(context);

			var strCountryId = context.RouteData.Values["id"] as string;
			if (int.TryParse(strCountryId, out var countryId))
			{
				if (_db.Countries.FirstOrDefault(x => x.CountryId == countryId) == null)
				{
					context.ModelState.AddModelError("CountryID", "Država više ne postoji.");
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
