using System.ComponentModel.DataAnnotations;
using WEB_API_V04.Models;

namespace WEB_API_V04.DTOs.User
{
    public class UserUpdateDto
    {

        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required]
        public string EMail { get; set; } = string.Empty;

        [Required]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        public Gender Gender { get; set; }

        public string? ProfileImageUrl { get; set; }
    }
}
