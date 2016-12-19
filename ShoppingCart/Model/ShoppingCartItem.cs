namespace ShoppingCarts.Microservice.Model
{
    public class ShoppingCartItem
    {
        private double price;
        private string productDescription;
        private string productName;
        private int productId;

        public ShoppingCartItem(int productId, string productName, string productDescription, double price)
        {
            this.productId = productId;
            this.productName = productName;
            this.productDescription = productDescription;
            this.price = price;
        }
    }
}
