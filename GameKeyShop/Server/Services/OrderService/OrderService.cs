namespace GameKeyShop.Server.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _context;
        private readonly ICartService _cartService;
        private readonly IAuthService _authService;

        public OrderService(DataContext context, ICartService cartService, IAuthService authService)
        {
            _context = context;
            _cartService = cartService;
            _authService = authService;
        }

        public async Task<ServiceResponse<OrderDetailsResponseDto>> GetOrderDetails(int orderId)
        {
            var response = new ServiceResponse<OrderDetailsResponseDto>();

            try
            {
                var order = await _context.Orders
                    .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                    .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.PlatformType)
                    .Where(o => o.UserId == _authService.GetUserId() && o.Id == orderId)
                    .OrderByDescending(o => o.OrderDate)
                    .FirstOrDefaultAsync();

                if (order == null)
                {
                    response.Success = false;
                    response.Message = "Order not found.";
                    return response;
                }

                var orderDetailsResponse = new OrderDetailsResponseDto
                {
                    OrderDate = order.OrderDate,
                    TotalPrice = order.TotalPrice,
                    Products = new List<OrderDetailsProductResponseDto>()
                };

                order.OrderItems.ForEach(item =>
                    orderDetailsResponse.Products.Add(new OrderDetailsProductResponseDto
                    {
                        ProductId = item.ProductId,
                        ImageUrl = item.Product.ImageUrl,
                        PlatformType = item.PlatformType.Name,
                        Quantity = item.Quantity,
                        Title = item.Product.Name,
                        GameKey = item.GameKey,
                        TotalPrice = item.TotalPrice
                    }));

                response.Data = orderDetailsResponse;
            }
            catch (Exception e)
            {
                response.Data = null;
                response.Success = false;
                response.Message = $"Could not get order details. Error: {e.Message}";
            }

            return response;
        }

        public async Task<ServiceResponse<List<OrderOverviewResponseDto>>> GetOrders()
        {
            var response = new ServiceResponse<List<OrderOverviewResponseDto>>();

            try
            {
                var orders = await _context.Orders
                    .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                    .Where(o => o.UserId == _authService.GetUserId())
                    .OrderByDescending(o => o.OrderDate)
                    .ToListAsync();

                var orderResponse = new List<OrderOverviewResponseDto>();

                // TODO: Combine pictures of games if multiple order items
                orders.ForEach(o => orderResponse.Add(new OrderOverviewResponseDto
                {
                    Id = o.Id,
                    OrderDate = o.OrderDate,
                    TotalPrice = o.TotalPrice,
                    Product = o.OrderItems.Count > 1 ?
                        $"{o.OrderItems.First().Product.Name} and" +
                        $" {o.OrderItems.Count - 1} more..." :
                        o.OrderItems.First().Product.Name,
                    ProductImageUrl = o.OrderItems.First().Product.ImageUrl
                }));

                response.Data = orderResponse;
            }
            catch (Exception e)
            {
                response.Data = null;
                response.Success = false;
                response.Message = $"Could not get order list. Error: {e.Message}";
            }

            return response;
        }



        public async Task<ServiceResponse<bool>> PlaceOrder()
        {
            try
            {
                var products = (await _cartService.GetDbCartProducts()).Data;

                if (products == null)
                {
                    return new ServiceResponse<bool> { Data = false, Message = "Can not place order. Cart is empty." };
                }

                decimal totalPrice = 0;
                products.ForEach(product => totalPrice += product.Price * product.Quantity);

                var orderItems = new List<OrderItem>();
                products.ForEach(product =>
                {
                    for (int i = 0; i < product.Quantity; i++)
                    {
                        orderItems.Add(new OrderItem
                        {
                            ProductId = product.ProductId,
                            PlatformTypeId = product.PlatformTypeId,
                            Quantity = 1,
                            GameKey = GenerateGUID(),
                            TotalPrice = product.Price
                        });
                    }
                });

                var order = new Order
                {
                    UserId = _authService.GetUserId(),
                    OrderDate = DateTime.Now,
                    TotalPrice = totalPrice,
                    OrderItems = orderItems
                };

                _context.Orders.Add(order);

                _context.CartItems.RemoveRange(_context.CartItems
                    .Where(ci => ci.UserId == _authService.GetUserId()));

                await _context.SaveChangesAsync();

                return new ServiceResponse<bool> { Data = true };
            }
            catch (Exception e)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Success = false,
                    Message = $"Could not place order. Error: {e.Message}"
                };
            }
            
        }

        private string GenerateGUID()
        {
            var guid = Guid.NewGuid();
            return guid.ToString();
        }
    }
}
