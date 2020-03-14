using System;
using Microsoft.AspNetCore.Mvc;
using Sports_Events_ASP_NET.Models;

namespace Sports_Events_ASP_NET.Controllers
{
    public class AdministratorController : Controller
    {
        private IRepository repository;

        public ViewResult Administrator() => View(repository.Administrators);

        public AdministratorController(IRepository repo)
        {
            repository = repo;
        }
    }
}
