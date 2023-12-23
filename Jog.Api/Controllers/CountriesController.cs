using Jog.Api.Data;
using Jog.Api.Filters.ActionFilters;
using Jog.Api.Filters.ExceptionFilters;
using Jog.Api.Filters.ResourceFilters;
using Jog.Api.Models;
using Jog.Api.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Jog.Api.Controllers
{
	//https://itovac.bsite.net/api/v1/countries
	//https://itovac.bsite.net/api/v1/countries/1
	// Post "/api/v1/countries"
	// Get "/api/v1/countries"
	// Get "/api/v1/countries/{id}"
	// Put "/api/v1/countries/{id}"
	// Delete "/api/v1/countries/{id}"

	[ApiController]
	[Route("api/v1/[controller]")]
	public class CountriesController : ControllerBase
	{
		private readonly ApplicationDbContext _db;

		public CountriesController(ApplicationDbContext db)
		{
			_db = db;
		}

		// Create
		[HttpPost]
		[AllowEmptyJsonBody]
		[TypeFilter(typeof(Country_ValidateCreateCountryFilterAttribute))]
		public IActionResult CreateCountry([FromBody] CountryModel country)
		{
			_db.Countries.Add(country);
			_db.SaveChanges();

			return CreatedAtAction(nameof(GetCountryById),
				new { id = country.CountryId },
				country);
		}

		// Read
		[HttpGet]
		public IActionResult GetAllCountries()
		{
			return Ok(_db.Countries.ToList());
		}

		// Read
		[HttpGet("{id}")]
		[TypeFilter(typeof(Country_ValidateCountryIdFilterAttribute))]
		public IActionResult GetCountryById(int id)
		{
			return Ok(HttpContext.Items["country"]);
		}

		// Update
		[HttpPut("{id}")]
		[AllowEmptyJsonBody]
		[TypeFilter(typeof(Country_ValidateCountryIdFilterAttribute))]
		[Country_ValidateUpdateCountryFilter]
		[TypeFilter(typeof(Country_HandleUpdateExceptionsFilterAttribute))]
		public IActionResult UpdateCountry(int id, CountryModel country)
		{
			var countryToUpdate = HttpContext.Items["country"] as CountryModel;
			countryToUpdate!.Alpha = country.Alpha;
			countryToUpdate.Country = country.Country;
			countryToUpdate.Continent = country.Continent;

			_db.SaveChanges();

			return NoContent();
		}

		// Delete
		[HttpDelete("{id}")]
		[TypeFilter(typeof(Country_ValidateCountryIdFilterAttribute))]
		public IActionResult DeleteCountry(int id)
		{
			var countryToDelete = HttpContext.Items["country"] as CountryModel;
			
			_db.Countries.Remove(countryToDelete!);
			_db.SaveChanges();

			return Ok(countryToDelete);
		}
	}
}
