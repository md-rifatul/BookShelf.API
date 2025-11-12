using BookShelf.API.Data;
using BookShelf.API.Repository.Common.IRepository;

namespace BookShelf.API.Repository.Common
{
    public class Commit : ICommit
    {
        private readonly ApplicationDbContext _dbContext;

        public Commit(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        void ICommit.Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}
