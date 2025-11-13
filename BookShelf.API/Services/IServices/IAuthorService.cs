using BookShelf.API.DTO;
using BookShelf.API.Entities;

namespace BookShelf.API.Services.IServices
{
    public interface IAuthorService
    {
        IEnumerable<AuthorViewDto> GetAllAuthors();
        Author GetAuthorById(int id);
        void AddAuthor(AuthorCreate authorCreate);
        void UpdateAuthor(Author author);
        void DeleteAuthor(Author author);
    }
}
