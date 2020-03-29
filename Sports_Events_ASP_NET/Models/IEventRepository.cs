using System;
namespace Sports_Events_ASP_NET.Models
{
    public interface IEventRepository
    {
        Event Add(Event ev);
        Event Update(Event ev);
        Event Delete(int id);
    }
}
