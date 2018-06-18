using DatabaseAPI.Models;
using Fias.ViewModels;

namespace Fias.Infrastructure.Mappers
{
    public class UserMapper
    {
        public UserViewModel Map(User source)
        {
            if (source == null)
                return null;

            return new UserViewModel
            {
                Id = source.Id,
                UserName = source.UserName,
                Name = source.Name,
                DateOfBirth = source.DateOfBirth,
                Email = source.Email,
                Phone = source.PhoneNumber
            };
        }

        public User Map(UserViewModel source)
        {
            if (source == null)
                return null;

            return new User
            {
                Id = source.Id,
                UserName = source.UserName,
                Name = source.Name,
                DateOfBirth = source.DateOfBirth,
                Email = source.Email,
                PhoneNumber = source.Phone
            };
        }
    }
}
