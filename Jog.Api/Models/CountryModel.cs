using Jog.Api.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Jog.Api.Models
{
	public class CountryModel(int countryID, string alpha, string country, ContinentEnum continent)
	{
		public int CountryID { get; set; } = countryID;

		[Required]
		[StringLength(3, ErrorMessage = "Dužina polja mora biti tačno 3 karaktera.")]
		public string Alpha { get; set; } = alpha;

		[Required]
		public string Country { get; set; } = country;

		[Required]
		public ContinentEnum Continent { get; set; } = continent;
	}
}
