using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Univers.Data.Migrations
{
    /// <inheritdoc />
    public partial class FranchiseContrainteAnneeCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "CK_Franchises_AnneeCreation",
                table: "Franchises",
                sql: "AnneeCreation > 1890");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Franchises_AnneeCreation",
                table: "Franchises");
        }
    }
}
