using Microsoft.EntityFrameworkCore.Migrations;

namespace plathora.Persistence.Migrations
{
    public partial class addsectorcityandwebsiteurlinadvertisementInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "cityIds",
                table: "advertisementInfos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "sectorId",
                table: "advertisementInfos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "websiteUrl",
                table: "advertisementInfos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_advertisementInfos_sectorId",
                table: "advertisementInfos",
                column: "sectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_advertisementInfos_SectorRegistration_sectorId",
                table: "advertisementInfos",
                column: "sectorId",
                principalTable: "SectorRegistration",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_advertisementInfos_SectorRegistration_sectorId",
                table: "advertisementInfos");

            migrationBuilder.DropIndex(
                name: "IX_advertisementInfos_sectorId",
                table: "advertisementInfos");

            migrationBuilder.DropColumn(
                name: "cityIds",
                table: "advertisementInfos");

            migrationBuilder.DropColumn(
                name: "sectorId",
                table: "advertisementInfos");

            migrationBuilder.DropColumn(
                name: "websiteUrl",
                table: "advertisementInfos");
        }
    }
}
