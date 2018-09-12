using System;
using System.Linq;
using System.Threading.Tasks;
using DatabaseAPI.Interfaces;
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
        public async Task<IActionResult> Register(UserViewModel user, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var u = _userMapper.Map(user);
                if (u == null)
                {
                    throw new ArgumentNullException(nameof(user));
                }

                var errors = await _userService.CreateAsync(u, user.Password);

                if (errors == null)
                {
                    if (string.IsNullOrEmpty(returnUrl))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return Redirect(returnUrl);
                    }
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

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _userService.LoginAsync(model.UserName, model.Password);

            if (string.IsNullOrEmpty(returnUrl))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return Redirect(returnUrl);
            }
        }

        public async Task<ActionResult> Logout()
        {
            await _userService.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Get(string userName)
        {
            var user = await _userService.GetAsync(userName);
            var u = _userMapper.Map(user);
            return View("UserDetails", u);
        }

        public async Task<ActionResult> Delete(string userName)
        {
            await _userService.DeleteAsync(userName);
            var users = _userService.List().Select(u => _userMapper.Map(u));
            return View("List", users);
        }
    }
}