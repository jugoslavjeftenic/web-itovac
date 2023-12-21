using Jog.Api.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Jog.Api.Models
{
	public class CountryModel
	{
		public int CountryId { get; set; }

		[Required(ErrorMessage = "Nedostaje Alpha kod države od 3 karaktera.")]
		[StringLength(3, ErrorMessage = "Dužina polja mora biti tačno 3 karaktera.")]
		public string? Alpha { get; set; }

		[Required(ErrorMessage = "Nedostaje naziv države.")]
		public string? Country { get; set; }

		[Required(ErrorMessage = "Nedostaje kontinent.")]
		public ContinentEnum? Continent { get; set; }
	}
}
