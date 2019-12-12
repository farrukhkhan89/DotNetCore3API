using CourseLibrary.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibrary.API.Services
{
    public interface IArtistsRepository
    {
        public Task<List<Artist>> GetArtistsAsync();
        public Task<Artist> GetArtistByIdAsync(double id);
    }
}
