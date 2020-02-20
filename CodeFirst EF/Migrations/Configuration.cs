using System.Data.Entity.Migrations;

namespace CodeFirst_EF.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<CodeFirst_EF.IndexedContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CodeFirst_EF.IndexedContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
