using System;
namespace Sports_Events_ASP_NET.Models
{
    public interface IUserRepository
    {
        User Add(User user);
        User Update(User user);
        User Delete(int userID);
        User GetUser(int userID);
    }
}
