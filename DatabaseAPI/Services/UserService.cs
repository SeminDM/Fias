using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAPI.Interfaces;
using DatabaseAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace DatabaseAPI.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task CreateAsync(User user)
        {
            await _userManager.CreateAsync(user);
        }

        public void Edit(User user)
        {
            throw new NotImplementedException();
        }

        public void Delete(string userName)
        {
            throw new NotImplementedException();
        }

        public User Get(string userName)
        {
            throw new NotImplementedException();
        }

        public IList<User> List()
        {
            return _userManager.Users.ToList();
        }
    }
}
