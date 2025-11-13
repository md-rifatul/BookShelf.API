using AutoMapper;
using BookShelf.API.DTO;
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
        private readonly IMapper _mapper;
        public BookService(IBookRepository bookRepository, IUnitOfWork commit, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _db = commit;
            _mapper = mapper;
        }
        public void AddBook(BookCreateDto bookCreateDto)
        {
            if (bookCreateDto == null)
            {
                throw new Exception("Book data is required");
            }
            var book = _mapper.Map<Book>(bookCreateDto);
            _bookRepository.Add(book);
            _db.Commit();
        }

        public void DeleteBook(BookDto bookDto)
        {
            var existingBook = _bookRepository.GetById(x=>x.Id==bookDto.Id);
            _bookRepository?.Delete(existingBook);
            _db.Commit();
        }

        public IEnumerable<BookDto> GetAllBooks()
        {
            var books = _bookRepository.GetAll(includeProp:"Author");
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        public BookDto GetBookById(int id)
        {
            var book = _bookRepository.GetById(x=>x.Id==id,"Author");
            return _mapper.Map<BookDto>(book);
        }

        public void UpdateBook(BookDto bookDto)
        {
            var existingBook = _bookRepository.GetById(x => x.Id == bookDto.Id);
            existingBook.Title = bookDto.Title;
            existingBook.Year = bookDto.Year;
            existingBook.AuthorId = bookDto.AuthorId;
           var book = _mapper.Map<Book>(existingBook);
            _bookRepository.Update(book);
            _db.Commit();
        }
    }
}
