using Microsoft.AspNetCore.Mvc;

namespace RDG.Api.Controllers
{
	// Post "/api/v1/states"
	// Get "/api/v1/states"
	// Get "/api/v1/states/{id}"
	// Put "/api/v1/states/{id}"
	// Delete "/api/v1/states/{id}"

	[ApiController]
	[Route("api/v1/[controller]")]
	public class StatesController : ControllerBase
	{
		[HttpPost]
		public string CreateState()
		{
			return $"Create a State.";
		}

		[HttpGet]
		public string ReadAllStates()
		{
			return $"Read all the States.";
		}

		[HttpGet("{id}")]
		public string ReadStateById(int id)
		{
			return $"Read State with id: {id}.";
		}

		[HttpPut("{id}")]
		public string UpdateState(int id)
		{
			return $"Update State with id: {id}.";
		}

		[HttpDelete("{id}")]
		public string DeleteState(int id)
		{
			return $"Delete State with id: {id}.";
		}
	}
}
