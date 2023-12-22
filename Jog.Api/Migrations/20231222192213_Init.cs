using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Jog.Api.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Alpha = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Continent = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "Alpha", "Continent", "Country" },
                values: new object[,]
                {
                    { 1, "BIH", 3, "Bosna i Hercegovina" },
                    { 2, "MNE", 3, "Crna Gora" },
                    { 3, "HRV", 3, "Hrvatska" },
                    { 4, "MKD", 3, "Republika Makedonija" },
                    { 5, "SVN", 3, "Slovenija" },
                    { 6, "SRB", 3, "Srbija" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
