using StructureMap.Configuration.DSL;
using OpenIdAuth.Core.Model.DataAccess;
using OpenIdAuth.Core.Services;

namespace OpenIdAuth.Core.Infrastructure {
    public class CoreRegistry : Registry {
        protected override void configure() {

            ForRequestedType<IImageRepository>()
                .TheDefaultIsConcreteType<SqlImageRepository>();
            ForRequestedType<IUserRepository>()
                .TheDefaultIsConcreteType<SqlUserRepository>();

            ForRequestedType<IAuthenticationService>()
                .TheDefaultIsConcreteType<AuthenticationService>();
            ForRequestedType<IImageService>()
                .TheDefaultIsConcreteType<ImageService>();
            ForRequestedType<IUserService>()
                .TheDefaultIsConcreteType<UserService>();

        }
    }
}
