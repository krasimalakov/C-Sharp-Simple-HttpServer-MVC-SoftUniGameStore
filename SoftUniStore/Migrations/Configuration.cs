namespace SoftUniStore.Migrations
{
    using System.Data.Entity.Migrations;
    using Data;

    internal sealed class Configuration : DbMigrationsConfiguration<SoftUniStoreContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SoftUniStoreContext context)
        {
        }
    }
}