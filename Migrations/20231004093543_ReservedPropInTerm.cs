using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MassageStudio.Migrations
{
    /// <inheritdoc />
    public partial class ReservedPropInTerm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Reserved",
                table: "freeTerms",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reserved",
                table: "freeTerms");
        }
    }
}
