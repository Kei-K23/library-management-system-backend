using LibraryManagementSystemBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystemBackend.ApplicationDBContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}