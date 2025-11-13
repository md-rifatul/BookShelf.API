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
                .ForMember(x => x.AuthorName, opt => opt.MapFrom(src => src.Author!=null? src.Author.Name:null));

            CreateMap<BookDto, Book>()
                .ForMember(dest => dest.Author, opt => opt.Ignore());


            CreateMap<BookCreateDto, Book>();
            CreateMap<BookUpdateDto, Book>();
            CreateMap<AuthorCreate, Author>();
            CreateMap<Author, AuthorViewDto>();
        }
    }
}
