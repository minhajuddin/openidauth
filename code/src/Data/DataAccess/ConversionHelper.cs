using OpenIdAuth.Data.Domain;

namespace OpenIdAuth.Data.DataAccess
{
    public static class ConversionHelper {
        public static User ConvertUser(Entity.User user) {
            return new User(user.UserName, user.Password) { UserID = user.UserId };
        }
    }
}