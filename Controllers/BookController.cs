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
    public class BookController : ControllerBase
    {
        private readonly IBookService<Book> _bookService;
        private readonly IMapper _mapper;

        public BookController(IBookService<Book> bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookService.GetAllAsync();
            var booksResponse = books.Select(_mapper.Map<BookResponseDto>);
            return Ok(booksResponse);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> GetBookById(Guid id)
        {
            var book = await _bookService.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            var bookResponse = _mapper.Map<BookResponseDto>(book);
            return Ok(bookResponse);
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> AddBook(BookRequestDto bookRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var book = _mapper.Map<Book>(bookRequestDto);
            var createdBook = await _bookService.AddAsync(book);
            var bookRes = _mapper.Map<BookResponseDto>(createdBook);
            return Ok(bookRes);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> UpdateBook(Guid id, BookUpdateRequestDto bookUpdateRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var book = _mapper.Map<Book>(bookUpdateRequestDto);
            var updatedBook = await _bookService.UpdateAsync(id, book);
            var bookRes = _mapper.Map<BookResponseDto>(updatedBook);
            return Ok(bookRes);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            await _bookService.DeleteAsync(id);
            return NoContent();
        }
    }
}
