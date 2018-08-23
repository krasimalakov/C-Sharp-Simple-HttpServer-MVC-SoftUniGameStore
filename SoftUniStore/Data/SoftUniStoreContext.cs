namespace SoftUniStore.Data
{
    using System.Data.Entity;
    using Migrations;
    using Models;
    using Security;

    public class SoftUniStoreContext : DbContext
    {
        public SoftUniStoreContext()
            : base("SoftUniStoreContext")
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<SoftUniStoreContext, Configuration>());
        }


        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<Game> Games { get; set; }
    }
}