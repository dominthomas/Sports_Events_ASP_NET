using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sports_Events_ASP_NET.Models;

namespace Sports_Events_ASP_NET.Models
{
    public class Repository : IRepository
    {
        private ApplicationDbContext context;

        public Repository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Event> Events => context.Events;

        public IQueryable<User> Users => context.Users;

        public IQueryable<Address> Addresses => context.Addresses;

        public IQueryable<Administrator> Administrators => context.Administrators;

        public IQueryable<Organisation> Organisations => context.Organisations;
    }
}
