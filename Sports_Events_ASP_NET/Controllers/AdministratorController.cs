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
                return View(repository);
            }

            if(sessionVal != null && sessionVal.Equals(err))
            {
                return View("Login", err);
            }

            if (sessionVal == null)
            {
                return View("Login");
            }

            return View(repository);
        }

        public ViewResult Logout()
        {
            HttpContext.Session.Remove(loginID);
            return View();
        }

        public ViewResult SubmitEdit(string submitButton, int userID, string userEmail, string userPassword, string userName, string userPhone, string userDOB, string userGender,
            string userWorkLocation, string userBio, string userSkills, int makeAdmin, int userAddressID, string userAddrFirstLine, string userAddrTown,
            string userAddrPostCode, string userAddrCountry)
        {
            if(submitButton != null && submitButton.Trim().Equals("deleteUser"))
            {
                return DeleteUser(userID);
            }

            User user = new User
            {
                UserID = userID,
                Email = userEmail,
                Password = userPassword,
                Name = userName,
                Phone = userPhone,
                AddressID = userAddressID,
                DateOfBirth = getUnixDate(userDOB),
                Gender = userGender,
                WorkLocation = userWorkLocation,
                Bio = userBio,
                Skills = userSkills
            };

            userRepository.Update(user);

            updateUserAddress(userAddressID, userAddrFirstLine, userAddrTown, userAddrPostCode, userAddrCountry);

            addPrivileges(userID, makeAdmin);

            return View("Administrator", repository);
        }

        public ViewResult AddNewUser(string addUserEmail, string addUserPassword, string addUserName, string addUserPhone, string addUserDOB, string addUserGender,
            string addUserWorkLocation, string addUserBio, string addUserSkills, int addMakeAdmin, string addUserAddrFirstLine, string addUserAddrTown,
            string addUserAddrPostCode, string addUserAddrCountry)
        {
            Address addr = addUserAddress(addUserAddrFirstLine, addUserAddrTown, addUserAddrPostCode, addUserAddrCountry);

            User user = new User
            {
                Email = addUserEmail,
                Password = addUserPassword,
                Name = addUserName,
                Phone = addUserPhone,
                AddressID = addr.AddressID,
                DateOfBirth = getUnixDate(addUserDOB),
                Gender = addUserGender,
                WorkLocation = addUserWorkLocation,
                Bio = addUserBio,
                Skills = addUserSkills
            };

            User usr = userRepository.Add(user);
            addPrivileges(usr.UserID, addMakeAdmin);
            return View("Administrator", repository);
        }

        private ViewResult DeleteUser(int deleteUserID)
        {
            User usr = userRepository.GetUser(deleteUserID);
            System.Diagnostics.Debug.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            System.Diagnostics.Debug.WriteLine(deleteUserID);
            userRepository.Delete(deleteUserID);
            addrRepository.Delete(usr.AddressID);

            return View("Administrator", repository);
        }

        private void addPrivileges(int userID, int priveleges)
        {
            List<int> AdminIDs = getAdminIDs();
            if (priveleges == 2)
            {
                if (!AdminIDs.Contains(userID))
                {
                    Administrator administrator = new Administrator();
                    administrator.UserID = userID;
                    administratorRepositroy.Add(administrator);
                }
            }
            else if (priveleges == 1)
            {
                if (AdminIDs.Contains(userID))
                {
                    administratorRepositroy.Delete(userID);
                }
            }
        }

        private void updateUserAddress(int id, string firstLine, string town, string postcode, string country)
        {
            Address addr = new Address
            {
                AddressID = id,
                FirstLine = firstLine,
                Town = town,
                PostCode = postcode,
                Country = country
            };

            addrRepository.Update(addr);
        }

        private Address addUserAddress(string fl, string t, string pc, string c)
        {
            Address addr = new Address
            {
                FirstLine = fl,
                Town = t,
                PostCode = pc,
                Country = c
            };

            return addrRepository.Add(addr);
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