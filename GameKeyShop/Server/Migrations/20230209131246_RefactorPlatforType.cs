using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameKeyShop.Server.Migrations
{
    /// <inheritdoc />
    public partial class RefactorPlatforType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariants_ProductTypes_PlatformTypeId",
                table: "ProductVariants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTypes",
                table: "ProductTypes");

            migrationBuilder.RenameTable(
                name: "ProductTypes",
                newName: "PlatformTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlatformTypes",
                table: "PlatformTypes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    PlatformTypeId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => new { x.ProductId, x.PlatformTypeId, x.UserId });
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVariants_PlatformTypes_PlatformTypeId",
                table: "ProductVariants",
                column: "PlatformTypeId",
                principalTable: "PlatformTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariants_PlatformTypes_PlatformTypeId",
                table: "ProductVariants");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlatformTypes",
                table: "PlatformTypes");

            migrationBuilder.RenameTable(
                name: "PlatformTypes",
                newName: "ProductTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTypes",
                table: "ProductTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVariants_ProductTypes_PlatformTypeId",
                table: "ProductVariants",
                column: "PlatformTypeId",
                principalTable: "ProductTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
