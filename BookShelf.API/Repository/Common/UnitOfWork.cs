using BookShelf.API.Data;
using BookShelf.API.Repository.Common.IRepository;

namespace BookShelf.API.Repository.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        void IUnitOfWork.Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}
