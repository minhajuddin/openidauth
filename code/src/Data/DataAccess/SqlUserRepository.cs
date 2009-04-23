using System;
using System.Collections.Generic;
using System.Linq;
using OpenIdAuth.Data.DataAccess.Context;
using OpenIdAuth.Data.Domain;

namespace OpenIdAuth.Data.DataAccess {
    public class SqlUserRepository : IUserRepository {
        private readonly DBDataContext _db;

        public SqlUserRepository() {
            _db = new DBDataContext(OpenIdAuthConfiguration.GetConnectionString());
        }

        public IList<User> GetUsers() {
            return _db.Users.Select(x => ConversionHelper.ConvertUser(x))
                .ToList();
        }

        public User GetUser(string userName) {
            var user = _db.Users
                        .Where(x => string.Compare(x.UserName, userName, StringComparison.OrdinalIgnoreCase) == 0)
                        .SingleOrDefault();
            return user != null ? ConversionHelper.ConvertUser(user) : null;
        }

        public void Insert(User user) {
            throw new NotImplementedException();
        }

        public void Save() {
            throw new NotImplementedException();
        }

        public bool IsUserAvailable(string userName) {
            throw new NotImplementedException();
        }

        public void Delete(string userName) {
            throw new NotImplementedException();
        }

    }
}