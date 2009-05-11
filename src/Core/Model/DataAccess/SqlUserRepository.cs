using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenIdAuth.Core.Model.DataAccess.Context;
using OpenIdAuth.Core.Model.Domain;
using OpenIdAuth.Core.Model.DataAccess;
using OpenIdAuth.Core.Configuration;

namespace OpenIdAuth.Core.Model.DataAccess {
    public class SqlUserRepository : IUserRepository {
        private readonly DB _db;

        public SqlUserRepository() {
            _db = new DB(Config.GetConnectionString());
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