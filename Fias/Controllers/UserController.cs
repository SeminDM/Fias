using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseAPI.Interfaces;
using DatabaseAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fias.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult List()
        {
            var users = _userService.List();
            return View(users);
        }
    }
}