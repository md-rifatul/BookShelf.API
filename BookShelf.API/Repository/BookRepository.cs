using BookShelf.API.Data;
using BookShelf.API.Entities;
using BookShelf.API.Repository.Common;
using BookShelf.API.Repository.Interfaces;

namespace BookShelf.API.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public BookRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Book> GetBooksByAuthor(string author)
        {
            throw new NotImplementedException();
        }
    }
}
