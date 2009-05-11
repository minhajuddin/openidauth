using MbUnit.Framework;
using OpenIdAuth.UI.Controllers;
using System.Web.Mvc;

namespace OpenIdAuth.UnitTests.UI.Controllers {
    [TestFixture]
    class HomeControllerTests {
        [Test]
        public void CanGetIndexView() {
            var homeController = new HomeController();
            var result = homeController.Index();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(typeof(ViewResult), result);
        }
    }
}
