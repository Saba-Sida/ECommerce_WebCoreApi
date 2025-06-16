using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WEB_API_V04.DTOs.ProductCategory;
using WEB_API_V04.Interfaces.IRepositories;
using WEB_API_V04.Mappers;

namespace WEB_API_V04.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProductCategoriesController : ControllerBase
    {
        private IProductCategoryRepository categoryRepo;
        public ProductCategoriesController(IProductCategoryRepository categoryRepository)
        {
            categoryRepo = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productCategoryModels = await categoryRepo.GetAllAsync();

            return Ok(productCategoryModels.ToProductCategoryGetHierarchicalListDto());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var foundObject = await categoryRepo.GetByIdAsync(id);

            if (foundObject == null) return NotFound();

            return Ok(foundObject.ToProductCategoryGetOneDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductCategoryCreateDto productCategoryCreateDto)
        {
            try
            {
                var productToCreateModel = productCategoryCreateDto.FromCreateDtoToProductCategoryModel();

                await categoryRepo.CreateAsync(productToCreateModel);

                return CreatedAtAction(nameof(GetById), new { id = productToCreateModel.ProductCategoryId }, productToCreateModel.ToProductCategoryGetOneDto());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteById([FromRoute] int id)
        {
            try
            {
                var deletedObject = await categoryRepo.DeleteByIdAsync(id);

                if (deletedObject == null) return NotFound();

                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPatch]
        [Route("RenameCategoryTitle/{id}")]
        public async Task<IActionResult> RenameProductCategoryTitle([FromRoute] int id, [FromBody] ProductCategoryRenameTitleDto renameDto)
        {
            try
            {
                var categoryToRename = await categoryRepo.GetByIdAsync(id);

                if (categoryToRename == null) return NotFound();

                categoryToRename.ProductCategoryTitle = renameDto.NewTitle;

                await categoryRepo.UpdateAsync(id, categoryToRename);

                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
