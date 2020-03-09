using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsEvents.Models
{
    public class EventRepository : IEventRepository
    {
        private ApplicationDbContext context;

        public EventRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Event> Events => context.Events;
    }
}
