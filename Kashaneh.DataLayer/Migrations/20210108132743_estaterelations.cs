using Microsoft.EntityFrameworkCore.Migrations;

namespace Kashaneh.DataLayer.Migrations
{
    public partial class estaterelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Region",
                table: "Estates",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Estates_Region",
                table: "Estates",
                column: "Region");

            migrationBuilder.AddForeignKey(
                name: "FK_Estates_Cities_Region",
                table: "Estates",
                column: "Region",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estates_Cities_Region",
                table: "Estates");

            migrationBuilder.DropIndex(
                name: "IX_Estates_Region",
                table: "Estates");

            migrationBuilder.DropColumn(
                name: "Region",
                table: "Estates");
        }
    }
}
