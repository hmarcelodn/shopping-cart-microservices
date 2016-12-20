using ShoppingCarts.Microservice.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCarts.Microservice.Event
{
    public class EventStore : IEventStore
    {
        public void Raise(string eventName, object content)
        {
            //throw new NotImplementedException();
        }

        public void Save(object obj)
        {
            //throw new NotImplementedException();
        }
    }
}
