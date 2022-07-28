using Api.Context;
using Api.Repositories.Contracts;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext RepositoryContext { get; set; }
        public RepositoryBase(RepositoryContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public IQueryable<T> FindAll() => RepositoryContext.Set<T>();

        public T FindById(long id) => RepositoryContext.Set<T>().Find(id);

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            RepositoryContext.Set<T>().Where(expression);

        public T Create(T entity)
        {
            RepositoryContext.Set<T>().Add(entity);
            RepositoryContext.SaveChanges();
            return entity;
        }

        public T Update(T entity) 
        {
            RepositoryContext.Set<T>().Update(entity);
            RepositoryContext.SaveChanges();
            return entity;
        }

        public bool Delete(T entity)
        {
            bool deleted = RepositoryContext.Set<T>().Remove(entity).State == EntityState.Deleted;
            RepositoryContext.SaveChanges();
            return deleted;
        }

        public bool Exists(Expression<Func<T, bool>> expression)
        {
            var result = RepositoryContext.Set<T>().Where(expression).FirstOrDefault();
            return result == null ? false : true;
        }
    }
}
