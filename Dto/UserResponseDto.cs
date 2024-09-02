using System.ComponentModel.DataAnnotations;
using LibraryManagementSystemBackend.Enum;

namespace LibraryManagementSystemBackend.Dto
{
    public class UserResponseDto
    {
        public Guid Id { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public string? ProfilePicture { get; set; }
        public UserRole UserRole { get; set; }
        public DateTime DateJoined { get; set; }
        public bool isBanned { get; set; } = false;
        public bool isLocked { get; set; } = false;
    }
}