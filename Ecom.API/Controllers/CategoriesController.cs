using AutoMapper;
using Ecom.API.Helper;
using Ecom.Core.DTO;
using Ecom.Core.Entities.Product;
using Ecom.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.API.Controllers
{
    public class CategoriesController : BaseController
    {
        public CategoriesController(IUnitOfWork work, IMapper mapper) : base(work, mapper)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var categories = await _work.CategoryRepository.GetAllAsync();
                if (categories == null || !categories.Any())
                    return NotFound(ResponseAPI<IEnumerable<Category>>.NotFound("No categories found"));

                return Ok(ResponseAPI<IEnumerable<Category>>.Ok(categories));
            }
            catch (Exception e)
            {
                return BadRequest(ResponseAPI<IEnumerable<Category>>.Error(e.Message));
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var category = await _work.CategoryRepository.GetByIdAsync(id);
                if (category == null)
                    return NotFound(ResponseAPI<Category>.NotFound($"Category not found with id {id}"));

                return Ok(ResponseAPI<Category>.Ok(category));
            }
            catch (Exception e)
            {
                return BadRequest(ResponseAPI<Category>.Error(e.Message));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Store(CategoryDto categoryDto)
        {
            try
            {
                var category = _mapper.Map<Category>(categoryDto);
                await _work.CategoryRepository.AddAsync(category);

                return CreatedAtAction(nameof(GetById),
                    new { id = category.Id },
                    ResponseAPI<Category>.Created(category, "Category created successfully"));
            }
            catch (Exception e)
            {
                return BadRequest(ResponseAPI<Category>.Error(e.Message));
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateCategoryDto updateCategoryDto)
        {
            try
            {
                var existing = await _work.CategoryRepository.GetByIdAsync(id);
                if (existing == null)
                    return NotFound(ResponseAPI<Category>.NotFound($"Category not found with id {id}"));

                _mapper.Map(updateCategoryDto, existing); // Update existing entity
                await _work.CategoryRepository.UpdateAsync(existing);

                return Ok(ResponseAPI<Category>.Ok(existing, "Category updated successfully"));
            }
            catch (Exception e)
            {
                return BadRequest(ResponseAPI<Category>.Error(e.Message));
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Destroy(int id)
        {
            try
            {
                var existing = await _work.CategoryRepository.GetByIdAsync(id);
                if (existing == null)
                    return NotFound(ResponseAPI<Category>.NotFound($"Category not found with id {id}"));

                await _work.CategoryRepository.DeleteAsync(id);
                return Ok(ResponseAPI<object>.Ok(null, "Category deleted successfully"));
            }
            catch (Exception e)
            {
                return BadRequest(ResponseAPI<object>.Error(e.Message));
            }
        }
    }
}
