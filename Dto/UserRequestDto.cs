using System.ComponentModel.DataAnnotations;
using LibraryManagementSystemBackend.Enum;

namespace LibraryManagementSystemBackend.Dto
{
    public class UserRequestDto
    {
        [StringLength(100, MinimumLength = 3)]
        [Required]
        public required string UserName { get; set; }

        [StringLength(80, MinimumLength = 3)]
        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [StringLength(255, MinimumLength = 8)]
        [Required]
        public required string Password { get; set; }

        public string? ProfilePicture { get; set; }
        [Required]
        public UserRole UserRole { get; set; }
    }
}