using System.Linq.Expressions;

namespace TestingWebApp.Repositories
{
    public interface IGenericRepository<T> where T :class
    {
        Task<T> GetById(int id);

        Task<IEnumerable<T>> GetAll();

        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);

        void Add(T entity);

        void Remove(T entity);
    }
}
