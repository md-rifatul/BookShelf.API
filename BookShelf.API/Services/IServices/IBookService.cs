using BookShelf.API.Entities;

namespace BookShelf.API.Services.IServices
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int id);
        void DeleteBook(Book book);
        void AddBook(Book book);
        void UpdateBook(Book book);
    }
}
