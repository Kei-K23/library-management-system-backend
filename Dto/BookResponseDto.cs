using System.ComponentModel.DataAnnotations;
using LibraryManagementSystemBackend.Models;

namespace LibraryManagementSystemBackend.Dto
{
    public class BookResponseDto
    {

        public Guid Id { get; set; }

        public required string Title { get; set; }

        public required string Author { get; set; }

        public required string ISBN { get; set; }

        public required string Publisher { get; set; }

        public required DateTime PublishedDate { get; set; }

        public string? Description { get; set; }
        public bool? CopiesAvailable { get; set; }
        public int? TotalCopies { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime? CratedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    }
}