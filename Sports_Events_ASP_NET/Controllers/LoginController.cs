using System;
using Microsoft.AspNetCore.Mvc;
using Sports_Events_ASP_NET.Models;

namespace Sports_Events_ASP_NET.Controllers
{
    public class LoginController : Controller
    {
        private IRepository repository;

        public LoginController(IRepository repo) => repository = repo;

        public ViewResult Login() => View();
    }
}