using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DatabaseAPI.Models;

namespace DatabaseAPI.Interfaces
{
    public interface IUserService
    {
        Task CreateAsync(User user);

        void Edit(User user);

        void Delete(string userName);

        User Get(string userName);

        IList<User> List();
    }
}
