using AutoMapper;
using BookShelf.API.DTO;
using BookShelf.API.Entities;

namespace BookShelf.API.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDto>()
                .ForMember(x => x.AuthorName, opt => opt.MapFrom(src => src.Author.Name));

            CreateMap<BookCreateDto, Book>();
            CreateMap<BookUpdateDto, Book>();
        }
    }
}
