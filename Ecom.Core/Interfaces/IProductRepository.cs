using Ecom.Core.DTO;
using Ecom.Core.Entities.Product;

namespace Ecom.Core.Interfaces;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<bool> AddAsync(AddProductDto addProductDto);
    Task<bool> UpdateAsync(UpdateProductDto updateProductDto);
    Task DeleteAsync(Product product);
}