using Ecom.Core.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecom.Infrastructure.Data.Config;

public class PhotoConfiguration : IEntityTypeConfiguration<Photo>
{
    public void Configure(EntityTypeBuilder<Photo> builder)
    {
        // Paths are relative to wwwroot and match the files shipped in wwwroot/Images/{ProductName}/
        builder.HasData(
            new Photo { Id = 1, ImageName = "/Images/iPhone 15 Pro/iph1.jfif", ProductId = 1 },
            new Photo { Id = 2, ImageName = "/Images/iPhone 15 Pro/iph2.jfif", ProductId = 1 },
            new Photo { Id = 3, ImageName = "/Images/iPhone 15 Pro/iph3.jfif", ProductId = 1 },
            new Photo { Id = 4, ImageName = "/Images/Samsung QLED 4K TV/tv1.jfif", ProductId = 2 },
            new Photo { Id = 5, ImageName = "/Images/Samsung QLED 4K TV/tv2.jfif", ProductId = 2 },
            new Photo { Id = 6, ImageName = "/Images/Samsung QLED 4K TV/tv3.jfif", ProductId = 2 },
            new Photo { Id = 7, ImageName = "/Images/Men's Casual Shirt/shirt1.jpg", ProductId = 3 },
            new Photo { Id = 8, ImageName = "/Images/Men's Casual Shirt/shirt2.jpg", ProductId = 3 },
            new Photo { Id = 9, ImageName = "/Images/The Great Gatsby/book1.jpg", ProductId = 4 },
            new Photo { Id = 10, ImageName = "/Images/The Great Gatsby/book2.jpg", ProductId = 4 },
            new Photo { Id = 11, ImageName = "/Images/Office Desk/desk1.jpg", ProductId = 5 },
            new Photo { Id = 12, ImageName = "/Images/Office Desk/desk2.jpg", ProductId = 5 },
            new Photo { Id = 13, ImageName = "/Images/Yoga Mat/yoga1.jpg", ProductId = 6 },
            new Photo { Id = 14, ImageName = "/Images/Yoga Mat/yoga2.jpg", ProductId = 6 },
            new Photo { Id = 15, ImageName = "/Images/Vitamin C Serum/serum1.jpg", ProductId = 7 },
            new Photo { Id = 16, ImageName = "/Images/Vitamin C Serum/serum2.jpg", ProductId = 7 },
            new Photo { Id = 17, ImageName = "/Images/LEGO Classic Set/lego1.jpg", ProductId = 8 },
            new Photo { Id = 18, ImageName = "/Images/LEGO Classic Set/lego2.jpg", ProductId = 8 },
            new Photo { Id = 19, ImageName = "/Images/Organic Coffee Beans/coffee1.jpg", ProductId = 9 },
            new Photo { Id = 20, ImageName = "/Images/Organic Coffee Beans/coffee2.jpg", ProductId = 9 },
            new Photo { Id = 21, ImageName = "/Images/Car Phone Mount/mount1.jpg", ProductId = 10 },
            new Photo { Id = 22, ImageName = "/Images/Car Phone Mount/mount2.jpg", ProductId = 10 }
        );
    }
}
