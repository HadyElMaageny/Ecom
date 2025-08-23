using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecom.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Electronic devices and gadgets including smartphones, laptops, and accessories", "Electronics" },
                    { 2, "Apparel and fashion items for men, women, and children", "Clothing" },
                    { 3, "Physical and digital books across various genres and categories", "Books" },
                    { 4, "Furniture, decor, and gardening supplies for home improvement", "Home & Garden" },
                    { 5, "Sports equipment, outdoor gear, and fitness accessories", "Sports & Outdoors" },
                    { 6, "Cosmetics, skincare, haircare, and personal hygiene products", "Beauty & Personal Care" },
                    { 7, "Children's toys, board games, and entertainment products", "Toys & Games" },
                    { 8, "Groceries, snacks, beverages, and culinary ingredients", "Food & Beverages" },
                    { 9, "Healthcare products, supplements, and wellness equipment", "Health & Wellness" },
                    { 10, "Vehicle parts, accessories, and automotive care products", "Automotive" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Latest Apple smartphone with A17 Pro chip and titanium design", "iPhone 15 Pro", 999.99m },
                    { 2, 1, "55-inch 4K QLED Smart TV with Quantum HDR", "Samsung QLED 4K TV", 899.99m },
                    { 3, 2, "100% Cotton casual shirt for men, available in multiple colors", "Men's Casual Shirt", 39.99m },
                    { 4, 3, "Classic novel by F. Scott Fitzgerald", "The Great Gatsby", 12.99m },
                    { 5, 4, "Modern office desk with built-in cable management", "Office Desk", 249.99m },
                    { 6, 5, "Eco-friendly yoga mat with non-slip surface", "Yoga Mat", 29.99m },
                    { 7, 6, "Anti-aging facial serum with vitamin C and hyaluronic acid", "Vitamin C Serum", 24.99m },
                    { 8, 7, "Creative brick box with 790 pieces for endless building possibilities", "LEGO Classic Set", 49.99m },
                    { 9, 8, "Premium organic Arabica coffee beans, medium roast", "Organic Coffee Beans", 14.99m },
                    { 10, 10, "Universal smartphone car holder with wireless charging", "Car Phone Mount", 34.99m }
                });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "Id", "ImageName", "ProductId" },
                values: new object[,]
                {
                    { 1, "iphone15-1.jpg", 1 },
                    { 2, "iphone15-2.jpg", 1 },
                    { 3, "samsung-tv-1.jpg", 2 },
                    { 4, "shirt-1.jpg", 3 },
                    { 5, "shirt-2.jpg", 3 },
                    { 6, "gatsby-1.jpg", 4 },
                    { 7, "desk-1.jpg", 5 },
                    { 8, "desk-2.jpg", 5 },
                    { 9, "yogamat-1.jpg", 6 },
                    { 10, "serum-1.jpg", 7 },
                    { 11, "lego-1.jpg", 8 },
                    { 12, "lego-2.jpg", 8 },
                    { 13, "coffee-1.jpg", 9 },
                    { 14, "carmount-1.jpg", 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_ProductId",
                table: "Photos",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
