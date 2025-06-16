using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WEB_API_V04.DTOs.ProductImage
{
    public class ProductImageGetDto
    {

        public int ProductImageId { get; set; }

        public string ProductImageUrl { get; set; } = string.Empty;

        public int ProductId {get; set;}

    }
}
