using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DatabaseAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace DatabaseAPI.Interfaces
{
    public interface IUserService
    {
        Task<IList<string>> CreateAsync(User user, string password);

        Task<IList<string>> DeleteAsync(string userName);

        Task<User> GetAsync(string userName);

        IList<User> List();

        Task LoginAsync(string username, string password);

        void LoginAsync(User user);
    }
}
