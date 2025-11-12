using BookShelf.API.Data;
using BookShelf.API.Entities;
using BookShelf.API.Repository.Common.IRepository;
using BookShelf.API.Repository.Interfaces;
using BookShelf.API.Services.IServices;

namespace BookShelf.API.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IUnitOfWork _db;
        public AuthorService(IAuthorRepository authorRepository, IUnitOfWork db)
        {
            _authorRepository = authorRepository;
            _db = db;
        }
        public void AddAuthor(Author author)
        {
            _authorRepository.Add(author);
            _db.Commit();
        }

        public void DeleteAuthor(Author author)
        {
            _authorRepository.Delete(author);
            _db.Commit();
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return _authorRepository.GetAll();
        }

        public Author GetAuthorById(int id)
        {
            return _authorRepository.GetById(id);
        }

        public void UpdateAuthor(Author author)
        {
            _authorRepository.Update(author);
            _db.Commit();
        }
    }
}
