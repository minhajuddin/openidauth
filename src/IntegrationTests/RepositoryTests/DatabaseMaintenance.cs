using OpenIdAuth.Core.Model.DataAccess.Context;
using OpenIdAuth.Core.Configuration;
using Entity = OpenIdAuth.Core.Model.DataAccess.Entity;

namespace OpenIdAuth.IntegrationTests.RepositoryTests {
    public class DatabaseMaintenance {
        private static DB Db;

        static DatabaseMaintenance() {
            Db = new DB(Config.GetConnectionString());
        }

        public static void PopulateData() {
            CreateDatabase();
            //Populate repository with test data
            Db.Users.InsertAllOnSubmit(
                new[] {
                    new Entity.User{UserName="Jack",Password="jake"},
                    new Entity.User{UserName="Rob",Password="con"},
                    new Entity.User{UserName="Scott",Password="Han"}
                });
            Db.SubmitChanges();
        }

        private static void CreateDatabase() {
            DeleteDatabase();
            Db.CreateDatabase();
        }

        private static void DeleteDatabase() {
            if (Db.DatabaseExists())
                Db.DeleteDatabase();
        }

    }
}