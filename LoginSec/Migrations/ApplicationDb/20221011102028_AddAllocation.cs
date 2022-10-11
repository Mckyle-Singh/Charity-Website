using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoginSec.Migrations.ApplicationDb
{
    public partial class AddAllocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Monetary_Allocations",
                columns: table => new
                {
                    MonetaryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisasterId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monetary_Allocations", x => x.MonetaryId);
                    table.ForeignKey(
                        name: "FK_Monetary_Allocations_Disasters_DisasterId",
                        column: x => x.DisasterId,
                        principalTable: "Disasters",
                        principalColumn: "DisasterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Monetary_Allocations_DisasterId",
                table: "Monetary_Allocations",
                column: "DisasterId");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
                name: "Monetary_Allocations");
        }
    }
}
