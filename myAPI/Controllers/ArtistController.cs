using Microsoft.AspNetCore.Mvc;
using System;

namespace myAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArtistController : ControllerBase
    {
        private static readonly string[] Genres = new[]
        {
        "Rock", "Jazz", "Pop", "Hipop", "R&B", "Techno", "Coutnry"};

        private static readonly string[] ArtistNames = new[]
        {
        "Rose", "Shift", "Jamie Law", "Charlie Caine", "Lee Winter", "Quiver", "Clyde East"};

        private readonly ILogger<ArtistController> _logger;

        public ArtistController(ILogger<ArtistController> logger)
        {
            _logger = logger;
        }
        IEnumerable<Artist> artists = Enumerable.Range(1, 5).Select(index => new Artist
        {
            Name = ArtistNames[Random.Shared.Next(ArtistNames.Length)],
            Ranking = Random.Shared.Next(1, 100),
            Genre = Genres[Random.Shared.Next(Genres.Length)]
        });

        /// <summary>
        /// Returns different artists
        /// </summary>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IEnumerable<Artist> Get()
        {
            return artists.ToArray();
        }

        /// <summary>
        /// Demonstrates posting action
        /// </summary>
        /// <returns>A 201 Created response</returns>
        [HttpPost]
        [ProducesResponseType(201)]
        public Artist Post(String artistName, int rank, String Genre)
        {
            Artist newArtist = new Artist
            {
                Name = artistName,
                Ranking = rank,
                Genre = Genre
            };
            artists.Append(newArtist);
            return newArtist;
        }

        /// <summary>
        /// Demonstrates put action
        /// </summary>
        /// <returns>A 201 Created Response></returns>
        [HttpPut]
        [ProducesResponseType(201)]
        public Artist Put(String oldArtistName, String newArtistName, int newRank, String newGenre)
        {
            for (int i = 0; i < artists.Count(); i++)
            {
                if (artists.ElementAt(i).Name == oldArtistName)
                {
                    Artist newArtist = new Artist
                    {
                        Name = newArtistName,
                        Ranking = newRank,
                        Genre = newGenre
                    };
                    artists = artists.Where(u => u.Name != oldArtistName);
                    artists.Append(newArtist);
                    return newArtist;
                }
            }
            return null;
        }


        /// <summary>
        /// Demonstrates a delete action
        /// </summary>
        /// <returns>A 204 No Content Response</returns>
        [HttpDelete]
        [ProducesResponseType(204)]
        public IActionResult DemonstrateDelete(String artistRemove)
        {
            for (int i = 0; i < artists.Count(); i++)
            {
                if (artists.ElementAt(i).Name == artistRemove)
                {
                    artists = artists.Where(u => u.Name != artistRemove);
                }
                return Ok(204);
            }

            return BadRequest("No such artist");
        }

    }
}