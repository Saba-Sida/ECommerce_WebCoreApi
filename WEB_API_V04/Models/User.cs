using System.ComponentModel.DataAnnotations;

namespace WEB_API_V04.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required]
        public string EMail { get; set; } = string.Empty;

        [Required]
        public string PhoneNumber {  get; set; } = string.Empty;

        [Required]
        public string PasswordHash {  get; set; } = string.Empty;

        [Required]
        public Gender Gender {  get; set; }

        public string? ProfileImageUrl { get; set; }


        // navigation
        public List<Product> Products { get; set; } = new();
    }

    public enum Gender
    {
        Male = 1,
        Female
    }
}
