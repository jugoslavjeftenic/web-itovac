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
	public class CountriesController
	{
		[HttpPost]
		public string CreateState()
		{
			return $"Create a Country.";
		}

		[HttpGet]
		public string ReadAllStates()
		{
			return $"Read all the countries.";
		}

		[HttpGet("{id}")]
		public string ReadStateById(int id)
		{
			return $"Read Country with id: {id}.";
		}

		[HttpPut("{id}")]
		public string UpdateState(int id)
		{
			return $"Update Country with id: {id}.";
		}

		[HttpDelete("{id}")]
		public string DeleteState(int id)
		{
			return $"Delete Country with id: {id}.";
		}
	}
}
