using BookShelf.API.Entities;
using BookShelf.API.Repository.Common.IRepository;
using BookShelf.API.Repository.Interfaces;
using BookShelf.API.Services.IServices;

namespace BookShelf.API.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICommit _commit;
        public BookService(IBookRepository bookRepository, ICommit commit)
        {
            _bookRepository = bookRepository;
            _commit = commit;
        }
        public void AddBook(Book book)
        {
            throw new NotImplementedException();
        }

        public void DeleteBook(Book book)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            throw new NotImplementedException();
        }

        public Book GetBookById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateBook(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
