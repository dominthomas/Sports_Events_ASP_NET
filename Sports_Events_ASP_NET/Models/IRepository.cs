using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sports_Events_ASP_NET.Models;

namespace SportsEvents.Models
{
    public interface IRepository
    {
        IQueryable<Event> Events { get; }
        IQueryable<User> Users { get; }
        IQueryable<Address> Addresses { get; }
        IQueryable<Administrator> Administrators { get; }
        IQueryable<Organisation> Organisations { get; }
    }

}
