using AutoMapper;
using CourseLibrary.API.Commands;
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


        public class CreateArtistCommandHandler : IRequestHandler<CreateArtistCommand, double>
        {
            private readonly IMapper _mapper;
            private readonly IArtistsRepository _artistRepository;

            public CreateArtistCommandHandler(IArtistsRepository artistRepository, IMapper mapper)
            {
                _artistRepository = artistRepository;
                _mapper = mapper;
            }

            public async Task<double> Handle(CreateArtistCommand request, CancellationToken cancellationToken)
            {
                var existingRepo = await _artistRepository.GetArtistByIdAsync(request.Artist._Id);
                if (existingRepo != null)
                    throw new Exception("Repository alreay exists. Creation failed.");

                //request.Repository.LastUpdated = DateTime.Now;
                await _artistRepository.Create(request.Artist);
                return request.Artist._Id;
            }
        }

        public class UpdateArtistCommandHandler : IRequestHandler<UpdateArtistCommand>
        {
            //private readonly IMapper _mapper;
            private readonly IArtistsRepository _artistRepository;

            public UpdateArtistCommandHandler(IArtistsRepository artistRepository)
            {
                _artistRepository = artistRepository;
            }

            public async Task<Unit> Handle(UpdateArtistCommand request, CancellationToken cancellationToken)
            {
                await _artistRepository.Update(request.Id,request.Artist);
                return Unit.Value;
            }

           
        }

    }
}
