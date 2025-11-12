using BookShelf.API.Entities;
using BookShelf.API.Repository.Common.IRepository;

namespace BookShelf.API.Repository.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        IEnumerable<Book> GetBooksByAuthor(string author);
    }
}
