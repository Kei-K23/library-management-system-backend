using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystemBackend.Models
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(255, MinimumLength = 3)]
        [Required]
        public required string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<Book> Books { get; set; }
        public DateTime? CratedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    }
}