namespace SoftUniStore.Data
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using Contracts;

    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbSet<T> Set;

        public Repository(DbSet<T> context)
        {
            this.Set = context;
        }

        public void Add(T entity)
        {
            this.Set.Add(entity);
        }

        public T Remove(object id)
        {
            var entity = this.Find(id);
            this.Remove(entity);
            return entity;
        }

        public void Remove(T entity)
        {
            this.Set.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entitites)
        {
            this.Set.RemoveRange(entitites);
        }

        public IQueryable<T> All()
        {
            return this.Set;
        }
        
        public T Find(object id)
        {
            return this.Set.Find(id);
        }
    }
}