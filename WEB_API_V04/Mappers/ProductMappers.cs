using WEB_API_V04.DTOs.Product;
using WEB_API_V04.Models;

namespace WEB_API_V04.Mappers
{
    public static class ProductMappers
    {
        public static ProductGetWhenUserPropertyDto ToProductGetWhenUserPropertyDto(this Product productModel)
        {
            return new ProductGetWhenUserPropertyDto
            {
                ProductId = productModel.ProductId,
                ProductName = productModel.ProductName,
                ProductDescription = productModel.ProductDescription,
                Price = productModel.Price,
                ProductCategory = productModel.ProductCategory.ToProductCategoryGetOneDto(),
                ProductImages = productModel.ProductImages.Select(image => image.ToProductImageGetDto()).ToList()
            };
        }

        public static ProductGetCompleteWithReferenceObjectsDto ToProductGetCompleteWithReferenceObjectsDto(this Product productModel)
        {
            return new ProductGetCompleteWithReferenceObjectsDto
            {
                ProductId = productModel.ProductId,
                ProductName = productModel.ProductName,
                ProductDescription = productModel.ProductDescription,
                Price = productModel.Price,
                ProductImages = productModel.ProductImages.Select(image => image.ToProductImageGetDto()).ToList(),
                ProductCategory = productModel.ProductCategory.ToProductCategoryGetOneDto(),
                AuthorUser = productModel.AuthorUser.ToUserGetWhenInProductDto()
            };
        }

        public static Product FromCreateDtoToProductModel(this ProductCreateDto productCreateDto)
        {
            return new Product
            {
                ProductName = productCreateDto.ProductName,
                ProductDescription = productCreateDto.ProductDescription,
                Price = productCreateDto.Price,
                AuthorUserId = productCreateDto.AuthorUserId,
                ProductCategoryId = productCreateDto.ProductCategoryId
            };
        }
    }
}
