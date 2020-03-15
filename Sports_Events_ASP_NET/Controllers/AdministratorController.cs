using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sports_Events_ASP_NET.Models;

namespace Sports_Events_ASP_NET.Controllers
{
    public class AdministratorController : Controller
    {
        private IRepository repository;

        public AdministratorController(IRepository repo) => repository = repo;

        public ViewResult Administrator()
        {
            string bob = "bob";
            HttpContext.Current.Session["bob"] = bob;

            if (HttpContext.Session["login_user"] == null)
            {
                return View("Login", User);
            }
            return View(getAllAdminUserInfo());
        }

        private IQueryable<User> getAllAdminUserInfo()
        {

            IQueryable<Administrator> Admins = repository.Administrators;
            List<int> AdminIDs = Admins.Select(user => user.UserID).ToList();

            IQueryable<User> AllUsers = repository.Users;

            IQueryable<User> AdminUsers = AllUsers.Where(user => AdminIDs.Contains(user.UserID));

            return AdminUsers;
        }
    }
}