using CourseLibrary.API.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibrary.API.Queries
{
    public class Artist2Query
    {
        public class GetAllArtist2Query : IRequest<List<Artist2Dto>> // To Return List Of Artists
        {

        }
    }
}
