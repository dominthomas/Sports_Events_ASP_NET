using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sports_Events_ASP_NET.Models;

namespace Sports_Events_ASP_NET.Controllers
{
    public class EventsController : Controller
    {
        private IRepository repository;

        public ViewResult Events() => View(repository.Events);
        /*
        public ViewResult EventsList() => View(repository.Events);

        public ViewResult Users() => View(repository.Users);

        public ViewResult Addresses() => View(repository.Addresses);

        public ViewResult Administrators() => View(repository.Administrators);

        public ViewResult Organisations() => View(repository.Organisations); */

        public EventsController (IRepository repo)
        {
            repository = repo;
        }
    }
}
