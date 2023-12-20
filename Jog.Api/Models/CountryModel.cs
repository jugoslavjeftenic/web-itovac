﻿using Jog.Api.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Jog.Api.Models
{
	public class CountryModel
	{
		public int CountryID { get; set; }

		[Required]
		[StringLength(3, ErrorMessage = "Dužina polja mora biti tačno 3 karaktera.")]
		public string Alpha { get; set; }

		[Required]
		public string Country { get; set; }

		[Required]
		public ContinentEnum Continent { get; set; }

		public CountryModel(int countryID, string alpha, string country, ContinentEnum continent)
		{
			CountryID = countryID;
			Alpha = alpha;
			Country = country;
			Continent = continent;
		}
	}
}
