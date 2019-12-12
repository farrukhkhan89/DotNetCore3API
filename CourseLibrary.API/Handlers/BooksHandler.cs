using AutoMapper;
using CourseLibrary.API.Entities;
using CourseLibrary.API.Models;
using CourseLibrary.API.Queries;
using CourseLibrary.API.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CourseLibrary.API.Handlers
{

    public class GetAllBooksQueryHandler : IRequestHandler<GeAlltBooksQuery, List<BookDto>>
    {
        private readonly IMapper _mapper;
        private readonly IBooksRepository _bookRepository;

        public GetAllBooksQueryHandler(IBooksRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<List<BookDto>> Handle(GeAlltBooksQuery request, CancellationToken cancellationToken)
        {
            var booksList = await _bookRepository.GetBooksAsync();
            if (booksList == null)
                throw new Exception("No user found. Failed to get list.");

            var bookDTOList = _mapper.Map<List<Book>, List<BookDto>>(booksList);
            return bookDTOList;
        }
    }



    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookDto>
    {
        private readonly IMapper _mapper;
        private readonly IBooksRepository _bookRepository;

        public GetBookByIdQueryHandler(IBooksRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BookDto> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetById(request.Id);
            if (book == null)
                throw new Exception("Not Found Any.");

            var bookDto = _mapper.Map<Models.BookDto>(book);

            return bookDto;

        }


    }



}
