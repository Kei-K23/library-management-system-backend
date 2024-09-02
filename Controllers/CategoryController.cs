using AutoMapper;
using LibraryManagementSystemBackend.Interfaces;
using LibraryManagementSystemBackend.Models;
using LibraryManagementSystemBackend.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace LibraryManagementSystemBackend.Controllers
{
    [ApiController]
    [Route("api/v1/books")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService<Category> _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService<Category> bookService, IMapper mapper)
        {
            _categoryService = bookService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> GetAllCategories()
        {
            var books = await _categoryService.GetAllAsync();
            var booksResponse = books.Select(_mapper.Map<CategoryResponseDto>);
            return Ok(booksResponse);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            var book = await _categoryService.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            var bookResponse = _mapper.Map<CategoryResponseDto>(book);
            return Ok(bookResponse);
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> AddCategory(CategoryRequestDto bookRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var book = _mapper.Map<Category>(bookRequestDto);
            var createdCategory = await _categoryService.AddAsync(book);
            var bookRes = _mapper.Map<CategoryResponseDto>(createdCategory);
            return Ok(bookRes);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> UpdateCategory(Guid id, CategoryUpdateRequestDto bookUpdateRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var book = _mapper.Map<Category>(bookUpdateRequestDto);
            var updatedCategory = await _categoryService.UpdateAsync(id, book);
            var bookRes = _mapper.Map<CategoryResponseDto>(updatedCategory);
            return Ok(bookRes);
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
