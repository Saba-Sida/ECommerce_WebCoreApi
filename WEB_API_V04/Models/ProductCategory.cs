using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEB_API_V04.Models
{
    public class ProductCategory
    {
        [Key]
        public int ProductCategoryId { get; set; }

        [Required]
        public string ProductCategoryTitle { get; set; } = string.Empty;

        public int? ParentProductCategoryId { get; set; }
        [ForeignKey("ParentProductCategoryId")]
        public ProductCategory? ParentProductCategory { get; set; }

        public List<Product> Products { get; set; } = new();
    }
}
