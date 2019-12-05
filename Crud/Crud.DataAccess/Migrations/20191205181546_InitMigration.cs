using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Crud.DataAccess.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Beers",
                columns: table => new
                {
                    BeerId = table.Column<Guid>(nullable: false),
                    BeerName = table.Column<string>(nullable: false),
                    BeerDescription = table.Column<string>(maxLength: 1500, nullable: true),
                    BeerLabelImg = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beers", x => x.BeerId);
                });

            migrationBuilder.InsertData(
                table: "Beers",
                columns: new[] { "BeerId", "BeerDescription", "BeerLabelImg", "BeerName" },
                values: new object[,]
                {
                    { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "Lorem ipsum 1", null, "Żywiec" },
                    { new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), "Lorem ipsum 1", null, "Lech" },
                    { new Guid("2902b665-1190-4c70-9915-b9c2d7680450"), "Lorem ipsum 1", null, "Okocim" },
                    { new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"), "Lorem ipsum 1", null, "Specjal" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Beers");
        }
    }
}
