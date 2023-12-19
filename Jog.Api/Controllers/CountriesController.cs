using Jog.Api.Filter;
using Jog.Api.Models;
using Jog.Api.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Jog.Api.Controllers
{
	// Post "/api/v1/countries"
	// Get "/api/v1/countries"
	// Get "/api/v1/countries/{id}"
	// Put "/api/v1/countries/{id}"
	// Delete "/api/v1/countries/{id}"


	[ApiController]
	[Route("api/v1/[controller]")]
	public class CountriesController : ControllerBase
	{
		[HttpPost]
		public IActionResult CreateState([FromBody] CountryModel country)
		{
			return Ok($"Create a Country.");
		}

		[HttpGet]
		public IActionResult ReadAllStates()
		{
			return Ok($"Read all the countries.");
		}

		[HttpGet("{id}")]
		[Country_ValidateCountryIDFilter]
		public IActionResult ReadStateById(int id)
		{
			return Ok(CountryRepository.GetCountryById(id));
		}

		[HttpPut("{id}")]
		public IActionResult UpdateState(int id)
		{
			return Ok($"Update Country with id: {id}.");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteState(int id)
		{
			return Ok($"Delete Country with id: {id}.");
		}
	}
}
