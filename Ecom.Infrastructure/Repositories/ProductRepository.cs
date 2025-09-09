using AutoMapper;
using Ecom.Core.DTO;
using Ecom.Core.Entities.Product;
using Ecom.Core.Interfaces;
using Ecom.Core.Services;
using Ecom.Core.Sharing;
using Ecom.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecom.Infrastructure.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    private readonly IMapper _mapper;
    private readonly AppDbContext _context;
    private readonly IImageManagementService _imageManagementService;

    public ProductRepository(AppDbContext context, IMapper mapper, IImageManagementService imageManagementService) :
        base(context)
    {
        _context = context;
        _mapper = mapper;
        _imageManagementService = imageManagementService;
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync(ProductParams productParams)
    {
        var query = _context.Products
            .Include(p => p.Category)
            .Include(p => p.Photos)
            .AsNoTracking();

        if (productParams.CategoryId != null)
            query = query.Where(p => p.CategoryId == productParams.CategoryId);

        if (!string.IsNullOrEmpty(productParams.Search))
        {
            var searchWords = productParams.Search.Split(' ');
            query = query.Where(p => searchWords.Any(word =>
                p.Name.ToLower().Contains(word.ToLower()) ||
                p.Description.ToLower().Contains(word.ToLower())
            ));
        }


        if (!string.IsNullOrEmpty(productParams.Sort))
        {
            query = productParams.Sort switch
            {
                "PriceAsc" => query.OrderBy(q => q.NewPrice),
                "PriceDesc" => query.OrderByDescending(q => q.NewPrice),
                _ => query.OrderBy(q => q.Name)
            };
        }

        var products = await query
            .Skip((productParams.PageNumber - 1) * productParams.PageSize)
            .Take(productParams.PageSize)
            .ToListAsync();
        var result = _mapper.Map<List<ProductDto>>(products);
        return result;
    }

    public async Task<bool> AddAsync(AddProductDto addProductDto)
    {
        if (addProductDto == null) return false;

        var product = _mapper.Map<Product>(addProductDto);
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        var imagePaths = await _imageManagementService.AddImageAsync(addProductDto.Photos, product.Name);
        var photo = imagePaths.Select(path => new Photo
        {
            ImageName = path,
            ProductId = product.Id,
        }).ToList();
        await _context.Photos.AddRangeAsync(photo);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateAsync(UpdateProductDto updateProductDto)
    {
        if (updateProductDto == null) return false;
        var existingProduct = await _context.Products
            .Include(p => p.Category)
            .Include(p => p.Photos)
            .FirstOrDefaultAsync(p => p.Id == updateProductDto.Id);
        var product = _mapper.Map(updateProductDto, existingProduct);
        var existingPhotos = await _context.Photos.Where(p => p.ProductId == updateProductDto.Id).ToListAsync();
        foreach (var item in existingPhotos)
        {
            _imageManagementService.DeleteImageAsync(item.ImageName);
        }

        _context.Photos.RemoveRange(existingPhotos);

        var imagePaths = await _imageManagementService.AddImageAsync(updateProductDto.Photos, updateProductDto.Name);
        var photo = imagePaths.Select(path => new Photo
        {
            ImageName = path,
            ProductId = updateProductDto.Id,
        }).ToList();
        await _context.Photos.AddRangeAsync(photo);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task DeleteAsync(Product product)
    {
        var photoes = await _context.Photos.Where(p => p.ProductId == product.Id).ToListAsync();
        foreach (var photo in photoes)
        {
            _imageManagementService.DeleteImageAsync(photo.ImageName);
        }

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }
}