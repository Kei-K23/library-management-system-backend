using System.ComponentModel.DataAnnotations;
using LibraryManagementSystemBackend.Enum;

namespace LibraryManagementSystemBackend.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

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
        public bool? IsBanned { get; set; } = false;
        public bool? IsLocked { get; set; } = false;
        [Required]
        public UserRole UserRole { get; set; }
        public DateTime DateJoined { get; set; }
        public DateTime? CratedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    }
}