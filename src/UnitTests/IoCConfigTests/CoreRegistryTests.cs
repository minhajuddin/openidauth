using MbUnit.Framework;
using StructureMap;
using OpenIdAuth.Core.Model.DataAccess;
using OpenIdAuth.Core.Services;

namespace OpenIdAuth.UnitTests.IoCConfigTests {
    [TestFixture]
    public class CoreRegistryTests {

        [FixtureSetUp]
        public void FixtureSetup() {
            OpenIdAuth.UI.Infrastructure.DI.BootStrapper.ConfigureStructureMap();
        }


        //ForRequestedType<IImageRepository>()
        //    .TheDefaultIsConcreteType<SqlImageRepository>();
        [Test]
        public void CanGetImageRepository() {
            var result = ObjectFactory.GetInstance<IImageRepository>() as SqlImageRepository;
            Assert.IsNotNull(result);
        }

        //ForRequestedType<IUserRepository>()
        //    .TheDefaultIsConcreteType<SqlUserRepository>();

        [Test]
        public void CanGetUserRepository() {
            var result = ObjectFactory.GetInstance<IUserRepository>() as SqlUserRepository;
            Assert.IsNotNull(result);
        }


        //ForRequestedType<IAuthenticationService>()
        //    .TheDefaultIsConcreteType<AuthenticationService>();

        [Test]
        public void CanGetAuthenticationService() {
            var result = ObjectFactory.GetInstance<IAuthenticationService>() as AuthenticationService;
            Assert.IsNotNull(result);
        }


        //ForRequestedType<IImageService>()
        //    .TheDefaultIsConcreteType<ImageService>();

        [Test]
        public void CanGetImageService() {
            var result = ObjectFactory.GetInstance<IImageService>() as ImageService;
            Assert.IsNotNull(result);
        }

        //ForRequestedType<IUserService>()
        //    .TheDefaultIsConcreteType<UserService>();

        [Test]
        public void CanGetUserService() {
            var result = ObjectFactory.GetInstance<IUserService>() as UserService;
            Assert.IsNotNull(result);
        }
    }
}
