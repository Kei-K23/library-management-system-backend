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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Categories
            var categoryGuid1 = Guid.NewGuid();
            var categoryGuid2 = Guid.NewGuid();
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = categoryGuid1,
                    Name = "Science Fiction"
                },
                new Category
                {
                    Id = categoryGuid2,
                    Name = "Fantasy"
                }
            );

            // Seed Books
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = Guid.NewGuid(),
                    Title = "Dune",
                    Author = "Frank Herbert",
                    ISBN = "9780441013593",
                    Publisher = "Ace",
                    PublishedDate = new DateTime(1965, 8, 1),
                    Description = "A science fiction novel.",
                    CopiesAvailable = true,
                    TotalCopies = 5,
                    CategoryId = categoryGuid1 // Use only the foreign key here
                },
                new Book
                {
                    Id = Guid.NewGuid(),
                    Title = "The Hobbit",
                    Author = "J.R.R. Tolkien",
                    ISBN = "9780345339683",
                    Publisher = "Houghton Mifflin",
                    PublishedDate = new DateTime(1937, 9, 21),
                    Description = "A fantasy novel.",
                    CopiesAvailable = true,
                    TotalCopies = 7,
                    CategoryId = categoryGuid2 // Use only the foreign key here
                }
            );
        }
    }
}
