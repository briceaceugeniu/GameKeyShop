using Blazored.LocalStorage;
using GameKeyShop.Shared.Models;
using System.Collections.Generic;

namespace GameKeyShop.Client.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly HttpClient _http;

        public CartService(ILocalStorageService localStorage, HttpClient http)
        {
            _localStorage = localStorage;
            _http = http;
        }

        public event Action OnChange;

        public async Task AddToCart(CartItem cartItem)
        {
            var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
            if (cart == null)
            {
                cart = new List<CartItem>();
            }

            var sameItem = cart.Find(i => i.ProductId == cartItem.ProductId 
                && i.PlatformTypeId == cartItem.PlatformTypeId);

            if (sameItem == null)
            {
                cart.Add(cartItem);
            }
            else
            {
                sameItem.Quantity += cartItem.Quantity;
            }


            await _localStorage.SetItemAsync("cart", cart);

            OnChange?.Invoke();
        }

        public async Task<List<CartItem>> GetCartItems()
        {
            var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
            if (cart == null)
            {
                cart = new List<CartItem>();
            }

            return cart;
        }

        public async Task<List<CartProductResponseDto>> GetCartProducts()
        {
            var cartItems = await _localStorage.GetItemAsync<List<CartItem>>("cart");
            var response = await _http.PostAsJsonAsync("api/cart/products", cartItems);
            var cartProducts = await response.Content.ReadFromJsonAsync<ServiceResponse<List<CartProductResponseDto>>>();

            return cartProducts.Data;
        }

        public async Task RemoveProductFromCart(int productId, int platformTypeId)
        {
            var cartItems = await _localStorage.GetItemAsync<List<CartItem>>("cart");
            if (cartItems == null)
            {
                return;
            }

            var cartItem = cartItems.Find(i => i.ProductId == productId && i.PlatformTypeId == platformTypeId);
            if (cartItem != null)
            {
                cartItems.Remove(cartItem);
                await _localStorage.SetItemAsync("cart", cartItems);
                OnChange.Invoke();
            }
        }

        public async Task UpdateQuantity(CartProductResponseDto product)
        {
            var cartItems = await _localStorage.GetItemAsync<List<CartItem>>("cart");
            if (cartItems == null)
            {
                return;
            }

            var cartItem = cartItems.Find(i => i.ProductId == product.ProductId && i.PlatformTypeId == product.PlatformTypeId);
            if (cartItem != null)
            {
                cartItem.Quantity = product.Quantity;
                await _localStorage.SetItemAsync("cart", cartItems);
            }
        }
    }
}
