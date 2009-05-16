using MbUnit.Framework;
using System.Web.Mvc;
using OpenIdAuth.UI.Controllers;
using OpenIdAuth.Core.Services;
using Moq;

namespace OpenIdAuth.UnitTests.UI.Controllers {
    [TestFixture]
    public class RegisterControllerTests {

        [Test]
        public void IndexActionReturnsTheDefaultView() {
            var mockUserService = new Mock<IUserService>();
            var regController = new RegisterController(mockUserService.Object);
            ViewResult result = regController.Index() as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(string.Empty, result.ViewName);
        }

        [Test]
        public void CheckUserActionReturnsAJsonObject() {
            var mockUserService = new Mock<IUserService>();
            mockUserService.Setup(us => us.IsUserAvailable("test")).Returns(true);
            var regController = new RegisterController(mockUserService.Object);
            var result = regController.CheckUser("test") as JsonResult;
            Assert.IsNotNull(result);
        }

        //[Test]
        //public void CheckUserActionReturnsAJsonObject() {
        //    var mockUserService = new Mock<IUserService>();
        //    var regController = new RegisterController(mockUserService.Object);
        //    var result = regController.Index() as JsonResult;
        //    System.Console.WriteLine(result.Data);
        //}


    }
}
