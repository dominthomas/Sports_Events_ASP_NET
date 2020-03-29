using System;
namespace Sports_Events_ASP_NET.Models
{
    public class AddressRepository : IAddressRepository
    {
        private ApplicationDbContext context;

        public AddressRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public Address Add(Address address)
        {
            context.Addresses.Add(address);
            context.SaveChanges();
            return address;
        }

        public Address Delete(int id)
        {
            Address addr = context.Addresses.Find(id);
            if(addr != null)
            {
                context.Addresses.Remove(addr);
                context.SaveChanges();
            }
            return addr;
        }

        public Address Update(Address address)
        {
            var addr = context.Addresses.Attach(address);
            addr.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return address;
        }
    }
}
