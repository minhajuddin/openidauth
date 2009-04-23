using System.Collections.Generic;
using OpenIdAuth.Data.Domain;

namespace OpenIdAuth.Service
{
    public interface IUserService
    {
        IList<User> GetUsers();
        void Insert(User user);
        void Save();
        bool IsUserAvailable(string userName);
        void Delete(string userName);
    }
}