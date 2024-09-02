using AutoMapper;
using LibraryManagementSystemBackend.Interfaces;
using LibraryManagementSystemBackend.Models;
using LibraryManagementSystemBackend.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace LibraryManagementSystemBackend.Controllers
{
    [ApiController]
    [Route("api/v1/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService<Category> _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService<Category> categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryService.GetAllAsync();
            var categoriesResponse = categories.Select(_mapper.Map<CategoryResponseDto>);
            return Ok(categoriesResponse);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            var categoryResponse = _mapper.Map<CategoryResponseDto>(category);
            return Ok(categoryResponse);
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> AddCategory(CategoryRequestDto categoryRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = _mapper.Map<Category>(categoryRequestDto);
            var createdCategory = await _categoryService.AddAsync(category);
            var categoryRes = _mapper.Map<CategoryResponseDto>(createdCategory);
            return Ok(categoryRes);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> UpdateCategory(Guid id, CategoryUpdateRequestDto categoryUpdateRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = _mapper.Map<Category>(categoryUpdateRequestDto);
            var updatedCategory = await _categoryService.UpdateAsync(id, category);
            var categoryRes = _mapper.Map<CategoryResponseDto>(updatedCategory);
            return Ok(categoryRes);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            await _categoryService.DeleteAsync(id);
            return NoContent();
        }
    }
}
