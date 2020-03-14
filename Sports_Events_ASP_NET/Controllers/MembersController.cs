using System;
using Microsoft.AspNetCore.Mvc;
using Sports_Events_ASP_NET.Models;

namespace Sports_Events_ASP_NET.Controllers
{
    public class MembersController : Controller
    {
        private IRepository repository;

        public MembersController(IRepository repo) => repository = repo;

        public ViewResult Members() => View(model: repository.Users);
    }
}
