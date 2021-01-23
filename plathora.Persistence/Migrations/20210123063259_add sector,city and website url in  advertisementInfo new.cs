using Microsoft.EntityFrameworkCore.Migrations;

namespace plathora.Persistence.Migrations
{
    public partial class addsectorcityandwebsiteurlinadvertisementInfonew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "websiteUrl",
                table: "advertisementInfos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "websiteUrl",
                table: "advertisementInfos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
