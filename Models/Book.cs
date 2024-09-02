using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystemBackend.Models
{
    public class Book
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(255, MinimumLength = 3)]
        [Required]
        public required string Title { get; set; }

        [StringLength(80, MinimumLength = 3)]
        [Required]
        public required string Author { get; set; }

        [StringLength(255, MinimumLength = 5)]
        [Required]
        public required string ISBN { get; set; }

        [StringLength(255, MinimumLength = 3)]
        [Required]
        public required string Publisher { get; set; }

        [StringLength(255, MinimumLength = 3)]
        [Required]
        public required DateTime PublishedDate { get; set; }

        public string? Description { get; set; }
        public bool? CopiesAvailable { get; set; }
        public int? TotalCopies { get; set; }
        public Guid CategoryId { get; set; }
        public required Category Category { get; set; }

        public DateTime? CratedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    }
}