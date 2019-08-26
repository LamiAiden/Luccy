using System.Data.Entity.Migrations;

namespace Luccy.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Luccy.EntityFramework.LuccyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Luccy";
        }

        protected override void Seed(Luccy.EntityFramework.LuccyDbContext context)
        {
            // This method will be called every time after migrating to the latest version.
            // You can add any seed data here...
        }
    }
}
