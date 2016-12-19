using ShoppingCarts.Microservice.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingCarts.Microservice.Interfaces
{
    public interface IProductCatalogClient
    {
        Task<IEnumerable<ShoppingCartItem>> GetShoppingCartItems(int[] productCatalogIds);
    }
}
