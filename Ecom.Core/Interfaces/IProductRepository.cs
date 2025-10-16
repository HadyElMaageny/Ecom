using Ecom.Core.DTO;
using Ecom.Core.Entities.Product;
using Ecom.Core.Sharing;

namespace Ecom.Core.Interfaces;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<ReturnProductDto> GetAllAsync(ProductParams productParams);
    Task<bool> AddAsync(AddProductDto addProductDto);
    Task<bool> UpdateAsync(UpdateProductDto updateProductDto);
    Task DeleteAsync(Product product);
}