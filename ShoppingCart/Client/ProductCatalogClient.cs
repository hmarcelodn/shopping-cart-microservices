using Newtonsoft.Json;
using ShoppingCarts.Microservice.Interfaces;
using ShoppingCarts.Microservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ShoppingCarts.Microservice.Client
{
    public class ProductCatalogClient : IProductCatalogClient
    {
        // Note: Apiary Mock Data API
        private static string productCatalogBaseUrl = @"https://private-b3bb4-productcatalogmicroservice3.apiary-mock.com";
        private static string getProductPathTemplate = @"/products?productIds=[{0}]";

        private static async Task<HttpResponseMessage> RequestProductFromProductCatalog(int[] productCatalogIds)
        {
            var productsResource = string.Format(getProductPathTemplate, string.Join(",", productCatalogIds));

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(productsResource);

                return await 
                    httpClient
                    .GetAsync(productsResource)
                    .ConfigureAwait(false);
            }
        }

        // Note: Convert from Product Catalog Microservice Domain to Shopping Cart Microservice Domin
        private static async Task<IEnumerable<ShoppingCartItem>> ConvertToShopppingCartItems(HttpResponseMessage response)
        {
            response.EnsureSuccessStatusCode();
            var products = JsonConvert.DeserializeObject<List<ProductCatalogProduct>>(
                    await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );

            return products.Select(p => new ShoppingCartItem(
                    int.Parse(p.ProductId),
                    p.ProductName,
                    p.ProductDescription,
                    p.Price
                ));
        }

        private static async Task<IEnumerable<ShoppingCartItem>> GetItemsFromCatalogService(int[] productIds)
        {
            var response = await RequestProductFromProductCatalog(productIds).ConfigureAwait(false);

            return await ConvertToShopppingCartItems(response).ConfigureAwait(false);
        }

        private class ProductCatalogProduct
        {
            public string ProductId { get; set; }
            public string ProductName { get; set; }
            public string ProductDescription { get; set; }
            public double Price { get; set; }
        }

        public Task<IList<ShoppingCartItem>> GetShoppingCartItems(int[] productCatalogIds)
        {
            throw new NotImplementedException();
        }
    }
}
