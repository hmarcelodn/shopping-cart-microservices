using ShoppingCarts.Microservice.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCarts.Microservice.Model
{
    public class ShoppingCart
    {
        private HashSet<ShoppingCartItem> _items = new HashSet<ShoppingCartItem>();

        public int UserId { get; }
        public IEnumerable<ShoppingCartItem> Items { get { return _items; } }

        public ShoppingCart(int userId)
        {
            this.UserId = userId;
        }

        public void AddItems(IEnumerable<ShoppingCartItem> shoppingCartItems, 
                             IEventStore eventStore)
        {
            foreach (var item in shoppingCartItems)
            {
                _items.Add(item);

                // Note: Domain Object Raising Events
                eventStore.Raise(
                    "ShoppingCartItemAdded", 
                    new { UserId = item }
                );
            }
        }

        public void RemoveItems(int[] productCatalogIds, IEventStore eventStore)
        {
            _items.RemoveWhere(i => productCatalogIds.Contains(i.ProductId));
        }
    }

    public class Money
    {
        public string Currency { get; }
        public decimal Amount { get; }

        public Money(string currency, decimal amount)
        {
            this.Currency = currency;
            this.Amount = amount;
        }
    }
}
