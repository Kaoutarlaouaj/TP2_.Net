using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Authentification.JWT.DAL.Entities;

namespace Authentification.JWT.DAL.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByUsernameAsync(string username);
        Task<User> RegisterUserAsync(User user);
    }
}
