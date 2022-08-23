using MultipleImplementation.Interfaces;

namespace MultipleImplementation.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly Func<string, IShoppingCart> shoppingCart;
        public ShoppingCartRepository(Func<string, IShoppingCart> shoppingCart)
        {
            this.shoppingCart = shoppingCart;
        }

        public object GetCart()
        {
            return shoppingCart(CartSource.API.ToString()).GetCart();
        }
    }
}