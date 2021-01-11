using Microsoft.EntityFrameworkCore.Migrations;

namespace Kashaneh.DataLayer.Migrations
{
    public partial class changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubEstateType",
                table: "Estates",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Estates_SubEstateType",
                table: "Estates",
                column: "SubEstateType");

            migrationBuilder.AddForeignKey(
                name: "FK_Estates_EstateTypes_SubEstateType",
                table: "Estates",
                column: "SubEstateType",
                principalTable: "EstateTypes",
                principalColumn: "EstateTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estates_EstateTypes_SubEstateType",
                table: "Estates");

            migrationBuilder.DropIndex(
                name: "IX_Estates_SubEstateType",
                table: "Estates");

            migrationBuilder.DropColumn(
                name: "SubEstateType",
                table: "Estates");
        }
    }
}
