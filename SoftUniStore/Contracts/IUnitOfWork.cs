namespace SoftUniStore.Contracts
{
    using Models;
    using Security;

    public interface IUnitOfWork
    {
        IRepository<User> Users { get; }
        IRepository<Session> Sessions { get; }
        IRepository<Game> Games { get; }
        void SaveChanges();
    }
}