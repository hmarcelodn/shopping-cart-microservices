namespace ShoppingCarts.Microservice.Interfaces
{
    public interface IEventStore
    {
        void Save(object obj);

        void Raise(string eventName, object content);
    }
}
