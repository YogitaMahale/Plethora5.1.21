using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace plathora.Persistence.Migrations
{
    public partial class addcommissionDistributiontable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "commissionDistribution",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    commissiontype = table.Column<string>(nullable: true),
                    registrationtype = table.Column<string>(nullable: true),
                    affilateId = table.Column<string>(nullable: true),
                    fromAffilateId = table.Column<string>(nullable: true),
                    commissionamount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    createddate = table.Column<DateTime>(nullable: false),
                    isdeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_commissionDistribution", x => x.id);
                    table.ForeignKey(
                        name: "FK_commissionDistribution_AspNetUsers_affilateId",
                        column: x => x.affilateId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_commissionDistribution_AspNetUsers_fromAffilateId",
                        column: x => x.fromAffilateId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_commissionDistribution_affilateId",
                table: "commissionDistribution",
                column: "affilateId");

            migrationBuilder.CreateIndex(
                name: "IX_commissionDistribution_fromAffilateId",
                table: "commissionDistribution",
                column: "fromAffilateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "commissionDistribution");
        }
    }
}
