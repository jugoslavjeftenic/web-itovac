using Jog.Api.Models.Enums;

namespace Jog.Api.Models.Repositories
{
	public class CountryRepository
	{
		private static readonly List<CountryModel> _countries = new() {
			new CountryModel{
				CountryId= 1,
				Alpha= "BIH",
				Country= "Bosna i Hercegovina",
				Continent= ContinentEnum.Evropa
			},
			new CountryModel{
				CountryId= 2,
				Alpha= "MNE",
				Country= "Crna Gora",
				Continent= ContinentEnum.Evropa
			},
			new CountryModel{
				CountryId= 3,
				Alpha= "HRV",
				Country= "Hrvatska",
				Continent= ContinentEnum.Evropa
			},
			new CountryModel{
				CountryId= 4,
				Alpha= "MKD",
				Country= "Republika Makedonija",
				Continent= ContinentEnum.Evropa
			},
			new CountryModel{
				CountryId= 5,
				Alpha= "SVN",
				Country= "Slovenija",
				Continent= ContinentEnum.Evropa
			},
			new CountryModel{
				CountryId = 6,
				Alpha = "SRB",
				Country = "Srbija",
				Continent = ContinentEnum.Evropa
			}
		};

		public static bool CountryExist(int id)
		{
			return _countries.Any(x => x.CountryId == id);
		}

		public static void AddCountry(CountryModel country)
		{
			int maxId = _countries.Max(x => x.CountryId);
			country.CountryId = maxId + 1;

			_countries.Add(country);
		}

		public static List<CountryModel> GetAllCountries()
		{
			return _countries;
		}

		public static CountryModel? GetCountryById(int id)
		{
			return _countries.FirstOrDefault(x => x.CountryId == id);
		}

		public static CountryModel? GetCountryByProperties(string? alpha, string? country,
			ContinentEnum? continent)
		{
			return _countries.FirstOrDefault(x =>
				!string.IsNullOrWhiteSpace(alpha) &&
				!string.IsNullOrWhiteSpace(x.Alpha) &&
				x.Alpha.Equals(alpha, StringComparison.OrdinalIgnoreCase) &&
				!string.IsNullOrWhiteSpace(country) &&
				!string.IsNullOrWhiteSpace(x.Country) &&
				x.Country.Equals(country, StringComparison.OrdinalIgnoreCase) &&
				continent.HasValue &&
				x.Continent.HasValue &&
				continent.Value == x.Continent.Value);
		}

		public static void UpdateCountry(CountryModel country)
		{
			var countryToUpdate = _countries.First(x => x.CountryId == country.CountryId);
			countryToUpdate.Alpha = country.Alpha;
			countryToUpdate.Country = country.Country;
			countryToUpdate.Continent = country.Continent;
		}
	}
}
