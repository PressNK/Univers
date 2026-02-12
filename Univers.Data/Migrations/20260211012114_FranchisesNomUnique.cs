using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Univers.Data.Migrations
{
    /// <inheritdoc />
    public partial class FranchisesNomUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Franchises_Nom",
                table: "Franchises",
                column: "Nom",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Franchises_Nom",
                table: "Franchises");
        }
    }
}
