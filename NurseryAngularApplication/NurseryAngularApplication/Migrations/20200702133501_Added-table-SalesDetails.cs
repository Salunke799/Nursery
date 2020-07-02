using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NurseryAngularApplication.Migrations
{
    public partial class AddedtableSalesDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SalesDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    NurseryId = table.Column<int>(nullable: true),
                    FarmerId = table.Column<int>(nullable: true),
                    ProductName = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: true),
                    Cost = table.Column<int>(nullable: true),
                    Total = table.Column<int>(nullable: true),
                    Advanceamount = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    GrandTotal = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesDetails_Farmers_FarmerId",
                        column: x => x.FarmerId,
                        principalTable: "Farmers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesDetails_Nurserys_NurseryId",
                        column: x => x.NurseryId,
                        principalTable: "Nurserys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalesDetails_FarmerId",
                table: "SalesDetails",
                column: "FarmerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesDetails_NurseryId",
                table: "SalesDetails",
                column: "NurseryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesDetails");
        }
    }
}
