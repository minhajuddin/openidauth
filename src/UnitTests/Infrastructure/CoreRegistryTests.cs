using MbUnit.Framework;
using OpenIdAuth.UI.Infrastructure.DI;
using OpenIdAuth.UI.Controllers;
using UnitTests;
using System.Web.Routing;

namespace OpenIdAuth.UnitTests.Infrastructure {

    [TestFixture]
    public class CoreRegistryTests {

        private IoCControllerFactory _factory;

        [FixtureSetUp]
        public void FixtureSetup() {
            BootStrapper.ConfigureStructureMap();
            _factory = new IoCControllerFactory();
        }

        [Test]
        public void CanGetARegisterController() {
            var controller = _factory.CreateController(new RequestContext(MvcMockHelpers.FakeHttpContext(), new RouteData()), "Register") as RegisterController;
            Assert.IsNotNull(controller);
        }

        [Test]
        public void CanGetAHomeController() {
            var controller = _factory.CreateController(new RequestContext(MvcMockHelpers.FakeHttpContext(), new RouteData()), "Home") as HomeController;
            Assert.IsNotNull(controller);
        }


    }

}
