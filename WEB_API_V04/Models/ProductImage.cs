using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEB_API_V04.Models
{
    public class ProductImage
    {
        [Key]
        public int ProductImageId { get; set; }

        [Required]
        public string ProductImageUrl { get; set; } = string.Empty;

        [Required]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product product { get; set; } = null!;
    }
}
