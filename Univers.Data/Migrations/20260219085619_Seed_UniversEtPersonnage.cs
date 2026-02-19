using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Univers.Data.Migrations
{
    /// <inheritdoc />
    public partial class Seed_UniversEtPersonnage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Franchises",
                columns: new[] { "FranchiseId", "AnneeCreation", "Nom", "Proprietaire", "SiteWeb" },
                values: new object[,]
                {
                    { 1, (short)1939, "Marvel", "Disney", "https://www.marvel.com" },
                    { 2, (short)1934, "DC Comics", "Warner Bros", "https://www.dc.com" }
                });

            migrationBuilder.InsertData(
                table: "Personnages",
                columns: new[] { "PersonnageId", "DateNaissance", "EstVilain", "FranchiseId", "IdentiteReelle", "Nom" },
                values: new object[,]
                {
                    { 1, new DateOnly(1980, 12, 1), false, 1, "Peter Parker", "Spiderman" },
                    { 2, new DateOnly(1970, 11, 12), false, 1, "Tony Stark", "Iron Man" },
                    { 3, new DateOnly(1966, 3, 4), false, 2, "Bruce Wayne", "Batman" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Personnages",
                keyColumn: "PersonnageId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Personnages",
                keyColumn: "PersonnageId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Personnages",
                keyColumn: "PersonnageId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Franchises",
                keyColumn: "FranchiseId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Franchises",
                keyColumn: "FranchiseId",
                keyValue: 2);
        }
    }
}
