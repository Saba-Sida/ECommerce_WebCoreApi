using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WEB_API_V04.DTOs.Product
{
    public class ProductCreateDto
    {
        [Required]
        public string ProductName { get; set; } = string.Empty;
        public string? ProductDescription { get; set; } = null;

        [Required]
        public decimal Price { get; set; }


        [Required]
        public int AuthorUserId { get; set; }


        [Required]
        public int ProductCategoryId { get; set; }
    }
}
