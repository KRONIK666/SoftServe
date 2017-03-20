namespace MySharedBudget.Web
{
    using System.Data.Entity;

    using MySharedBudget.Data;
    using MySharedBudget.Data.Migrations;

    public class DatabaseConfig
    {
        public static void RegisterMigrations()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MySharedBudgetDbContext, Configuration>());
        }
    }
}