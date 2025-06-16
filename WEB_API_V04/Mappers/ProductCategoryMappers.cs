using System.Runtime.CompilerServices;
using WEB_API_V04.DTOs.ProductCategory;
using WEB_API_V04.Models;

namespace WEB_API_V04.Mappers
{
    public static class ProductCategoryMappers
    {
        public static ProductCategoryGetOneDto ToProductCategoryGetOneDto(this ProductCategory productCategoryModel)
        {
            return new ProductCategoryGetOneDto
            {
                ProductCategoryId = productCategoryModel.ProductCategoryId,
                ProductCategoryTitle = productCategoryModel.ProductCategoryTitle,
                ParentProductCategoryId = productCategoryModel.ParentProductCategoryId
            };
        }

        public static ProductCategoryGetHierarchicalDto ToProductCategoryGetHierarchicalDto(this ProductCategory productCategoryModel)
        {
            return new ProductCategoryGetHierarchicalDto
            {
                ProductCategoryId = productCategoryModel.ProductCategoryId,
                ProductCategoryTitle = productCategoryModel.ProductCategoryTitle
            };
        }

        public static List<ProductCategoryGetHierarchicalDto> ToProductCategoryGetHierarchicalListDto(this List<ProductCategory> productCategoryModels, int? parentProductCategoryId = null)
        {
            List<ProductCategoryGetHierarchicalDto> listOfCategories = new();
            foreach (var productCategoryModel in productCategoryModels)
            {
                if(productCategoryModel.ParentProductCategoryId == parentProductCategoryId)
                {
                    var hierarchicalCategoryDto = productCategoryModel.ToProductCategoryGetHierarchicalDto();

                    hierarchicalCategoryDto.SubProductCategories = productCategoryModels.ToProductCategoryGetHierarchicalListDto(productCategoryModel.ProductCategoryId);

                    listOfCategories.Add(hierarchicalCategoryDto);
                }
            }

            return listOfCategories;
        }

        public static ProductCategory FromCreateDtoToProductCategoryModel(this ProductCategoryCreateDto productCategoryCreateDto)
        {
            return new ProductCategory
            {
                ProductCategoryTitle = productCategoryCreateDto.ProductCategoryTitle,
                ParentProductCategoryId = productCategoryCreateDto.ParentProductCategoryId
            };
        }
    }

}
