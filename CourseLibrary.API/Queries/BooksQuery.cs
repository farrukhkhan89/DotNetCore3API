using CourseLibrary.API.Entities;
using CourseLibrary.API.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibrary.API.Queries
{
    public class GeAlltBooksQuery: IRequest<List<BookDto>>    
    {
    }

    public class GetBookByIdQuery : IRequest<BookDto>
    {
        public string Id { get; set; }

        public GetBookByIdQuery(string id)
        {
            Id = id;
        }
    }


}
