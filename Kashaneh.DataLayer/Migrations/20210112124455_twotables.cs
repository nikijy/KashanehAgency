using Microsoft.EntityFrameworkCore.Migrations;

namespace Kashaneh.DataLayer.Migrations
{
    public partial class twotables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Estates");

            migrationBuilder.AddColumn<int>(
                name: "LikedEstateId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EstateImageId",
                table: "Estates",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LikedEstateId",
                table: "Estates",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EstateImages",
                columns: table => new
                {
                    EstateImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstateId = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstateImages", x => x.EstateImageId);
                    table.ForeignKey(
                        name: "FK_EstateImages_Estates_EstateId",
                        column: x => x.EstateId,
                        principalTable: "Estates",
                        principalColumn: "EstateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LikedEstates",
                columns: table => new
                {
                    LikedEstateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    EstateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikedEstates", x => x.LikedEstateId);
                    table.ForeignKey(
                        name: "FK_LikedEstates_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estates_LikedEstateId",
                table: "Estates",
                column: "LikedEstateId");

            migrationBuilder.CreateIndex(
                name: "IX_EstateImages_EstateId",
                table: "EstateImages",
                column: "EstateId");

            migrationBuilder.CreateIndex(
                name: "IX_LikedEstates_UserId",
                table: "LikedEstates",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estates_LikedEstates_LikedEstateId",
                table: "Estates",
                column: "LikedEstateId",
                principalTable: "LikedEstates",
                principalColumn: "LikedEstateId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estates_LikedEstates_LikedEstateId",
                table: "Estates");

            migrationBuilder.DropTable(
                name: "EstateImages");

            migrationBuilder.DropTable(
                name: "LikedEstates");

            migrationBuilder.DropIndex(
                name: "IX_Estates_LikedEstateId",
                table: "Estates");

            migrationBuilder.DropColumn(
                name: "LikedEstateId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EstateImageId",
                table: "Estates");

            migrationBuilder.DropColumn(
                name: "LikedEstateId",
                table: "Estates");

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Estates",
                type: "nvarchar(600)",
                maxLength: 600,
                nullable: true);
        }
    }
}
