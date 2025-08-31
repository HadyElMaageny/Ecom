using Ecom.Core.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecom.Infrastructure.Data.Config;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Description).IsRequired().HasMaxLength(200);
        builder.Property(x => x.NewPrice).HasColumnType("decimal(18,2)");
        builder.HasData(
            new Product
            {
                Id = 1,
                Name = "iPhone 15 Pro",
                Description = "Latest Apple smartphone with A17 Pro chip and titanium design",
                NewPrice = 999.99m,
                CategoryId = 1 // Electronics
            },
            new Product
            {
                Id = 2,
                Name = "Samsung QLED 4K TV",
                Description = "55-inch 4K QLED Smart TV with Quantum HDR",
                NewPrice = 899.99m,
                CategoryId = 1 // Electronics
            },
            new Product
            {
                Id = 3,
                Name = "Men's Casual Shirt",
                Description = "100% Cotton casual shirt for men, available in multiple colors",
                NewPrice = 39.99m,
                CategoryId = 2 // Clothing
            },
            new Product
            {
                Id = 4,
                Name = "The Great Gatsby",
                Description = "Classic novel by F. Scott Fitzgerald",
                NewPrice = 12.99m,
                CategoryId = 3 // Books
            },
            new Product
            {
                Id = 5,
                Name = "Office Desk",
                Description = "Modern office desk with built-in cable management",
                NewPrice = 249.99m,
                CategoryId = 4 // Home & Garden
            },
            new Product
            {
                Id = 6,
                Name = "Yoga Mat",
                Description = "Eco-friendly yoga mat with non-slip surface",
                NewPrice = 29.99m,
                CategoryId = 5 // Sports & Outdoors
            },
            new Product
            {
                Id = 7,
                Name = "Vitamin C Serum",
                Description = "Anti-aging facial serum with vitamin C and hyaluronic acid",
                NewPrice = 24.99m,
                CategoryId = 6 // Beauty & Personal Care
            },
            new Product
            {
                Id = 8,
                Name = "LEGO Classic Set",
                Description = "Creative brick box with 790 pieces for endless building possibilities",
                NewPrice = 49.99m,
                CategoryId = 7 // Toys & Games
            },
            new Product
            {
                Id = 9,
                Name = "Organic Coffee Beans",
                Description = "Premium organic Arabica coffee beans, medium roast",
                NewPrice = 14.99m,
                CategoryId = 8 // Food & Beverages
            },
            new Product
            {
                Id = 10,
                Name = "Car Phone Mount",
                Description = "Universal smartphone car holder with wireless charging",
                NewPrice = 34.99m,
                CategoryId = 10 // Automotive
            }
        );
    }
}