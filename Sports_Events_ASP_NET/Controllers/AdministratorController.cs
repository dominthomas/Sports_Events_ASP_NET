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

        private string loginID = "loginID";

        private string err = "err";

        public AdministratorController(IRepository repo) => repository = repo;

        public ViewResult Administrator(string inputUserEmail, string inputPassword)
        {
            string sessionVal = HttpContext.Session.GetString(loginID);

            if(inputUserEmail != null && inputPassword != null)
            {
                validate(inputUserEmail, inputPassword);
                sessionVal = HttpContext.Session.GetString(loginID);
            }

            if (sessionVal != null && !sessionVal.Equals(err))
            {
                return View(getAllAdminUserInfo());
            }

            if(sessionVal != null && sessionVal.Equals(err))
            {
                return View("Login", err);
            }

            if (sessionVal == null)
            {
                return View("Login");
            }

            return View(getAllAdminUserInfo());
        }

        private IQueryable<User> getAllAdminUserInfo()
        {
            List<int> AdminIDs = getAdminIDs();

            IQueryable<User> AllUsers = repository.Users;

            IQueryable<User> AdminUsers = AllUsers.Where(user => AdminIDs.Contains(user.UserID));

            return AdminUsers;
        }

        private void validate(string userEmail, string userPassword)
        {
            List<int> AdminIDs = getAdminIDs();

            IQueryable<User> loginUser = repository.Users.Where
                (user => user.Email.Equals(userEmail));

            Boolean isUserAdmin = AdminIDs.Any(id => id == loginUser.First().UserID);

            // We will know if the user is an Admin, hence therefore, the user's
            // email is correct! So we just need to check the password.
            Boolean passOK = loginUser.First().Password.Equals(userPassword);

            if(isUserAdmin && passOK)
            {
                HttpContext.Session.SetString(loginID, loginUser.First().UserID.ToString());
            }

            else
            {
                HttpContext.Session.SetString(loginID, err);
            }
        }

        private List<int> getAdminIDs()
        {
            return repository.Administrators.Select(user => user.UserID).ToList();
        }
    }
}