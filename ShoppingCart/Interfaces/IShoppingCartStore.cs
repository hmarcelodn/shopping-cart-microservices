using ShoppingCarts.Microservice.Model;

namespace ShoppingCarts.Microservice.Interfaces
{
    public interface IShoppingCartStore
    {
        ShoppingCart Get(int userId);

        void Save(ShoppingCart shoppingCart);
    }
}
