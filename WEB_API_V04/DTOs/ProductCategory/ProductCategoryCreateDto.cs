using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WEB_API_V04.DTOs.ProductCategory
{
    public class ProductCategoryCreateDto
    {
        [Required]
        public string ProductCategoryTitle { get; set; } = string.Empty;

        public int? ParentProductCategoryId { get; set; }
    }
}
