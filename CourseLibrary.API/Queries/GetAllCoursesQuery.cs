using CourseLibrary.API.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibrary.API.Queries
{
    public class GetAllCoursesQuery:IRequest<List<Course>>
    {
    }
}
