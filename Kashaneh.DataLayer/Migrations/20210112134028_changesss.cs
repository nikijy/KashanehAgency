using Microsoft.EntityFrameworkCore.Migrations;

namespace Kashaneh.DataLayer.Migrations
{
    public partial class changesss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstateImageId",
                table: "Estates");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstateImageId",
                table: "Estates",
                type: "int",
                nullable: true);
        }
    }
}
