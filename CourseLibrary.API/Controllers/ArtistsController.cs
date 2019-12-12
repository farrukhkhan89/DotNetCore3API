﻿using AutoMapper;
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
    [Route("api/artists")]
    public class ArtistsController : ControllerBase
    {
        private readonly IArtistsRepository _artistsRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ArtistsController(IArtistsRepository artistsRepository, IMapper mapper, IMediator mediator
          )
        {
            _artistsRepository = artistsRepository ?? throw new ArgumentNullException(nameof(artistsRepository));
            _mapper = mapper ?? throw new ArgumentOutOfRangeException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentOutOfRangeException(nameof(mediator));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllArtistQuery();
            var result = await _mediator.Send(query);

            return Ok(result);

        }

        [HttpGet("{id}", Name = "GetArtistById")]
        public async Task<IActionResult> Get(double id)
        {
            var query = new GetAllArtistByIdQuery(id);
            var result = await _mediator.Send(query);

            return Ok(result);

        }
    }


}
