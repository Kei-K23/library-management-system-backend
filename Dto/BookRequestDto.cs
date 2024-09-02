using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystemBackend.Dto
{
    public class BookRequestDto
    {

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
    }
}