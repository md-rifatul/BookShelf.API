using BookShelf.API.Entities;
using BookShelf.API.Repository.Common.IRepository;

namespace BookShelf.API.Repository.Interfaces
{
    public interface IAuthorRepository : IRepository<Author>
    {
        IEnumerable<Author> GetAuthorByBookTitle(string bookTitle);
    }
}
