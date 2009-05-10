namespace OpenIdAuth.Core.Model.Domain {
    public class User {
        public int UserID { get; set; }
        public string Password { get; set; }
        public string UserName { get; private set; }
        public User(string userName, string password) {
            Password = password;
            UserName = userName;
        }
    }
}