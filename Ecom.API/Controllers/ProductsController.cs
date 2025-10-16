using AutoMapper;
using Ecom.API.Helper;
using Ecom.Core.DTO;
using Ecom.Core.Entities.Product;
using Ecom.Core.Interfaces;
using Ecom.Core.Sharing;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.API.Controllers
{
    public class ProductsController : BaseController
    {
        public ProductsController(IUnitOfWork work, IMapper mapper) : base(work, mapper)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] ProductParams productParams)
        {
            try
            {
                var products = await _work.ProductRepository.GetAllAsync(productParams);
                if (products is null)
                    return NotFound(ResponseAPI<IEnumerable<Product>>.NotFound("No products found"));
                
                return Ok(ResponseAPI<Pagination<ProductDto>>.Ok(new Pagination<ProductDto>(
                    productParams.PageNumber,
                    productParams.PageSize,
                    products.TotalCount,
                    products.Products
                )));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseAPI<IEnumerable<Product>>.Error(ex.Message));
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var product = await _work.ProductRepository.GetByIdAsync(id, x => x.Category, x => x.Photos);
                if (product is null)
                    return NotFound(ResponseAPI<Product>.NotFound($"Product not found with id {id}"));
                var result = _mapper.Map<ProductDto>(product);
                return Ok(ResponseAPI<ProductDto>.Ok(result));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseAPI<IEnumerable<Product>>.Error(ex.Message));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Store(AddProductDto addProductDto)
        {
            try
            {
                await _work.ProductRepository.AddAsync(addProductDto);
                return Ok(ResponseAPI<ProductDto>.Ok());
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseAPI<IEnumerable<Product>>.Error(ex.Message));
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductDto updateProductDto)
        {
            try
            {
                var existing = await _work.ProductRepository.GetByIdAsync(updateProductDto.Id);
                if (existing == null)
                    return NotFound(ResponseAPI<Product>.NotFound($"Product not found with id {updateProductDto.Id}"));
                await _work.ProductRepository.UpdateAsync(updateProductDto);
                return Ok(ResponseAPI<ProductDto>.Ok());
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseAPI<IEnumerable<Product>>.Error(ex.Message));
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Destroy(int id)
        {
            try
            {
                var existing = await _work.ProductRepository.GetByIdAsync(id, x => x.Category);
                if (existing == null)
                    return NotFound(ResponseAPI<Product>.NotFound($"Product not found with id {id}"));
                await _work.ProductRepository.DeleteAsync(existing);
                return Ok(ResponseAPI<ProductDto>.Ok());
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseAPI<IEnumerable<Product>>.Error(ex.Message));
            }
        }
    }
}