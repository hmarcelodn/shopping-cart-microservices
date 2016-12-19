using ShoppingCarts.Microservice.Interfaces;
using System;
using System.Collections.Generic;

namespace ShoppingCarts.Microservice.Model
{
    public class ShoppingCart
    {
        public void AddItems(IEnumerable<ShoppingCartItem> shoppingCartItem, IEventStore eventStore)
        {
            throw new NotImplementedException();
        }

        public void RemoveItems(int[] productCatalogIds, IEventStore eventStore)
        {
            throw new NotImplementedException();
        }
    }
}
