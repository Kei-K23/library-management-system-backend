using System.ComponentModel.DataAnnotations;
using LibraryManagementSystemBackend.Enum;
using Microsoft.AspNetCore.Identity;

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
        [Required]
        public UserRole UserRole { get; set; }
        public DateTime DateJoined { get; set; }
    }
}