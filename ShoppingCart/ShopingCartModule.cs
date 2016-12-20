using Nancy;
using Nancy.ModelBinding;
using ShoppingCarts.Microservice.Interfaces;

namespace ShoppingCarts.Microservice
{
    public class ShopingCartModule : NancyModule
    {
        // Note: Nancy DIP
        public ShopingCartModule(
            IShoppingCartStore shoppingCartStore,
            IProductCatalogClient productCatalog,
            IEventStore eventStore) 
            : base("/shoppingcart")

        {
            Get("/{userid:int}", parameters =>
            {
                var userId = (int)parameters.userid;

                return shoppingCartStore.Get(userId);
            });

            // Note: Use Async for awaiters processes
            Post("/{userid:int}/items", async (parameters, _) =>
            {
                // Note: Nancy Module Binding
                var productCatalogIds = this.Bind<int[]>();
                var userId = (int)parameters.userid;

                var shoppingCart = shoppingCartStore.Get(userId);

                // Note: Heavy Process with awaiters (Needs async method)
                var shopingCartItems = await productCatalog
                                            .GetShoppingCartItems(productCatalogIds)
                                            .ConfigureAwait(false); // Note: Allows execution to be resumed with a different thread context

                shoppingCart.AddItems(shopingCartItems, eventStore);
                shoppingCartStore.Save(shoppingCart);

                return shoppingCart;
            });

            Delete("/{userid:int}/items", paramters =>
            {
                var productCatalogIds = this.Bind<int[]>();
                var userId = paramters.userid;

                var shoppingCart = shoppingCartStore.Get(userId);

                shoppingCart.RemoveItems(productCatalogIds, eventStore);
                shoppingCartStore.Save(shoppingCart);

                return shoppingCart;
            });
        }
    }
}
