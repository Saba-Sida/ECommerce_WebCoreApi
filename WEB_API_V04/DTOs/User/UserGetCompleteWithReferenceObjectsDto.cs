using System.ComponentModel.DataAnnotations;
using WEB_API_V04.DTOs.Product;
using WEB_API_V04.Models;

namespace WEB_API_V04.DTOs.User
{
    public class UserGetCompleteWithReferenceObjectsDto
    {
        public int UserId { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string EMail { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public Gender Gender { get; set; }

        public string? ProfileImageUrl { get; set; }


        public List<ProductGetWhenUserPropertyDto> Products { get; set; } = new(); // kinda this in here later
    }
}
