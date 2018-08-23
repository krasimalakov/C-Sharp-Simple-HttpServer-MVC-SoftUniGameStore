namespace SoftUniStore.Data
{
    using System.Data.Entity;
    using Contracts;
    using Models;
    using Security;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext context;
        private IRepository<User> users;
        private IRepository<Session> sessions;
        private IRepository<Game> games;

        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }
        public IRepository<User> Users => 
            this.users ?? (this.users = 
                new Repository<User>(this.context.Set<User>()));

        public IRepository<Session> Sessions =>
            this.sessions ?? (this.sessions = 
                new Repository<Session>(this.context.Set<Session>()));
        public IRepository<Game> Games =>
            this.games ?? (this.games =
                new Repository<Game>(this.context.Set<Game>()));


        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}