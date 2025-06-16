using System.ComponentModel.DataAnnotations;
using WEB_API_V04.Models;

namespace WEB_API_V04.DTOs.User
{
    public class UserGetWhenInProductDto
    {
        public int UserId { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string EMail { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;


        public Gender Gender { get; set; }

        public string? ProfileImageUrl { get; set; }
    }
}
