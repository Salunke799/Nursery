using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NurseryAngularApplication.Migrations
{
    public partial class AddedtableFarmer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Farmers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    NurseryId = table.Column<int>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DateofBirth = table.Column<DateTime>(nullable: true),
                    ContactNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    VillageName = table.Column<string>(nullable: true),
                    GenderType = table.Column<int>(nullable: false),
                    EducationType = table.Column<int>(nullable: false),
                    StateId = table.Column<int>(nullable: true),
                    DistrictId = table.Column<int>(nullable: true),
                    TehsilId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farmers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Farmers_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Farmers_Nurserys_NurseryId",
                        column: x => x.NurseryId,
                        principalTable: "Nurserys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Farmers_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Farmers_Tehsils_TehsilId",
                        column: x => x.TehsilId,
                        principalTable: "Tehsils",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Farmers_DistrictId",
                table: "Farmers",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Farmers_NurseryId",
                table: "Farmers",
                column: "NurseryId");

            migrationBuilder.CreateIndex(
                name: "IX_Farmers_StateId",
                table: "Farmers",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Farmers_TehsilId",
                table: "Farmers",
                column: "TehsilId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Farmers");
        }
    }
}
