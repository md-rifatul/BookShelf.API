using AutoMapper;
using BookShelf.API.Data;
using BookShelf.API.DTO;
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
        private readonly IMapper _mapper;
        public AuthorService(IAuthorRepository authorRepository, IUnitOfWork db, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _db = db;
            _mapper = mapper;
        }
        public void AddAuthor(AuthorCreate authorCreate)
        {
            var author = _mapper.Map<Author>(authorCreate);
            _authorRepository.Add(author);
            _db.Commit();
        }

        public void DeleteAuthor(Author author)
        {
            _authorRepository.Delete(author);
            _db.Commit();
        }
        public IEnumerable<AuthorViewDto> GetAllAuthors()
        {
            var authors = _authorRepository.GetAll();
            return _mapper.Map<IEnumerable<AuthorViewDto>>(authors);
        }

        public Author GetAuthorById(int id)
        {
            return _authorRepository.GetById(x => x.Id == id);
        }

        public void UpdateAuthor(Author author)
        {
            _authorRepository.Update(author);
            _db.Commit();
        }
    }
}
