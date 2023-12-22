using Jog.Api.Models;
using Jog.Api.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace Jog.Api.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{

		}

		public DbSet<CountryModel> Countries { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// data seeding
			modelBuilder.Entity<CountryModel>().HasData(
				new CountryModel
				{
					CountryId = 1,
					Alpha = "BIH",
					Country = "Bosna i Hercegovina",
					Continent = ContinentEnum.Evropa
				},
				new CountryModel
				{
					CountryId = 2,
					Alpha = "MNE",
					Country = "Crna Gora",
					Continent = ContinentEnum.Evropa
				},
				new CountryModel
				{
					CountryId = 3,
					Alpha = "HRV",
					Country = "Hrvatska",
					Continent = ContinentEnum.Evropa
				},
				new CountryModel
				{
					CountryId = 4,
					Alpha = "MKD",
					Country = "Republika Makedonija",
					Continent = ContinentEnum.Evropa
				},
				new CountryModel
				{
					CountryId = 5,
					Alpha = "SVN",
					Country = "Slovenija",
					Continent = ContinentEnum.Evropa
				},
				new CountryModel
				{
					CountryId = 6,
					Alpha = "SRB",
					Country = "Srbija",
					Continent = ContinentEnum.Evropa
				}
			);
		}
	}
}
