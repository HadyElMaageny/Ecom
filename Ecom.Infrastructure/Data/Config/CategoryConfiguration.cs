using Ecom.Core.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecom.Infrastructure.Data.Config;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Id).IsRequired();
        builder.HasData(
            new Category
            {
                Id = 1,
                Name = "Electronics",
                Description = "Electronic devices and gadgets including smartphones, laptops, and accessories"
            },
            new Category
            {
                Id = 2,
                Name = "Clothing",
                Description = "Apparel and fashion items for men, women, and children"
            },
            new Category
            {
                Id = 3,
                Name = "Books",
                Description = "Physical and digital books across various genres and categories"
            },
            new Category
            {
                Id = 4,
                Name = "Home & Garden",
                Description = "Furniture, decor, and gardening supplies for home improvement"
            },
            new Category
            {
                Id = 5,
                Name = "Sports & Outdoors",
                Description = "Sports equipment, outdoor gear, and fitness accessories"
            },
            new Category
            {
                Id = 6,
                Name = "Beauty & Personal Care",
                Description = "Cosmetics, skincare, haircare, and personal hygiene products"
            },
            new Category
            {
                Id = 7,
                Name = "Toys & Games",
                Description = "Children's toys, board games, and entertainment products"
            },
            new Category
            {
                Id = 8,
                Name = "Food & Beverages",
                Description = "Groceries, snacks, beverages, and culinary ingredients"
            },
            new Category
            {
                Id = 9,
                Name = "Health & Wellness",
                Description = "Healthcare products, supplements, and wellness equipment"
            },
            new Category
            {
                Id = 10,
                Name = "Automotive",
                Description = "Vehicle parts, accessories, and automotive care products"
            }
        );
    }
}