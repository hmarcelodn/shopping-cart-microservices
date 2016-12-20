using ShoppingCarts.Microservice.Interfaces;
using ShoppingCarts.Microservice.Model;
using System.Collections.Generic;

namespace ShoppingCarts.Microservice.Data
{
    public class ShoppingCartStore : IShoppingCartStore
    {
        private static readonly Dictionary<int, ShoppingCart> database = new Dictionary<int, ShoppingCart>();

        public ShoppingCart Get(int userId)
        {
            if (!database.ContainsKey(userId))
            {
                database[userId] = new ShoppingCart(userId);
            }

            return database[userId];
        }

        public void Save(ShoppingCart shoppingCart)
        {
            //throw new NotImplementedException();
        }
    }
}
