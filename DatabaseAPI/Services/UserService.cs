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

        public Task EditAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetAsync(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
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

        public async Task<IList<string>> CreateAsync(User user)
        {
            var result = await _userManager.CreateAsync(user);
            if (result.Succeeded)
            {
                return null;
            }
            else
            {
                return result.Errors.Select(er => er.Description).ToList();
            }
        }

        public IList<User> List()
        {
            return _userManager.Users.ToList();
        }

        public Task LoginAsync(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
