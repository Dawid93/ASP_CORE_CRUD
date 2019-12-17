using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Crud.DataAccess.Migrations
{
    public partial class addbeertype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Beers",
                keyColumn: "BeerId",
                keyValue: new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"));

            migrationBuilder.DeleteData(
                table: "Beers",
                keyColumn: "BeerId",
                keyValue: new Guid("2902b665-1190-4c70-9915-b9c2d7680450"));

            migrationBuilder.DeleteData(
                table: "Beers",
                keyColumn: "BeerId",
                keyValue: new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"));

            migrationBuilder.DeleteData(
                table: "Beers",
                keyColumn: "BeerId",
                keyValue: new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"));

            migrationBuilder.AddColumn<Guid>(
                name: "BeerTypeFK",
                table: "Beers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BeerTypes",
                columns: table => new
                {
                    BeerTypeId = table.Column<Guid>(nullable: false),
                    BeerTypeName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeerTypes", x => x.BeerTypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beers_BeerTypeFK",
                table: "Beers",
                column: "BeerTypeFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Beers_BeerTypes_BeerTypeFK",
                table: "Beers",
                column: "BeerTypeFK",
                principalTable: "BeerTypes",
                principalColumn: "BeerTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beers_BeerTypes_BeerTypeFK",
                table: "Beers");

            migrationBuilder.DropTable(
                name: "BeerTypes");

            migrationBuilder.DropIndex(
                name: "IX_Beers_BeerTypeFK",
                table: "Beers");

            migrationBuilder.DropColumn(
                name: "BeerTypeFK",
                table: "Beers");

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
    }
}
