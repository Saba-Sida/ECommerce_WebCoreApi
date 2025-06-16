using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEB_API_V04.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; } = string.Empty;
        public string? ProductDescription { get; set; } = null;

        [Required]
        [Precision(18, 2)]
        public decimal Price {  get; set; }


        [Required]
        public int AuthorUserId {  get; set; }

        [ForeignKey("AuthorUserId")]
        public User AuthorUser { get; set; } = null!;


        [Required]
        public int ProductCategoryId {  get; set; }
        [ForeignKey("ProductCategoryId")]
        public ProductCategory ProductCategory { get; set; } = null!;

        // navigation
        public List<ProductImage> ProductImages { get; set; } = new();
    }
}
