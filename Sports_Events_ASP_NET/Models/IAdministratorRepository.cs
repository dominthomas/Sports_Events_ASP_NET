using System;
namespace Sports_Events_ASP_NET.Models
{
    public interface IAdministratorRepository
    {
        Administrator Add(Administrator administrator);
        Administrator Delete(int id);
    }
}
