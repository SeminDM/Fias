using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseAPI.Interfaces;
using DatabaseAPI.Services;
using Fias.Infrastructure.Mappers;
using Fias.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Fias.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly UserMapper _userMapper;

        public UserController(IUserService userService, UserMapper userMapper)
        {
            _userService = userService;
            _userMapper = userMapper;
        }

        public IActionResult List()
        {
            var users = _userService.List().Select(u => _userMapper.Map(u));
            return View(users);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                var u = _userMapper.Map(user);
                if (u == null)
                {
                    throw new ArgumentNullException(nameof(user));
                }

                var errors = await _userService.CreateAsync(u);

                if (errors == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
            }
            return View(user);
        }

        public async Task<IActionResult> Get(string userName)
        {
            var user = await _userService.GetAsync(userName);
            var u = _userMapper.Map(user);
            return View("UserDetails", u);
        }
    }
}