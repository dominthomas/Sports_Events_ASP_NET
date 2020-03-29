using System;
namespace Sports_Events_ASP_NET.Models
{
    public class AdministratorRepository : IAdministratorRepository
    {
        private ApplicationDbContext context;
        public AdministratorRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public Administrator Add(Administrator administrator)
        {
            context.Administrators.Add(administrator);
            context.SaveChanges();
            return administrator;
        }

        public Administrator Delete(int id)
        {
            Administrator admin = context.Administrators.Find(id);
            if(admin != null)
            {
                context.Administrators.Remove(admin);
                context.SaveChanges();
            }
            return admin;
        }
    }
}
