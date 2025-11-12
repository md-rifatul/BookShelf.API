using BookShelf.API.Entities;
using BookShelf.API.Repository.Common.IRepository;
using BookShelf.API.Repository.Interfaces;
using BookShelf.API.Services.IServices;

namespace BookShelf.API.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUnitOfWork _db;
        public BookService(IBookRepository bookRepository, IUnitOfWork commit)
        {
            _bookRepository = bookRepository;
            _db = commit;
        }
        public void AddBook(Book book)
        {
            _bookRepository.Add(book);
            _db.Commit();
        }

        public void DeleteBook(Book book)
        {
            _bookRepository?.Delete(book);
            _db.Commit();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _bookRepository.GetAll();
        }

        public Book GetBookById(int id)
        {
            return _bookRepository.GetById(id);
        }

        public void UpdateBook(Book book)
        {
            _bookRepository.Update(book);
            _db.Commit();
        }
    }
}
