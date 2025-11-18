using AutoMapper;
using Ecom.Core.Entities;
using Ecom.Core.Interfaces;
using Ecom.Core.Services;
using Ecom.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;

namespace Ecom.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    public ICategoryRepository CategoryRepository { get; }
    public IPhotoRepository PhotoRepository { get; }
    public IProductRepository ProductRepository { get; }
    private readonly UserManager<AppUser>  _userManager;
    public IAuth Auth { get; }

    public UnitOfWork(AppDbContext  context, IMapper mapper, IImageManagementService imageManagementService, UserManager<AppUser> userManager)
    {
        _userManager = userManager;
        CategoryRepository = new CategoryRepository(context);
        PhotoRepository = new PhotoRepository(context);
        ProductRepository = new ProductRepository(context, mapper, imageManagementService);
        Auth = new AuthRepository(_userManager);
    }
}