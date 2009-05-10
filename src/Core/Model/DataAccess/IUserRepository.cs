using System.Collections.Generic;
using OpenIdAuth.Core.Model.Domain;

namespace OpenIdAuth.Core.Model.DataAccess {
    public interface IUserRepository {
        IList<User> GetUsers();
        void Insert(User user);
        void Save();
        bool IsUserAvailable(string userName);
        void Delete(string userName);
        User GetUser(string userName);
    }
}