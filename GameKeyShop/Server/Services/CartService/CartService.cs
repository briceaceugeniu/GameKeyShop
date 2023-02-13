namespace GameKeyShop.Server.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly DataContext _context;
        private readonly IAuthService _authService;

        public CartService(DataContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        public async Task<ServiceResponse<List<CartProductResponseDto>>> GetCartProducts(List<CartItem> cartItems)
        {
            var result = new ServiceResponse<List<CartProductResponseDto>>
            {
                Data = new List<CartProductResponseDto>()
            };

            foreach (var item in cartItems)
            {
                var product = await _context.Products
                    .Where(p => p.Id == item.ProductId)
                    .FirstOrDefaultAsync();

                if (product == null)
                {
                    continue;
                }

                var productVariant = await _context.ProductVariants
                    .Where(v => v.ProductId == item.ProductId
                        && v.PlatformTypeId == item.PlatformTypeId)
                    .Include(v => v.PlatformType)
                    .FirstOrDefaultAsync();

                if (productVariant == null)
                {
                    continue;
                }

                var cartProduct = new CartProductResponseDto
                {
                    ProductId = product.Id,
                    Title = product.Name,
                    ImageUrl = product.ImageUrl,
                    Price = productVariant.Price,
                    PlatformType = productVariant.PlatformType.Name,
                    PlatformTypeId = productVariant.PlatformTypeId,
                    Quantity = item.Quantity
                };

                result.Data.Add(cartProduct);
            }

            return result;
        }

        public async Task<ServiceResponse<List<CartProductResponseDto>>> StoreCartItems(List<CartItem> cartItems)
        {
            try
            {
                cartItems.ForEach(cartItem => cartItem.UserId = _authService.GetUserId());
                _context.CartItems.AddRange(cartItems);
                await _context.SaveChangesAsync();

                return await GetDbCartProducts();
            }
            catch (Exception e)
            {
                return new ServiceResponse<List<CartProductResponseDto>>
                {
                    Data = null,
                    Success = false,
                    Message = $"Could not store cart items. Error: {e.Message}"
                };
            }
        }

        public async Task<ServiceResponse<int>> GetCartItemsCount()
        {
            try
            {
                var count = (await _context.CartItems.Where(ci => ci.UserId == _authService.GetUserId()).ToListAsync()).Count;
                return new ServiceResponse<int> { Data = count };
            }
            catch (Exception e)
            {
                return new ServiceResponse<int>
                {
                    Data = 0,
                    Success = false,
                    Message = $"Could not get cart items count. Error: {e.Message}"
                };
            }
        }

        public async Task<ServiceResponse<List<CartProductResponseDto>>> GetDbCartProducts()
        {
            try
            {
                return await GetCartProducts(await _context.CartItems
                    .Where(ci => ci.UserId == _authService.GetUserId()).ToListAsync());

            }
            catch (Exception e)
            {
                return new ServiceResponse<List<CartProductResponseDto>>
                {
                    Data = null,
                    Success = false,
                    Message = $"Could not get cart items from DB. Error: {e.Message}"
                };
            }
        }

        public async Task<ServiceResponse<bool>> AddToCart(CartItem cartItem)
        {
            try
            {
                cartItem.UserId = _authService.GetUserId();

                var sameItem = await _context.CartItems
                    .FirstOrDefaultAsync(ci => ci.ProductId == cartItem.ProductId &&
                                               ci.PlatformTypeId == cartItem.PlatformTypeId && ci.UserId == cartItem.UserId);
                if (sameItem == null)
                {
                    _context.CartItems.Add(cartItem);
                }
                else
                {
                    sameItem.Quantity += cartItem.Quantity;
                }

                await _context.SaveChangesAsync();

                return new ServiceResponse<bool> { Data = true };
            }
            catch (Exception e)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Success = false,
                    Message = $"Could not add item to cart. Error: {e.Message}"
                };
            }
        }

        public async Task<ServiceResponse<bool>> UpdateQuantity(CartItem cartItem)
        {
            try
            {
                var dbCartItem = await _context.CartItems
                    .FirstOrDefaultAsync(ci => ci.ProductId == cartItem.ProductId &&
                                               ci.PlatformTypeId == cartItem.PlatformTypeId && ci.UserId == _authService.GetUserId());
                if (dbCartItem == null)
                {
                    return new ServiceResponse<bool>
                    {
                        Data = false,
                        Success = false,
                        Message = "Cart item does not exist."
                    };
                }

                dbCartItem.Quantity = cartItem.Quantity;
                await _context.SaveChangesAsync();

                return new ServiceResponse<bool> { Data = true };
            }
            catch (Exception e)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Success = false,
                    Message = $"Could not update quantity. Error: {e.Message}"
                };
            }
        }

        public async Task<ServiceResponse<bool>> RemoveItemFromCart(int productId, int productTypeId)
        {
            try
            {
                var dbCartItem = await _context.CartItems
                    .FirstOrDefaultAsync(ci => ci.ProductId == productId &&
                                               ci.PlatformTypeId == productTypeId && ci.UserId == _authService.GetUserId());
                if (dbCartItem == null)
                {
                    return new ServiceResponse<bool>
                    {
                        Data = false,
                        Success = false,
                        Message = "Cart item does not exist."
                    };
                }

                _context.CartItems.Remove(dbCartItem);
                await _context.SaveChangesAsync();

                return new ServiceResponse<bool> { Data = true };
            }
            catch (Exception e)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Success = false,
                    Message = $"Could not remove item form cart. Error: {e.Message}"
                };
            }
        }
    }
}
