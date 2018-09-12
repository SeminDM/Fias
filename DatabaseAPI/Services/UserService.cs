using System.Collections.Generic;
using System.Linq;
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

        public async Task<IList<string>> CreateAsync(User user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, true);
                return null;
            }
            else
            {
                return GetErrorsFromResult(result);
            }
        }

        public async Task<IList<string>> DeleteAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return null;
            }
            else
            {
                return GetErrorsFromResult(result);
            }
        }

        public async Task<User> GetAsync(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }

        public IList<User> List()
        {
            return _userManager.Users.ToList();
        }

        public async Task LoginAsync(string username, string password)
        {
            await _signInManager.SignOutAsync();
            var user = _userManager.FindByNameAsync(username).Result;
            await _signInManager.SignInAsync(user, null);
        }

        public async Task LoginAsync(User user)
        {
            await _signInManager.SignOutAsync();
            await _signInManager.SignInAsync(user, true);
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        private IList<string> GetErrorsFromResult(IdentityResult result)
        {
            return result.Errors.Select(er => er.Description).ToList();
        }
    }
}
