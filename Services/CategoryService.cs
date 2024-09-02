using LibraryManagementSystemBackend.ApplicationDBContext;
using LibraryManagementSystemBackend.Interfaces;
using LibraryManagementSystemBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystemBackend.Services
{
    public class CategoryService : ICategoryService<Category>
    {
        private readonly AppDbContext _context;
        private readonly ILogger<CategoryService> _logger;

        public CategoryService(AppDbContext context, ILogger<CategoryService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            try
            {
                return await _context.Categories.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving categories");
                throw new Exception("Something went wrong when retrieving categories", ex);
            }
        }

        public async Task<Category> GetByIdAsync(Guid id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                throw new KeyNotFoundException($"Category with id {id} not found.");
            }

            return category;
        }

        public async Task<Category> GetByNameAsync(string name)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(b => b.Name == name);

            if (category == null)
            {
                throw new KeyNotFoundException($"Category with title {name} not found.");
            }

            return category;
        }

        public async Task<Category> AddAsync(Category request)
        {
            try
            {
                await _context.Categories.AddAsync(request);
                await _context.SaveChangesAsync();

                return request;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the category");
                throw new Exception("An error occurred while creating the category", ex);
            }
        }

        public async Task<Category> UpdateAsync(Guid id, Category request)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                throw new KeyNotFoundException($"Category with id {id} not found.");
            }

            try
            {
                if (!string.IsNullOrEmpty(request.Name))
                {
                    category.Name = request.Name;
                }
                if (!string.IsNullOrEmpty(request.Description))
                {
                    category.Description = request.Description;
                }
                category.UpdatedAt = DateTime.Now;

                await _context.SaveChangesAsync();

                return category;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the category");
                throw new Exception("An error occurred while updating the category", ex);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                throw new KeyNotFoundException($"Category with id {id} not found.");
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}
