using System;
namespace Sports_Events_ASP_NET.Models
{
    public class EventRepository : IEventRepository
    {
        private ApplicationDbContext context;

        public EventRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public Event Add(Event ev)
        {
            context.Events.Add(ev);
            context.SaveChanges();
            return ev;
        }

        public Event Delete(int id)
        {
            Event ev = context.Events.Find(id);
            if(ev != null)
            {
                context.Remove(ev);
                context.SaveChanges();
            }
            return ev;
        }

        public Event Update(Event evChanges)
        {
            var ev = context.Events.Attach(evChanges);
            ev.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return evChanges;
        }
    }
}
