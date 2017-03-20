namespace MySharedBudget.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<MySharedBudget.Data.MySharedBudgetDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MySharedBudget.Data.MySharedBudgetDbContext context)
        {
        }
    }
}