using IntelitraderMobile.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntelitraderMobile.Services
{
    public interface IUserService
    {
        Task AddUser(User user);
        Task UpdateUser(string id, User user);
        Task DeleteUser(string id);
        Task<User> GetUser(string id);
        Task<IEnumerable<User>> GetUsers();
    }
}
