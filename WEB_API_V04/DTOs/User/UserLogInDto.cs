using System.ComponentModel.DataAnnotations;

namespace WEB_API_V04.DTOs.User
{
    public class UserLogInDto
    {
        [Required]
        public string EMail { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
