using CourseLibrary.API.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibrary.API.Queries
{
    public class GetAllArtistQuery:IRequest<List<ArtistDto>> // To Return List Of Artists
    {

    }

    public class GetAllArtistByIdQuery : IRequest<ArtistDto> // To Return Artist
    {
        public double Id { get; set; }

        public GetAllArtistByIdQuery(double id)
        {
            Id = id;
        }
    }
}
