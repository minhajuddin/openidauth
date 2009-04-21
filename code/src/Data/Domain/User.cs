namespace OpenIdAuth.Data.Domain {
    public class User {

        public User(string userName) {
            UserName = userName;
        }

        public string UserName { get; private set; }
    }
}