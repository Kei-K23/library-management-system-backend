using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystemBackend.Dto
{
    public class BookUpdateRequestDto
    {

        [StringLength(255, MinimumLength = 3)]
        public string? Title { get; set; }

        [StringLength(80, MinimumLength = 3)]
        public string? Author { get; set; }

        [StringLength(255, MinimumLength = 5)]
        public string? ISBN { get; set; }

        [StringLength(255, MinimumLength = 3)]
        public string? Publisher { get; set; }

        [StringLength(255, MinimumLength = 3)]
        public DateTime? PublishedDate { get; set; }

        public string? Description { get; set; }
        public bool? CopiesAvailable { get; set; }
        public int? TotalCopies { get; set; }
        public Guid CategoryId { get; set; }
    }
}