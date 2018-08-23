namespace SoftUniStore.Contracts
{
    using System.Collections.Generic;
    using System.Linq;

    public interface IRepository<T> where T : class
    {
        void Add(T entity);

        T Remove(object id);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entitites);

        T Find(object id);

        IQueryable<T> All();
    }
}