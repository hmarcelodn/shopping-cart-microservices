using ShoppingCarts.Microservice.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace ShoppingCarts.Microservice.EventFeed
{
    public class EventStore : IEventStore
    {
        private static long currentSequenceNumber = 0;
        private static readonly IList<Event> database = new List<Event>();

        public IEnumerable<Event> GetEvents(long firsEventSequenceNumber, long lastEventSequenceNumber)
        {
            return database.Where(e => e.SequenceNumber >= firsEventSequenceNumber && e.SequenceNumber <= lastEventSequenceNumber)
                           .OrderBy(e => e.SequenceNumber);
        }

        public void Raise(string eventName, object content)
        {
            var seqNumber = Interlocked.Increment(ref currentSequenceNumber);

            database.Add(
                new Event(seqNumber, DateTimeOffset.UtcNow, eventName, content)
            );
        }
    }
}
