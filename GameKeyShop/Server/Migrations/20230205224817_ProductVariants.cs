using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameKeyShop.Server.Migrations
{
    /// <inheritdoc />
    public partial class ProductVariants : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductVariants",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    PlatformTypeId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OriginalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVariants", x => new { x.ProductId, x.PlatformTypeId });
                    table.ForeignKey(
                        name: "FK_ProductVariants_ProductTypes_PlatformTypeId",
                        column: x => x.PlatformTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductVariants_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Url" },
                values: new object[] { "Action", "action" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "Url" },
                values: new object[] { "Adventure", "adventure" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "Url" },
                values: new object[] { "RPG", "rpg" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Url" },
                values: new object[,]
                {
                    { 4, "Fantasy", "fantasy" },
                    { 5, "Open World", "open-world" },
                    { 6, "Sports", "sports" },
                    { 7, "Horror", "horror" },
                    { 8, "Strategy", "strategy" }
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "PC" },
                    { 2, "PSN" },
                    { 3, "Nintendo" },
                    { 4, "Xbox" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name" },
                values: new object[] { 8, "One of the most celebrated real-time strategy franchises is getting a long-awaited new installment! Become the key player in events that shaped human history with Relic Entertainment, World’s Edge and Xbox Game Studios’ latest release - Age of Empires IV. ", "https://cdn.cdkeys.com/700x700/media/catalog/product/s/s/ss_20d475d96c3a3dcb720103ce79e22d41df1aa8e0.1920x1080-min_26_.jpg", "Age of Empires 4" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name" },
                values: new object[] { 5, "Hogwarts Legacy is an open-world action RPG set in the world first introduced in the Harry Potter books. Embark on a journey through familiar and new locations as you explore and discover magical beasts, customize your character and craft potions, master spell casting, upgrade talents and become the wizard you want to be.", "https://cdn.cdkeys.com/700x700/media/catalog/product/c/u/cupheaddeliciouslast-1640043161876_3__2.jpg", "HOGWARTS LEGACY" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name" },
                values: new object[] { 6, "EA SPORTS™ FIFA 23 brings The World’s Game to the pitch, with HyperMotion2 Technology that delivers even more game-play realism, both the men’s and women’s FIFA World Cup™ coming to the game later in the the season, the addition of women’s club teams, cross-play features, and more. Experience unrivaled authenticity with over 19,000 players, 700+ teams, 100 stadiums, and over 30 leagues in FIFA 23.", "https://cdn.cdkeys.com/700x700/media/catalog/product/a/a/aaaa_5.jpg", "FIFA 23" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "Rise, Tarnished, and be guided by grace to brandish the power of the Elden Ring and become an Elden Lord in the Lands Between. In the Lands Between ruled by Queen Marika the Eternal, the Elden Ring, the source of the Erdtree, has been shattered.", "https://cdn.cdkeys.com/700x700/media/catalog/product/5/d/5de6658946177c5f23698932_24_.jpg", "ELDEN RING" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name" },
                values: new object[] { 8, "The Settlers combines a fresh take on the popular game-play mechanics of the series with a new spin. It offers a deep infrastructure and economy game-play, used to create and employ armies, to ultimately defeat opponents.", "https://cdn.cdkeys.com/700x700/media/catalog/product/s/a/sadasd.jpg", "THE SETTLERS: NEW ALLIES" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name" },
                values: new object[] { 2, "In Assassin's Creed Unity you will become the ultimate assassin and change the course of history forever.Experience the French Revolution first hand. You'll need to hone your skills and equipment to survive the chaos!", "https://cdn.cdkeys.com/700x700/media/catalog/product/h/e/hero_11_.jpg", "ASSASSIN'S CREED UNITY" });

            migrationBuilder.InsertData(
                table: "ProductVariants",
                columns: new[] { "PlatformTypeId", "ProductId", "OriginalPrice", "Price" },
                values: new object[,]
                {
                    { 1, 1, 18.99m, 14.99m },
                    { 4, 2, 46.99m, 44.29m },
                    { 2, 3, 12.99m, 11.99m },
                    { 1, 4, 33.99m, 25.99m },
                    { 3, 5, 44.99m, 34.99m },
                    { 4, 6, 23.99m, 21.99m }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 7, 4, "Explore distant lands, fight bigger and more awe-inspiring machines, and encounter astonishing new tribes as you return to the far-future, post-apocalyptic world of Horizon.", "https://cdn.cdkeys.com/700x700/media/catalog/product/h/e/header_10_15__1.jpg", "HORIZON FORBIDDEN WEST" },
                    { 8, 7, "Experience the emotional storytelling and unforgettable characters in The Last of Us, winner of over 200 Game of the Year awards, now rebuilt from the ground up for the PlayStation®5 console.", "https://cdn.cdkeys.com/700x700/media/catalog/product/r/o/roadwarden_5_.jpg", "HE LAST OF US PART I" }
                });

            migrationBuilder.InsertData(
                table: "ProductVariants",
                columns: new[] { "PlatformTypeId", "ProductId", "OriginalPrice", "Price" },
                values: new object[,]
                {
                    { 1, 7, 32.99m, 30.99m },
                    { 4, 7, 56.99m, 33.99m },
                    { 2, 8, 66.99m, 65.99m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_PlatformTypeId",
                table: "ProductVariants",
                column: "PlatformTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductVariants");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Url" },
                values: new object[] { "Category 1", "category1" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "Url" },
                values: new object[] { "Category 2", "category2" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "Url" },
                values: new object[] { "Category 3", "category3" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 1, "Description Prod_ 1", "https://cdn.pixabay.com/photo/2012/06/19/10/32/owl-50267_960_720.jpg", "Prod 1.", 1.3m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 2, "Description Prod_ 2", "https://cdn.pixabay.com/photo/2022/10/29/19/21/golden-eagle-7555959_960_720.jpg", "Prod 2.", 3.5m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 3, "Description Prod_ 3", "https://cdn.pixabay.com/photo/2023/01/12/05/32/duck-7713310_960_720.jpg", "Prod 3.", 2.4m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "Description Prod_ 4", "https://cdn.pixabay.com/photo/2023/01/26/18/09/zebra-7746719_960_720.jpg", "Prod 4.", 4.3m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 2, "Description Prod_ 5", "https://cdn.pixabay.com/photo/2016/01/02/16/53/lion-1118467_960_720.jpg", "Prod 5.", 2.66m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 3, "Description Prod_ 6", "https://cdn.pixabay.com/photo/2016/03/27/22/22/fox-1284512_960_720.jpg", "Prod 6.", 5.42m });
        }
    }
}
