namespace OpenIdAuth.Data.Domain {
    public class User {
        public int UserID { get; set; }
        private string _password;
        public string UserName { get; private set; }
        public User(string userName, string password) {
            _password = password;
            UserName = userName;
        }
    }
}