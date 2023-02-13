using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameKeyShop.Server.Migrations
{
    /// <inheritdoc />
    public partial class ProdPublisherAnddeveloper : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeveloperId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PublisherId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Developers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "TestDeveloper1" },
                    { 2, "TestDeveloper2" },
                    { 3, "TestDeveloper3" },
                    { 4, "TestDeveloper4" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DeveloperId", "PublisherId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DeveloperId", "PublisherId" },
                values: new object[] { 2, 3 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DeveloperId", "PublisherId" },
                values: new object[] { 4, 2 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DeveloperId", "PublisherId" },
                values: new object[] { 3, 3 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DeveloperId", "PublisherId" },
                values: new object[] { 1, 4 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DeveloperId", "PublisherId" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DeveloperId", "PublisherId" },
                values: new object[] { 3, 3 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DeveloperId", "PublisherId" },
                values: new object[] { 4, 2 });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "TestPublisher1" },
                    { 2, "TestPublisher2" },
                    { 3, "TestPublisher3" },
                    { 4, "TestPublisher4" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_DeveloperId",
                table: "Products",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_PublisherId",
                table: "Products",
                column: "PublisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Developers_DeveloperId",
                table: "Products",
                column: "DeveloperId",
                principalTable: "Developers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Publishers_PublisherId",
                table: "Products",
                column: "PublisherId",
                principalTable: "Publishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Developers_DeveloperId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Publishers_PublisherId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Developers");

            migrationBuilder.DropTable(
                name: "Publishers");

            migrationBuilder.DropIndex(
                name: "IX_Products_DeveloperId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_PublisherId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DeveloperId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PublisherId",
                table: "Products");
        }
    }
}
