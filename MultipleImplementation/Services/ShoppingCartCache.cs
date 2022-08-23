using MultipleImplementation.Interfaces;

namespace MultipleImplementation.Services
{
    public class ShoppingCartCache : IShoppingCart
    {
        public object GetCart()
        {
            return "Cart loaded from cache.";
        }
    }
}