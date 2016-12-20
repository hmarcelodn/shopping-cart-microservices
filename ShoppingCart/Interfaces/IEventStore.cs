using System.Collections.Generic;
using ShoppingCarts.Microservice.EventFeed;

namespace ShoppingCarts.Microservice.Interfaces
{
    public interface IEventStore
    {
        IEnumerable<Event> GetEvents(long firsEventSequenceNumber, long lastEventSequenceNumber);

        void Raise(string eventName, object content);
    }
}
