using Microsoft.EntityFrameworkCore.Migrations;

namespace plathora.Persistence.Migrations
{
    public partial class addbusinessidinadvertisement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_advertisementInfos_AspNetUsers_customerId",
                table: "advertisementInfos");

            migrationBuilder.DropIndex(
                name: "IX_advertisementInfos_customerId",
                table: "advertisementInfos");

            migrationBuilder.DropColumn(
                name: "customerId",
                table: "advertisementInfos");

            migrationBuilder.AddColumn<int>(
                name: "businessid",
                table: "advertisementInfos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_advertisementInfos_businessid",
                table: "advertisementInfos",
                column: "businessid");

            migrationBuilder.AddForeignKey(
                name: "FK_advertisementInfos_BusinessOwnerRegi_businessid",
                table: "advertisementInfos",
                column: "businessid",
                principalTable: "BusinessOwnerRegi",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_advertisementInfos_BusinessOwnerRegi_businessid",
                table: "advertisementInfos");

            migrationBuilder.DropIndex(
                name: "IX_advertisementInfos_businessid",
                table: "advertisementInfos");

            migrationBuilder.DropColumn(
                name: "businessid",
                table: "advertisementInfos");

            migrationBuilder.AddColumn<string>(
                name: "customerId",
                table: "advertisementInfos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_advertisementInfos_customerId",
                table: "advertisementInfos",
                column: "customerId");

            migrationBuilder.AddForeignKey(
                name: "FK_advertisementInfos_AspNetUsers_customerId",
                table: "advertisementInfos",
                column: "customerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
