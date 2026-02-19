using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Univers.Data.Migrations
{
    /// <inheritdoc />
    public partial class Seed_Film : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "FilmId", "DateSortie", "Duree", "Etoile", "Titre" },
                values: new object[,]
                {
                    { 1, new DateOnly(2021, 7, 9), 121, (byte)3, "Black Widow" },
                    { 2, new DateOnly(2012, 5, 4), 98, (byte)5, "Avengers" },
                    { 3, new DateOnly(2003, 5, 3), 110, (byte)5, "Spiderman" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "FilmId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "FilmId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "FilmId",
                keyValue: 3);
        }
    }
}
