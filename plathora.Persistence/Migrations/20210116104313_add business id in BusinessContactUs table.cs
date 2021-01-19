using Microsoft.EntityFrameworkCore.Migrations;

namespace plathora.Persistence.Migrations
{
    public partial class addbusinessidinBusinessContactUstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "businessid",
                table: "BusinessContactUs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BusinessContactUs_businessid",
                table: "BusinessContactUs",
                column: "businessid");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessContactUs_BusinessOwnerRegi_businessid",
                table: "BusinessContactUs",
                column: "businessid",
                principalTable: "BusinessOwnerRegi",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessContactUs_BusinessOwnerRegi_businessid",
                table: "BusinessContactUs");

            migrationBuilder.DropIndex(
                name: "IX_BusinessContactUs_businessid",
                table: "BusinessContactUs");

            migrationBuilder.DropColumn(
                name: "businessid",
                table: "BusinessContactUs");
        }
    }
}
