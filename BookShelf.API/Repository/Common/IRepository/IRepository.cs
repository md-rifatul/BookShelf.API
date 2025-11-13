using System.Linq.Expressions;

namespace BookShelf.API.Repository.Common.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T,bool>>? filter = null, string? includeProp = null);
        T? GetById(Expression<Func<T,bool>> filter, string? includeProp = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
