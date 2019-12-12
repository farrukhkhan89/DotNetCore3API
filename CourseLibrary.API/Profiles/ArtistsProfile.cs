using AutoMapper;
using CourseLibrary.API.Entities;
using CourseLibrary.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibrary.API.Profiles
{
    public class ArtistsProfile : Profile
    {
        public ArtistsProfile()
        {
            //CreateMap<Artist, ArtistDto>().ForMember(x => x.Albums, opt => opt.Ignore());
            CreateMap<Artist, ArtistDto>();

            //.ForMember(
            //  dest => dest.AddressObj,
            //  opt => opt.MapFrom(src => src.Address));



            CreateMap<Address, AddressDto>();
            //.ForMember(
            //  dest => dest.City,
            //  opt => opt.MapFrom(src => src.City));



            CreateMap<Entities.Album, Models.AlbumDto>()
               .ForMember(
                   dest => dest.AlbumName,
                   opt => opt.MapFrom(src => src.AlbumName))
               .ForMember(
                   dest => dest.Albumyear,
                   opt => opt.MapFrom(src => src.Albumyear))
                .ForMember(
                   dest => dest.Genre,
                   opt => opt.MapFrom(src => src.Genre));

      
             


            //CreateMap<User, UserDetailsDTO>().ForMember(x => x.Repositories, opt => opt.Ignore());

        }

    }
}
