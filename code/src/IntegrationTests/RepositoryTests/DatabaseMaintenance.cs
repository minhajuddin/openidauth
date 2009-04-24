using OpenIdAuth.Data;
using OpenIdAuth.Data.DataAccess.Context;

namespace OpenIdAuth.IntegrationTests.RepositoryTests {
    public class DatabaseMaintenance {
        private static DBDataContext Db;

        static DatabaseMaintenance() {
            Db = new DBDataContext(OpenIdAuthConfiguration.GetConnectionString());
        }

        public static void PopulateData() {
            CreateDatabase();
            //Populate repository with test data
            Db.Users.InsertAllOnSubmit(
                new[] {
                    new Data.DataAccess.Entity.User{UserName="Jack",Password="jake"},
                    new Data.DataAccess.Entity.User{UserName="Rob",Password="con"},
                    new Data.DataAccess.Entity.User{UserName="Scott",Password="Han"}
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