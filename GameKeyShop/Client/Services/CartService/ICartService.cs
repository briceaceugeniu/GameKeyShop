﻿using GameKeyShop.Shared.DTO;

namespace GameKeyShop.Client.Services.CartService
{
    public interface ICartService
    {
        event Action OnChange;
        Task AddToCart(CartItem cartItem);
        Task<List<CartItem>> GetCartItems();
        Task<List<CartProductResponseDto>> GetCartProducts();
        Task RemoveProductFromCart(int productId, int productType);
        Task UpdateQuantity(CartProductResponseDto product);
    }
}