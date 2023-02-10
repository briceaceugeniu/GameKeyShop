using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameKeyShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ServiceResponse<bool>>> PlaceOrder()
        {
            var result = await _orderService.PlaceOrder();
            return Ok(result);
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<ServiceResponse<List<OrderOverviewResponseDto>>>> GetOrders()
        {
            var result = await _orderService.GetOrders();
            return Ok(result);
        }

        [HttpGet("{orderId}")]
        [Authorize]
        public async Task<ActionResult<ServiceResponse<OrderDetailsResponseDto>>> GetOrderDetails(int orderId)
        {
            var result = await _orderService.GetOrderDetails(orderId);
            return Ok(result);
        }
    }
}
