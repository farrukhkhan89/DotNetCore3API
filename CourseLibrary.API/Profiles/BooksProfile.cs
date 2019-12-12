using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace CourseLibrary.API.Profiles
{
    public class BooksProfile : Profile
    {
        public BooksProfile()
        {
            CreateMap<Entities.Book, Models.BookDto>()
                .ForMember(
                    dest => dest.BookId,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(
                    dest => dest.NameOfBook,
                    opt => opt.MapFrom(src => src.BookName))
                 .ForMember(
                    dest => dest.Category,
                    opt => opt.MapFrom(src => src.Category))
                  .ForMember(
                    dest => dest.Price,
                    opt => opt.MapFrom(src => src.Price))
                  .ForMember(
                    dest => dest.AuthorName,
                    opt => opt.MapFrom(src => src.Author));

        }

        public class NullStringConverter 
        {
            public static string Convert(string source)
            {
                return source ?? string.Empty;
            }
        }


    }
}
