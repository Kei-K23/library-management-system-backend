using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystemBackend.Dto
{
    public class CategoryUpdateRequestDto
    {

        [StringLength(255, MinimumLength = 3)]
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}