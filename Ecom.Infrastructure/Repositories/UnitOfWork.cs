using AutoMapper;
using Ecom.Core.Interfaces;
using Ecom.Core.Services;
using Ecom.Infrastructure.Data;

namespace Ecom.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    public ICategoryRepository CategoryRepository { get; }
    public IPhotoRepository PhotoRepository { get; }
    public IProductRepository ProductRepository { get; }

    public UnitOfWork(AppDbContext  context, IMapper mapper, IImageManagementService imageManagementService)
    {
        CategoryRepository = new CategoryRepository(context);
        PhotoRepository = new PhotoRepository(context);
        ProductRepository = new ProductRepository(context, mapper, imageManagementService);
    }
}