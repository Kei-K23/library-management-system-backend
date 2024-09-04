using System.ComponentModel.DataAnnotations;
using LibraryManagementSystemBackend.Enum;

namespace LibraryManagementSystemBackend.Dto
{
    public class UserUpdateRequestDto
    {
        [StringLength(100, MinimumLength = 3)]
        public string? UserName { get; set; }

        [StringLength(80, MinimumLength = 3)]
        [EmailAddress]
        public string? Email { get; set; }

        [StringLength(255, MinimumLength = 8)]
        public string? Password { get; set; }

        public string? ProfilePicture { get; set; }
        public UserRole? UserRole { get; set; }
        public bool? IsBanned { get; set; }
        public bool? IsLocked { get; set; }
    }
}