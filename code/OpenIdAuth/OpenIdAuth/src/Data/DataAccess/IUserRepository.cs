using System.Collections.Generic;
using OpenIdAuth.Data.Domain;

namespace OpenIdAuth.Data.DataAccess {
    public interface IUserRepository {
        IList<User> GetUsers();
        void Insert(User user);
        void Save();
        bool IsUserAvailable(string userName);
        void Delete(string userName);
    }
}