using BookShelf.API.Data;
using BookShelf.API.Entities;
using BookShelf.API.Repository.Common;
using BookShelf.API.Repository.Interfaces;

namespace BookShelf.API.Repository
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public AuthorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Author> GetAuthorByBookTitle(string bookTitle)
        {
            throw new NotImplementedException();
        }
    }
}
