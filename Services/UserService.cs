using LibraryManagementSystemBackend.ApplicationDBContext;
using LibraryManagementSystemBackend.Interfaces;
using LibraryManagementSystemBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystemBackend.Services
{
    public class UserService : IUserService<User>
    {
        private readonly AppDbContext _context;
        private readonly ILogger<UserService> _logger;

        public UserService(AppDbContext context, ILogger<UserService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            try
            {
                return await _context.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving users");
                throw new Exception("Something went wrong when retrieving user", ex);
            }
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with id {id} not found.");
            }

            return user;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                throw new KeyNotFoundException($"User with email {email} not found.");
            }

            return user;
        }

        public async Task<User> AddAsync(User request)
        {
            try
            {
                request.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(request.Password, 11);
                request.DateJoined = DateTime.Now;

                await _context.Users.AddAsync(request);
                await _context.SaveChangesAsync();

                return request;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the user");
                throw new Exception("An error occurred while creating the user", ex);
            }
        }

        public async Task<User> UpdateAsync(Guid id, User request)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with id {id} not found.");
            }

            try
            {
                if (!string.IsNullOrEmpty(request.UserName))
                {
                    user.UserName = request.UserName;
                }
                if (!string.IsNullOrEmpty(request.Email))
                {
                    user.Email = request.Email;
                }
                if (!string.IsNullOrEmpty(request.Password))
                {
                    user.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(request.Password, 11);
                }
                if (request.ProfilePicture != null)
                {
                    user.ProfilePicture = request.ProfilePicture;
                }
                user.UserRole = request.UserRole;

                await _context.SaveChangesAsync();

                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the user");
                throw new Exception("An error occurred while updating the user", ex);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with id {id} not found.");
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
