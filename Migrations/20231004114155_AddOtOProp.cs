using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MassageStudio.Migrations
{
    /// <inheritdoc />
    public partial class AddOtOProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "termId",
                table: "massages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_massages_termId",
                table: "massages",
                column: "termId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_massages_freeTerms_termId",
                table: "massages",
                column: "termId",
                principalTable: "freeTerms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_massages_freeTerms_termId",
                table: "massages");

            migrationBuilder.DropIndex(
                name: "IX_massages_termId",
                table: "massages");

            migrationBuilder.DropColumn(
                name: "termId",
                table: "massages");
        }
    }
}
