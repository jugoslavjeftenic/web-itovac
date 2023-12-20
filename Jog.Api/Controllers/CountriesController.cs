using Jog.Api.Filter;
using Jog.Api.Models;
using Jog.Api.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Jog.Api.Controllers
{
	//POST, GET
	//https://itovac.bsite.net/api/v1/countries
	//GET, PUT, DEL
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
		public IActionResult CreateCountry([FromBody] CountryModel country)
		{
			return Ok($"Create a Country.");
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
		public IActionResult UpdateCountry(int id)
		{
			return Ok($"Update Country with id: {id}.");
		}

		// Delete
		[HttpDelete("{id}")]
		public IActionResult DeleteCountry(int id)
		{
			return Ok($"Delete Country with id: {id}.");
		}
	}
}
