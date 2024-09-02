using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystemBackend.Dto
{
    public class CategoryRequestDto
    {

        [StringLength(255, MinimumLength = 3)]
        [Required]
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}