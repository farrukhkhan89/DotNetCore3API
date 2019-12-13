using CourseLibrary.API.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibrary.API.Commands
{
    public class ArtistCommands
    {
    }

    public class CreateArtistCommand : IRequest<double>
    {
        public Artist Artist { get; set; }
    }

    public class UpdateArtistCommand : IRequest
    {
        public double Id { get; set; }
        public Artist Artist { get; set; }
    }
}
