using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameKeyShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProducts()
        {
            var response = await _service.GetProductsAsync();
            return Ok(response);
        }

        [HttpGet("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetAdminProducts()
        {
            var response = await _service.GetAdminProductsAsync();
            return Ok(response);
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProduct(int productId)
        {
            var response = await _service.GetProductAsync(productId);
            return Ok(response);
        }

        [HttpGet("category/{categoryUrl}")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductsByCategory(string categoryUrl)
        {
            var response = await _service.GetProductsByCategory(categoryUrl);
            return Ok(response);
        }

        [HttpGet("search/{searchText}/{page}")]
        public async Task<ActionResult<ServiceResponse<ProductSearhResultDto>>> SearchProducts(string searchText, int page)
        {
            var response = await _service.SearchProducts(searchText, page);
            return Ok(response);
        }

        [HttpGet("featured")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetFeatured()
        {
            var response = await _service.GetFeaturedProducts();
            return Ok(response);
        }

        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<Product>>> CreateProduct(Product product)
        {
            var result = await _service.CreateProduct(product);
            return Ok(result);
        }

        [HttpPut, Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<Product>>> UpdateProduct(Product product)
        {
            var result = await _service.UpdateProduct(product);
            return Ok(result);
        }

        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteProduct(int id)
        {
            var result = await _service.DeleteProduct(id);
            return Ok(result);
        }
    }
}
