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

        public EventsController (IRepository repo)
        {
            repository = repo;
        }

        public ViewResult Events() => View(repository);
    }
}
