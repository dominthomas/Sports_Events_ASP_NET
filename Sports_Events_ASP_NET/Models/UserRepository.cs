using System;
namespace Sports_Events_ASP_NET.Models
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext context;

        public UserRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public User Add(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return user;
        }

        public User Delete(int userID)
        {
            User user = context.Users.Find(userID);
            if(user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
            return user;
        }

        public User Update(User user)
        {
            var us = context.Users.Attach(user);
            us.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return user;
        }

        public User GetUser(int id)
        {
            return context.Users.Find(id);
        }
    }
}
