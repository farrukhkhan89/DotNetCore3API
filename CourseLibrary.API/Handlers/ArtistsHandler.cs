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
    public class GetAllArtistQueryHandler: IRequestHandler<GetAllArtistQuery, List<ArtistDto>>
    {
        private readonly IMapper _mapper;
        private readonly IArtistsRepository _artistRepository;

        public GetAllArtistQueryHandler(IArtistsRepository artistRepository, IMapper mapper)
        {
            _artistRepository = artistRepository;
            _mapper = mapper;
        }

        public async Task<List<ArtistDto>> Handle(GetAllArtistQuery request, CancellationToken cancellationToken)
        {
            var artistList = await _artistRepository.GetArtistsAsync();
            if (artistList == null)
                throw new Exception("No Artist found. Failed to get list.");

            var artistDTOList = _mapper.Map<List<Artist>, List<ArtistDto>>(artistList);
            return artistDTOList;
        }

        public class GetAllArtistByIdQueryHandler : IRequestHandler<GetAllArtistByIdQuery, ArtistDto>
        {
            private readonly IMapper _mapper;
            private readonly IArtistsRepository _artistRepository;

            public GetAllArtistByIdQueryHandler(IArtistsRepository artistRepository, IMapper mapper)
            {
                _artistRepository = artistRepository;
                _mapper = mapper;
            }

            public async Task<ArtistDto> Handle(GetAllArtistByIdQuery request, CancellationToken cancellationToken)
            {
                var artistList = await _artistRepository.GetArtistByIdAsync(request.Id);
                if (artistList == null)
                    throw new Exception("No Artist found. Failed to get list.");

                var artistDTOList = _mapper.Map<Artist, ArtistDto>(artistList);
                return artistDTOList;
            }
        }
    }
}
