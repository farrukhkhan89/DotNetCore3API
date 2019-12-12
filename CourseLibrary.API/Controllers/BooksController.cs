using AutoMapper;
using CourseLibrary.API.Entities;
using CourseLibrary.API.Queries;
using CourseLibrary.API.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibrary.API.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksRepository _booksRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public BooksController(IBooksRepository booksRepository, IMapper mapper,IMediator mediator
           )
        {
            _booksRepository = booksRepository ?? throw new ArgumentNullException(nameof(booksRepository));
             _mapper = mapper ?? throw new ArgumentOutOfRangeException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentOutOfRangeException(nameof(mediator)); 
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GeAlltBooksQuery();
            var result = await _mediator.Send(query);

            return Ok(result);

        }

        [HttpGet("{id}", Name = "GetUser")]
        public async Task<IActionResult> GetBookById(string id)
        {
            var query = new GetBookByIdQuery(id);
            var result = await _mediator.Send(query);

            return Ok(result);

        }

        [HttpPost("PostBook")]
        public ActionResult<Book> PostBook([FromBody] Book body)
        {    
            var books = _booksRepository.CreateBook(body);
            //return CreatedAtAction("PostBook", new { orderId = result.Id }, result);
            return Ok(_mapper.Map<IEnumerable<Models.BookDto>>(books));

        }
    }
}
