using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WEB_API_V04.DTOs.ProductCategory;
using WEB_API_V04.DTOs.ProductImage;
using WEB_API_V04.DTOs.User;

namespace WEB_API_V04.DTOs.Product
{
    public class ProductGetCompleteWithReferenceObjectsDto
    {

        public int ProductId { get; set; }

        public string ProductName { get; set; } = string.Empty;
        public string? ProductDescription { get; set; } = null;

        public decimal Price { get; set; }



        public UserGetWhenInProductDto AuthorUser { get; set; } = null!;


        public ProductCategoryGetOneDto ProductCategory { get; set; } = null!;

        public List<ProductImageGetDto> ProductImages { get; set; } = new();
    }
}
