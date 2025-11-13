using BookShelf.API.DTO;
using BookShelf.API.Entities;

namespace BookShelf.API.Services.IServices
{
    public interface IBookService
    {
        IEnumerable<BookDto> GetAllBooks();
        BookDto GetBookById(int id);
        void DeleteBook(BookDto bookDto);
        void AddBook(BookCreateDto bookCreateDto);
        void UpdateBook(BookDto bookDto);
    }
}
