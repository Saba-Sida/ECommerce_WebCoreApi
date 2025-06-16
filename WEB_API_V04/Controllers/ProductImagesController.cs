using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WEB_API_V04.DTOs.ProductImage;
using WEB_API_V04.Interfaces.IRepositories;
using WEB_API_V04.Mappers;

namespace WEB_API_V04.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private IProductImageRepository productImageRepo;
        public ProductImagesController(IProductImageRepository productImageRepository)
        {
            productImageRepo = productImageRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetImageById(int id)
        {
            var imageModel = await productImageRepo.GetByIdAsync(id);

            if (imageModel == null) return NotFound();

            return Ok(imageModel.ToProductImageGetDto());
        }

        [HttpGet]
        public async Task<IActionResult> GetImagesByProductId([FromQuery] int productId)
        {
            var imagesByProductId = await productImageRepo.WhereAsync(image => image.ProductId == productId);

            return Ok(imagesByProductId.Select(image => image.ToProductImageGetDto()));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductImageCreateDto productImageCreateDto)
        {
            try
            {
                var productToBeAdded = productImageCreateDto.FromCreateDtoToProductImageModel();
                await productImageRepo.CreateAsync(productToBeAdded);

                return CreatedAtAction(nameof(GetImageById), new { id = productToBeAdded.ProductImageId }, productToBeAdded.ToProductImageGetDto());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteProductImageById([FromRoute] int id)
        {
            var productImageToBeDeleted = await productImageRepo.DeleteByIdAsync(id);

            if (productImageToBeDeleted == null) return NotFound();

            return NoContent();
        }
    }
}
