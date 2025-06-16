using WEB_API_V04.DTOs.ProductImage;
using WEB_API_V04.Models;

namespace WEB_API_V04.Mappers
{
    public static class ProductImageMappers
    {
        public static ProductImageGetDto ToProductImageGetDto(this ProductImage productImageModel)
        {
            return new ProductImageGetDto
            {
                ProductImageId = productImageModel.ProductImageId,
                ProductImageUrl = productImageModel.ProductImageUrl,
                ProductId = productImageModel.ProductId
            };
        }

        public static ProductImage FromCreateDtoToProductImageModel(this ProductImageCreateDto producImagetCreateDto)
        {
            return new ProductImage
            {
                ProductId = producImagetCreateDto.ProductId,
                ProductImageUrl = producImagetCreateDto.ProductImageUrl
            };
        }
    }
}


