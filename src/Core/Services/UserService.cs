using System.Collections.Generic;
using OpenIdAuth.Core.Model.DataAccess;
using OpenIdAuth.Core.Model.Domain;

namespace OpenIdAuth.Core.Services {
    public class UserService : IUserService {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository) {
            _repository = repository;
        }

        public IList<User> GetUsers() {
            return _repository.GetUsers();
        }

        public void Insert(User user) {
            _repository.Insert(user);
        }

        public void Save() {
            _repository.Save();
        }

        public bool IsUserAvailable(string userName) {
            return _repository.IsUserAvailable(userName);
        }

        public void Delete(string userName) {
            _repository.Delete(userName);
        }
    }
}