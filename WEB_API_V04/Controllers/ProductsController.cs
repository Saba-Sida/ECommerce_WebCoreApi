using Microsoft.AspNetCore.Mvc;
using WEB_API_V04.DTOs.Product;
using WEB_API_V04.Interfaces.IRepositories;
using WEB_API_V04.Mappers;

namespace WEB_API_V04.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductRepository productsRepo;
        public ProductsController(IProductRepository productRepository)
        {
            productsRepo = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var productModels = await productsRepo.GetAllAsync();

            return Ok(productModels.Select(pr => pr.ToProductGetCompleteWithReferenceObjectsDto()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var productModel = await productsRepo.GetByIdAsync(id);

            if (productModel == null) return NotFound();

            return Ok(productModel.ToProductGetCompleteWithReferenceObjectsDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductCreateDto productCreateDto)
        {
            try
            {
                var newProductModel = productCreateDto.FromCreateDtoToProductModel();

                await productsRepo.CreateAsync(newProductModel);

                var createdProduct = await productsRepo.GetByIdAsync(newProductModel.ProductId);

                if (createdProduct == null) return BadRequest();

                return Ok(createdProduct.ToProductGetCompleteWithReferenceObjectsDto());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deletedProduct = await productsRepo.DeleteByIdAsync(id); ;
                if (deletedProduct == null) return NotFound();
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
