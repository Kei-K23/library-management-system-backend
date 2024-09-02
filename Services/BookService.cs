using LibraryManagementSystemBackend.ApplicationDBContext;
using LibraryManagementSystemBackend.Interfaces;
using LibraryManagementSystemBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystemBackend.Services
{
    public class BookService : IBookService<Book>
    {
        private readonly AppDbContext _context;
        private readonly ILogger<UserService> _logger;

        public BookService(AppDbContext context, ILogger<UserService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            try
            {
                return await _context.Books.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving books");
                throw new Exception("Something went wrong when retrieving book", ex);
            }
        }

        public async Task<Book> GetByIdAsync(Guid id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                throw new KeyNotFoundException($"Book with id {id} not found.");
            }

            return book;
        }

        public async Task<Book> GetByTitleAsync(string title)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.Title == title);

            if (book == null)
            {
                throw new KeyNotFoundException($"Book with title {title} not found.");
            }

            return book;
        }

        public async Task<Book> AddAsync(Book request)
        {
            try
            {
                await _context.Books.AddAsync(request);
                await _context.SaveChangesAsync();

                return request;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the book");
                throw new Exception("An error occurred while creating the book", ex);
            }
        }

        public async Task<Book> UpdateAsync(Guid id, Book request)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                throw new KeyNotFoundException($"Book with id {id} not found.");
            }

            try
            {
                if (!string.IsNullOrEmpty(request.Title))
                {
                    book.Title = request.Title;
                }
                if (!string.IsNullOrEmpty(request.Author))
                {
                    book.Author = request.Author;
                }
                if (!string.IsNullOrEmpty(request.ISBN))
                {
                    book.ISBN = request.ISBN;
                }
                if (!string.IsNullOrEmpty(request.Publisher))
                {
                    book.Publisher = request.Publisher;
                }
                if (!string.IsNullOrEmpty(request.Description))
                {
                    book.Description = request.Description;
                }
                book.CopiesAvailable = request.CopiesAvailable;
                book.PublishedDate = request.PublishedDate;
                book.TotalCopies = request.TotalCopies;
                book.CategoryId = request.CategoryId;
                book.UpdatedAt = DateTime.Now;

                await _context.SaveChangesAsync();

                return book;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the book");
                throw new Exception("An error occurred while updating the book", ex);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                throw new KeyNotFoundException($"Book with id {id} not found.");
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}
