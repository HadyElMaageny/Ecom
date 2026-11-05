using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecom.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductPhotos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageName",
                value: "/Images/iPhone 15 Pro/iph1.jfif");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageName",
                value: "/Images/iPhone 15 Pro/iph2.jfif");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ImageName", "ProductId" },
                values: new object[] { "/Images/iPhone 15 Pro/iph3.jfif", 1 });

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ImageName", "ProductId" },
                values: new object[] { "/Images/Samsung QLED 4K TV/tv1.jfif", 2 });

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ImageName", "ProductId" },
                values: new object[] { "/Images/Samsung QLED 4K TV/tv2.jfif", 2 });

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ImageName", "ProductId" },
                values: new object[] { "/Images/Samsung QLED 4K TV/tv3.jfif", 2 });

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ImageName", "ProductId" },
                values: new object[] { "/Images/Men's Casual Shirt/shirt1.jpg", 3 });

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ImageName", "ProductId" },
                values: new object[] { "/Images/Men's Casual Shirt/shirt2.jpg", 3 });

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ImageName", "ProductId" },
                values: new object[] { "/Images/The Great Gatsby/book1.jpg", 4 });

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ImageName", "ProductId" },
                values: new object[] { "/Images/The Great Gatsby/book2.jpg", 4 });

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ImageName", "ProductId" },
                values: new object[] { "/Images/Office Desk/desk1.jpg", 5 });

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ImageName", "ProductId" },
                values: new object[] { "/Images/Office Desk/desk2.jpg", 5 });

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ImageName", "ProductId" },
                values: new object[] { "/Images/Yoga Mat/yoga1.jpg", 6 });

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ImageName", "ProductId" },
                values: new object[] { "/Images/Yoga Mat/yoga2.jpg", 6 });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "Id", "ImageName", "ProductId" },
                values: new object[,]
                {
                    { 15, "/Images/Vitamin C Serum/serum1.jpg", 7 },
                    { 16, "/Images/Vitamin C Serum/serum2.jpg", 7 },
                    { 17, "/Images/LEGO Classic Set/lego1.jpg", 8 },
                    { 18, "/Images/LEGO Classic Set/lego2.jpg", 8 },
                    { 19, "/Images/Organic Coffee Beans/coffee1.jpg", 9 },
                    { 20, "/Images/Organic Coffee Beans/coffee2.jpg", 9 },
                    { 21, "/Images/Car Phone Mount/mount1.jpg", 10 },
                    { 22, "/Images/Car Phone Mount/mount2.jpg", 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageName",
                value: "iphone15-1.jpg");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageName",
                value: "iphone15-2.jpg");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ImageName", "ProductId" },
                values: new object[] { "samsung-tv-1.jpg", 2 });

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ImageName", "ProductId" },
                values: new object[] { "shirt-1.jpg", 3 });

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ImageName", "ProductId" },
                values: new object[] { "shirt-2.jpg", 3 });

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ImageName", "ProductId" },
                values: new object[] { "gatsby-1.jpg", 4 });

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ImageName", "ProductId" },
                values: new object[] { "desk-1.jpg", 5 });

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ImageName", "ProductId" },
                values: new object[] { "desk-2.jpg", 5 });

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ImageName", "ProductId" },
                values: new object[] { "yogamat-1.jpg", 6 });

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ImageName", "ProductId" },
                values: new object[] { "serum-1.jpg", 7 });

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ImageName", "ProductId" },
                values: new object[] { "lego-1.jpg", 8 });

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ImageName", "ProductId" },
                values: new object[] { "lego-2.jpg", 8 });

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ImageName", "ProductId" },
                values: new object[] { "coffee-1.jpg", 9 });

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ImageName", "ProductId" },
                values: new object[] { "carmount-1.jpg", 10 });
        }
    }
}
