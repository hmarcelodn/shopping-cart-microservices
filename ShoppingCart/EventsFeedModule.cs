using Nancy;
using ShoppingCarts.Microservice.Interfaces;

namespace ShoppingCarts.Microservice
{
    public class EventsFeedModule: NancyModule
    {
        public EventsFeedModule(IEventStore eventStore) 
            : base("/events")
        {
            // Note: Events Endpoint
            Get("/", _ =>
            {
                return null;
            });
        }
    }
}
