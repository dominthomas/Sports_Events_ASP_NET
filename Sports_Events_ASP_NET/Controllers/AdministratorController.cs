using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sports_Events_ASP_NET.Models;

namespace Sports_Events_ASP_NET.Controllers
{
    public class AdministratorController : Controller
    {
        private IAddressRepository addrRepository;

        private IEventRepository eventRepository;

        private IUserRepository userRepository;

        private IAdministratorRepository administratorRepositroy;

        private IRepository repository;

        private string loginID = "loginID";

        private string err = "err";

        public AdministratorController(IRepository repo, IAddressRepository addr, IEventRepository ev, IUserRepository us, IAdministratorRepository admin)
        {
            this.repository = repo;
            this.addrRepository = addr;
            this.eventRepository = ev;
            this.userRepository = us;
            this.administratorRepositroy = admin;
        }

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
                return View(getAllUserInfo());
            }

            if(sessionVal != null && sessionVal.Equals(err))
            {
                return View("Login", err);
            }

            if (sessionVal == null)
            {
                return View("Login");
            }

            return View(getAllUserInfo());
        }

        public ViewResult Logout()
        {
            HttpContext.Session.Remove(loginID);
            return View();
        }

        public ViewResult SubmitEdit(int userID, string userEmail, string userPassword, string userName, string userPhone, int userAddressID, string userDOB, string userGender,
            string userWorkLocation, string userBio, string userSkills, Boolean makeAdmin)
        {
            User user = new User();
            user.UserID = userID;
            user.Email = userEmail;
            user.Password = userPassword;
            user.Name = userName;
            user.Phone = userPhone;
            user.AddressID = userAddressID;
            user.DateOfBirth = getUnixDate(userDOB);
            user.Gender = userGender;
            user.WorkLocation = userWorkLocation;
            user.Bio = userBio;
            user.Skills = userSkills;

            userRepository.Update(user);
            return View("Administrator", getAllUserInfo());
        }

        private IQueryable<User> getAllUserInfo()
        {
            List<int> AdminIDs = getAdminIDs();

            IQueryable<User> AllUsers = repository.Users;

            foreach (User user in AllUsers)
            {
                if(AdminIDs.Contains(user.UserID))
                {
                    user.SetUserAdmin(true);
                }
                else
                {
                    user.SetUserAdmin(false);
                }
            }
            return AllUsers;
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

        private int getUnixDate(string date)
        {
            date = date.Trim();

            Match m = Regex.Match(date, @"(\d*)\/(\d*)\/(\d*)");

            int year = Int32.Parse(m.Groups[1].ToString());
            int month = Int32.Parse(m.Groups[2].ToString());
            int day = Int32.Parse(m.Groups[3].ToString());

            DateTime datetime = new DateTime(year, month, day, 0, 0, 0, DateTimeKind.Utc);
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            Int32 unixTimestamp = (Int32)(datetime.ToUniversalTime() - epoch).TotalSeconds;

            return unixTimestamp;
        }
    }
}