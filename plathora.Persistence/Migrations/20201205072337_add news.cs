﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace plathora.Persistence.Migrations
{
    public partial class addnews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(nullable: false),
                    img = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    isdeleted = table.Column<bool>(nullable: false),
                    isactive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "News");
        }
    }
}
