using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseAPI.Models;

namespace DatabaseAPI.Interfaces
{
    public interface IUserService
    {
        Task<IList<string>> CreateAsync(User user, string password);

        Task<IList<string>> DeleteAsync(string userName);

        Task<User> GetAsync(string userName);

        IList<User> List();

        Task LoginAsync(string username, string password);

        Task LoginAsync(User user);

        Task LogoutAsync();
    }
}
