namespace SoftUniStore.Services
{
    using Contracts;
    using Data;

    public abstract class Service
    {
        protected IUnitOfWork Context { get; }

        protected Service()
        {
            this.Context = Data.UnitOfWork;
        }
		
		protected Service(IUnitOfWork context)
        {
            this.Context = context;
        }
    }
}