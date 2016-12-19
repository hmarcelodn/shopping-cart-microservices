using ShoppingCarts.Microservice.Interfaces;
using System.Collections.Generic;

namespace ShoppingCarts.Microservice.Model
{
    public class ShoppingCart
    {
        public void AddItems(IList<ShoppingCartItem> shoppingCartItem, IEventStore eventStore)
        { }

        public void RemoveItems(int[] productCatalogIds, IEventStore eventStore)
        { }
    }
}
