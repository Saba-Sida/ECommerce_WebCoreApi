using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WEB_API_V04.DTOs.ProductCategory
{
    public class ProductCategoryGetOneDto
    {
        public int ProductCategoryId { get; set; }
        public string ProductCategoryTitle { get; set; } = string.Empty;
        public int? ParentProductCategoryId { get; set; }
    }
}
