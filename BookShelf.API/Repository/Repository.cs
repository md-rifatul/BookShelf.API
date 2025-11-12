using BookShelf.API.Data;
using BookShelf.API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BookShelf.API.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbcontext;
        private readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbcontext = dbContext;
            _dbSet = _dbcontext.Set<T>();
        }

        public IEnumerable<T> GetAll() => _dbSet.ToList();
        public T? GetById(int id) => _dbSet.Find(id);
        public void Add(T entity) => _dbSet.Add(entity);
        public void Update(T entity) => _dbSet.Update(entity);
        public void Delete(T entity) => _dbSet.Remove(entity);
        public void Save() => _dbcontext.SaveChanges();
    }
}
