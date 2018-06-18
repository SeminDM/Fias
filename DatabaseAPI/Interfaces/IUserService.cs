using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DatabaseAPI.Models;

namespace DatabaseAPI.Interfaces
{
    public interface IUserService
    {
        Task<IList<string>> CreateAsync(User user);

        Task EditAsync(User user);

        Task DeleteAsync(string userName);

        Task<User> GetAsync(string userName);

        IList<User> List();

        Task LoginAsync(string username, string password);
    }
}
