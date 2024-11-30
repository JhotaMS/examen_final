using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace examen_final.Infrastructure.PostgreSql.Migrations
{
    /// <inheritdoc />
    public partial class v100 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "examen_finalMS");

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "examen_finalMS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    SecondName = table.Column<string>(type: "text", nullable: true),
                    SurName = table.Column<string>(type: "text", nullable: false),
                    SecondSurName = table.Column<string>(type: "text", nullable: true),
                    Enabled = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeatherForecasts",
                schema: "examen_finalMS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    TemperatureC = table.Column<int>(type: "integer", nullable: false),
                    Summary = table.Column<string>(type: "text", nullable: true),
                    Temperature = table.Column<int>(type: "integer", nullable: false),
                    Enabled = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherForecasts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeatherForecastsHistories",
                schema: "examen_finalMS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Proccess = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    CreatedByUser = table.Column<string>(type: "text", nullable: true),
                    LastModifiedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    LastModifiedByUser = table.Column<string>(type: "text", nullable: true),
                    Enabled = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherForecastsHistories", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users",
                schema: "examen_finalMS");

            migrationBuilder.DropTable(
                name: "WeatherForecasts",
                schema: "examen_finalMS");

            migrationBuilder.DropTable(
                name: "WeatherForecastsHistories",
                schema: "examen_finalMS");
        }
    }
}
