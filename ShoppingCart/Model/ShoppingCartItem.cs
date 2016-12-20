namespace ShoppingCarts.Microservice.Model
{
    public class ShoppingCartItem
    {
        public Money Price { get; private set; }
        public string ProductDescription { get; private set; }
        public string ProductName { get; private set; }
        public int ProductId { get; private set; }

        public ShoppingCartItem(int productId, string productName, string productDescription, Money price)
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.ProductDescription = productDescription;
            this.Price = price;
        }
    }
}
