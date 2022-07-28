using System.Linq.Expressions;

namespace Api.Repositories.Contracts
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        T FindById(long id);
        T Create(T entity);
        T Update(T entity);
        bool Delete(T entity);
        bool Exists(Expression<Func<T, bool>> expression);
    }
}
