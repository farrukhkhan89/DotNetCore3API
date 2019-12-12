using CourseLibrary.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibrary.API.Services
{
    public class ArtistsRepository: IArtistsRepository
    {
        private readonly IMongoCollection<Artist> _artist;

        public ArtistsRepository(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("BookStoreDb"));
            var database = client.GetDatabase("BookStoreDb");

            _artist = database.GetCollection<Artist>("artists");
        }
        public async Task<List<Artist>> GetArtistsAsync()
        {
            var artists = await _artist.FindAsync(x => true);
            return await artists.ToListAsync();

            //var users = await _users.FindAsync(user => true);
            //return await users.ToListAsync();

        }

        public async Task<Artist> GetArtistByIdAsync(double id)
        {
            var artists = await _artist.FindAsync(x => x.Id==id);
            return await artists.FirstOrDefaultAsync();
        }
    }
}





