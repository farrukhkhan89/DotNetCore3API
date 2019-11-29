using AutoMapper;
using CourseLibrary.API.Helpers;
using CourseLibrary.API.Models;
using CourseLibrary.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibrary.API.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorsController : ControllerBase
    {
        private readonly ICourseLibraryRepository _courseLibraryRepository;
        private readonly IMapper _mapper;

        public AuthorsController(ICourseLibraryRepository courseLibraryRepository,
            IMapper mapper)
        {

            _courseLibraryRepository = courseLibraryRepository ?? throw new ArgumentNullException(nameof(courseLibraryRepository));
            _mapper = mapper ?? throw new ArgumentOutOfRangeException(nameof(mapper));
        }

        [HttpGet()]
        public IActionResult GetAuthors()
        {
            var authorList = _courseLibraryRepository.GetAuthors();
            return Ok(_mapper.Map<IEnumerable<AuthorDto>>(authorList));

        }

        [HttpGet("{authorId}")]
        public IActionResult GetAuthor(Guid authorId)
        {
            var author = _courseLibraryRepository.GetAuthor(authorId);
            if (author != null)
                return Ok(_mapper.Map<AuthorDto>(author));

            return NotFound();

        }
    }
}
