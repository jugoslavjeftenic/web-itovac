using Jog.Api.Models.Enums;

namespace Jog.Api.Models.Repositories
{
	public class CountryRepository
	{
		private static readonly List<CountryModel> _countries = [
			new CountryModel(0, "BIH", "Bosna i Hercegovina", ContinentEnum.Evropa),
			new CountryModel(1, "MNE", "Crna Gora", ContinentEnum.Evropa),
			new CountryModel(2, "HRV", "Hrvatska", ContinentEnum.Evropa),
			new CountryModel(3, "MKD", "Republika Makedonija", ContinentEnum.Evropa),
			new CountryModel(4, "SVN", "Slovenija", ContinentEnum.Evropa),
			new CountryModel(5, "SRB", "Srbija", ContinentEnum.Evropa)
		];
	}
}
