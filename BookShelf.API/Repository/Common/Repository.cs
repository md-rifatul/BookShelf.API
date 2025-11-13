using BookShelf.API.Data;
using BookShelf.API.Repository.Common.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookShelf.API.Repository.Common
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        private readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }

        public void Add(T entity) => _dbSet.Add(entity);
        public void Update(T entity) => _dbSet.Update(entity);
        public void Delete(T entity) => _dbSet.Remove(entity);

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProp = null)
        {
            IQueryable<T> query = _dbSet;
            if(filter != null)
            {
                query = query.Where(filter);
            }

            if(!string.IsNullOrWhiteSpace(includeProp))
            {
                foreach(var incProp in includeProp.Split(',',StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(incProp.Trim());
                }
            }
            return query.ToList();
        }

        public T? GetById(Expression<Func<T, bool>> filter, string? includeProp = null)
        {
            IQueryable<T> query = _dbSet;

            if(!string.IsNullOrEmpty(includeProp))
            {
                foreach (var incProp in includeProp.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(incProp.Trim());
                }
            }
            return query.FirstOrDefault(filter);
        }
    }
}
