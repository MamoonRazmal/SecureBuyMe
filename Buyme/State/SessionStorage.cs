using BuyMe.Components.Data;
using BuyMe.Data;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace BuyMe.State
{
    public class SessionStore
    {
        private readonly ProtectedSessionStorage protectedSessionStorage;
        private List<Product> _cartItems = new List<Product>();

        public event Action? OnChange;

        public SessionStore(ProtectedSessionStorage protectedSessionStorage)
        {
            this.protectedSessionStorage = protectedSessionStorage;
        }

        private void NotifyStateChanged() => OnChange?.Invoke();

        public async Task AddToCart(Product product)
        {
            _cartItems.Add(product);
            await protectedSessionStorage.SetAsync("cart", _cartItems);
            NotifyStateChanged();
        }

        public async Task<List<Product>> GetCartItems()
        {
            var result = await protectedSessionStorage.GetAsync<List<Product>>("cart");
            if (result.Success && result.Value != null)
            {
                _cartItems = result.Value;
            }
            return _cartItems;
        }

        public async Task RemoveFromCart(Product product)
        {
            _cartItems.Remove(product);
            await protectedSessionStorage.SetAsync("cart", _cartItems);
            NotifyStateChanged();
        }
    }
}
