using Ecom.Core.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecom.Infrastructure.Data.Config;

public class PhotoConfiguration : IEntityTypeConfiguration<Photo>
{
    public void Configure(EntityTypeBuilder<Photo> builder)
    {
        builder.HasData(
            new Photo { Id = 1, ImageName = "iphone15-1.jpg", ProductId = 1 },
            new Photo { Id = 2, ImageName = "iphone15-2.jpg", ProductId = 1 },
            new Photo { Id = 3, ImageName = "samsung-tv-1.jpg", ProductId = 2 },
            new Photo { Id = 4, ImageName = "shirt-1.jpg", ProductId = 3 },
            new Photo { Id = 5, ImageName = "shirt-2.jpg", ProductId = 3 },
            new Photo { Id = 6, ImageName = "gatsby-1.jpg", ProductId = 4 },
            new Photo { Id = 7, ImageName = "desk-1.jpg", ProductId = 5 },
            new Photo { Id = 8, ImageName = "desk-2.jpg", ProductId = 5 },
            new Photo { Id = 9, ImageName = "yogamat-1.jpg", ProductId = 6 },
            new Photo { Id = 10, ImageName = "serum-1.jpg", ProductId = 7 },
            new Photo { Id = 11, ImageName = "lego-1.jpg", ProductId = 8 },
            new Photo { Id = 12, ImageName = "lego-2.jpg", ProductId = 8 },
            new Photo { Id = 13, ImageName = "coffee-1.jpg", ProductId = 9 },
            new Photo { Id = 14, ImageName = "carmount-1.jpg", ProductId = 10 }
        );
    }
}