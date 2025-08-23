using AutoMapper;
using Ecom.API.Helper;
using Ecom.Core.DTO;
using Ecom.Core.Entities.Product;
using Ecom.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting.Hosting;

namespace Ecom.API.Controllers
{
    public class ProductsController : BaseController
    {
        public ProductsController(IUnitOfWork work, IMapper mapper) : base(work, mapper)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var products = await _work.ProductRepository.GetAllAsync(x => x.Category, x => x.Photos);
                var result = _mapper.Map<List<ProductDto>>(products);
                if (products is null)
                    return NotFound(ResponseAPI<IEnumerable<Product>>.NotFound("No products found"));
                return Ok(ResponseAPI<IEnumerable<ProductDto>>.Ok(result));
            }
            catch (Exception e)
            {
                return BadRequest(ResponseAPI<IEnumerable<Product>>.Error(e.Message));
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
            catch (Exception e)
            {
                return BadRequest(ResponseAPI<IEnumerable<Product>>.Error(e.Message));
            }
        }
    }
}