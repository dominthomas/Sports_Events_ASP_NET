using System;
namespace Sports_Events_ASP_NET.Models
{
    public interface IAddressRepository
    {
        Address Add(Address address);
        Address Update(Address address);
        Address Delete(int id);
    }
}
