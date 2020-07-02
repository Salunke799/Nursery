using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NurseryAngularApplication.Migrations
{
    public partial class AddedtableNurserys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nurserys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    NurseryName = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<string>(nullable: true),
                    VilageName = table.Column<string>(nullable: true),
                    StateId = table.Column<int>(nullable: true),
                    DistrictId = table.Column<int>(nullable: true),
                    TehsilId = table.Column<int>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EmailId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nurserys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nurserys_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Nurserys_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Nurserys_Tehsils_TehsilId",
                        column: x => x.TehsilId,
                        principalTable: "Tehsils",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nurserys_DistrictId",
                table: "Nurserys",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Nurserys_StateId",
                table: "Nurserys",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Nurserys_TehsilId",
                table: "Nurserys",
                column: "TehsilId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nurserys");
        }
    }
}
