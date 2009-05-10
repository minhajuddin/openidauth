namespace OpenIdAuth.Core.Model.DataAccess {
    public interface IAuthenticationRepository {
        bool AuthenticateUser(string userName, string password);
    }
}