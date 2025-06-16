using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WEB_API_V04.DTOs.ProductCategory
{
    public class ProductCategoryGetHierarchicalDto
    {

        public int ProductCategoryId { get; set; }

        public string ProductCategoryTitle { get; set; } = string.Empty;

        public List<ProductCategoryGetHierarchicalDto>? SubProductCategories { get; set; } = new();

    }
}
