using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WEB_API_V04.Models;
using WEB_API_V04.DTOs.ProductCategory;
using WEB_API_V04.DTOs.ProductImage;

namespace WEB_API_V04.DTOs.Product
{
    public class ProductGetWhenUserPropertyDto
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = string.Empty;
        public string? ProductDescription { get; set; } = null;

        public decimal Price { get; set; }


        public ProductCategoryGetOneDto ProductCategory { get; set; } = null!;

        public List<ProductImageGetDto> ProductImages { get; set; } = new();
    }
}
