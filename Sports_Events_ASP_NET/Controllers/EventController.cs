using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsEvents.Models;

namespace SportsEvents.Controllers
{
    public class EventController : Controller
    {
        private IEventRepository repository;
        public ViewResult List() => View(repository.Events);

        public EventController (IEventRepository repo)
        {
            repository = repo;
        }
    }
}
