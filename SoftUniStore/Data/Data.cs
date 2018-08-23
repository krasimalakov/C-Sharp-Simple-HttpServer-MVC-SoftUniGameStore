namespace SoftUniStore.Data
{
    using Contracts;

    public class Data
    {
        private static IUnitOfWork unitOfWork;

        public static IUnitOfWork UnitOfWork =>
            unitOfWork ?? (unitOfWork = new UnitOfWork(new SoftUniStoreContext()));
    }
}