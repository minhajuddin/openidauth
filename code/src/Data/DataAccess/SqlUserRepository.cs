using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenIdAuth.Data.DataAccess.Context;
using OpenIdAuth.Data.Domain;

namespace OpenIdAuth.Data.DataAccess {
    public class SqlUserRepository : IUserRepository {
        private readonly DBDataContext _db;

        public SqlUserRepository() {
            _db = new DBDataContext(OpenIdAuthConfiguration.GetConnectionString());
        }

        public IList<User> GetUsers() {
            return _db.Users.Select(x => ConversionHelper.ConvertToDomainUser(x))
                .ToList();
        }

        public User GetUser(string userName) {
            var user = _db.Users
                        .Where(x => string.Compare(x.UserName, userName, StringComparison.OrdinalIgnoreCase) == 0)
                        .SingleOrDefault();
            return user != null ? ConversionHelper.ConvertToDomainUser(user) : null;
        }

        public void Insert(User user) {
            if (!IsUserAvailable(user.UserName)) {
                throw new ArgumentException("UserName is not available");
            }

            _db.Users.InsertOnSubmit(ConversionHelper.ConvertToEntityUser(user));
        }

        public void Save() {
            _db.SubmitChanges();
        }

        public bool IsUserAvailable(string userName) {
            var result =
                _db.Users
                .Where(x => string.Compare(x.UserName, userName, StringComparison.OrdinalIgnoreCase) == 0)
                .Count();
            return result == 0;
        }

        public void Delete(string userName) {
            var user = _db.Users
                        .Where(x => string.Compare(x.UserName, userName, StringComparison.OrdinalIgnoreCase) == 0)
                        .SingleOrDefault();
            _db.Users.DeleteOnSubmit(user);
        }

    }
}