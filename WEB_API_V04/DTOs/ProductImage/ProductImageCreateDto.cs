using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WEB_API_V04.DTOs.ProductImage
{
    public class ProductImageCreateDto
    {

        [Required]
        public string ProductImageUrl { get; set; } = string.Empty;

        [Required]
        public int ProductId { get; set; }
    }
}
