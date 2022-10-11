using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoginSec.Migrations.ApplicationDb
{
    public partial class FinalModelClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Good_Allocations",
                columns: table => new
                {
                    GoodsAllocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoodsId = table.Column<int>(type: "int", nullable: false),
                    GoodsDonationGoodsId = table.Column<int>(type: "int", nullable: true),
                    DisasterId = table.Column<int>(type: "int", nullable: false),
                    NumItems = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Good_Allocations", x => x.GoodsAllocationId);
                    table.ForeignKey(
                        name: "FK_Good_Allocations_Disasters_DisasterId",
                        column: x => x.DisasterId,
                        principalTable: "Disasters",
                        principalColumn: "DisasterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Good_Allocations_GoodsDonations_GoodsDonationGoodsId",
                        column: x => x.GoodsDonationGoodsId,
                        principalTable: "GoodsDonations",
                        principalColumn: "GoodsId");
                });

            migrationBuilder.CreateTable(
                name: "PurchaseGoods",
                columns: table => new
                {
                    PurchaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemDescription = table.Column<string>(type: "nvarchar(75)", nullable: true),
                    PurchaseAmount = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    DisasterId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseGoods", x => x.PurchaseId);
                    table.ForeignKey(
                        name: "FK_PurchaseGoods_Disasters_DisasterId",
                        column: x => x.DisasterId,
                        principalTable: "Disasters",
                        principalColumn: "DisasterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Good_Allocations_DisasterId",
                table: "Good_Allocations",
                column: "DisasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Good_Allocations_GoodsDonationGoodsId",
                table: "Good_Allocations",
                column: "GoodsDonationGoodsId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseGoods_DisasterId",
                table: "PurchaseGoods",
                column: "DisasterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Good_Allocations");

            migrationBuilder.DropTable(
                name: "PurchaseGoods");
        }
    }
}
