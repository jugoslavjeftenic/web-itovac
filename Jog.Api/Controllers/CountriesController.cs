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
		// Create
		[HttpPost]
		[AllowEmptyJsonBody]
		[Country_ValidateCreateCountryFilter]
		public IActionResult CreateCountry([FromBody] CountryModel country)
		{
			CountryRepository.AddCountry(country);

			return CreatedAtAction(nameof(GetCountryById),
				new { id = country.CountryId },
				country);
		}

		// Read
		[HttpGet]
		public IActionResult GetAllCountries()
		{
			return Ok(CountryRepository.GetAllCountries());
		}

		// Read
		[HttpGet("{id}")]
		[Country_ValidateCountryIDFilter]
		public IActionResult GetCountryById(int id)
		{
			return Ok(CountryRepository.GetCountryById(id));
		}

		// Update
		[HttpPut("{id}")]
		[AllowEmptyJsonBody]
		[Country_ValidateCountryIDFilter]
		[Country_ValidateUpdateCountryFilter]
		[Country_HandleUpdateExceptionsFilter]
		public IActionResult UpdateCountry(int id, CountryModel country)
		{
			CountryRepository.UpdateCountry(country);

			return NoContent();
		}

		// Delete
		[HttpDelete("{id}")]
		[Country_ValidateCountryIDFilter]
		public IActionResult DeleteCountry(int id)
		{
			var country = CountryRepository.GetCountryById(id);
			CountryRepository.DeleteCountry(id);

			return Ok(country);
		}
	}
}
