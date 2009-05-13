using MbUnit.Framework;
using System.Linq;
using OpenIdAuth.Core.Model.DataAccess.Context;
using OpenIdAuth.Core.Configuration;

namespace OpenIdAuth.UnitTests.Infrastructure {
    [TestFixture]
    public class DatabaseMaintenance {

        [Test]
        [Ignore]
        public void CreateDatbase() {
            var cs = @"Data Source=.\SQLEXPRESS;Initial Catalog=OpenIdAuth;Integrated Security=True";
            var db = new DB(cs);
            db.CreateDatabase();
        }

    }
}
