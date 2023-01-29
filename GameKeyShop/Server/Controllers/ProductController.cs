using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameKeyShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> _products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Prod 1",
                Description = "Description Prod 1",
                ImageUrl = "https://cdn.pixabay.com/photo/2012/06/19/10/32/owl-50267_960_720.jpg",
                Price = 1.3m
            },
            new Product
            {
                Id = 2,
                Name = "Prod 2",
                Description = "Description Prod 2",
                ImageUrl = "https://cdn.pixabay.com/photo/2022/10/29/19/21/golden-eagle-7555959_960_720.jpg",
                Price = 3.5m
            },
            new Product
            {
                Id = 3,
                Name = "Prod 3",
                Description = "Description Prod 3",
                ImageUrl = "https://cdn.pixabay.com/photo/2023/01/12/05/32/duck-7713310_960_720.jpg",
                Price = 2.4m
            }

        };

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(_products);
        }
    }
}
