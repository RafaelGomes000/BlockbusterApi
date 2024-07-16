using AutoMapper;
using BlockbusterApi.Data;
using BlockbusterApi.Data.Dtos;
using BlockbusterApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace BlockbusterApi.Controllers
{
    [ApiController]
    [Route ("Controller")]
    public class BlockbusterController : ControllerBase
    {
        BlockbusterContext _context;
        IMapper _mapper;

        public BlockbusterController(IMapper mapper, BlockbusterContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("TvShowCatalogue")]
        [ProducesResponseType(typeof(IEnumerable<TvShow>), 200)]
        public IEnumerable<TvShow> GetAllTvShows()
        {
            if (!ModelState.IsValid) return (IEnumerable<TvShow>)BadRequest(ModelState);
            return _context.TvShows;
        }

        [HttpGet("GameCatalogue")]
        [ProducesResponseType(typeof(IEnumerable<Game>), 200)]
        public IEnumerable<Game> GetAllGames()
        {
            if (!ModelState.IsValid) return (IEnumerable<Game>)BadRequest(ModelState);
            return _context.Games;
        }

        [HttpGet("MovieCatalogue")]
        [ProducesResponseType(typeof(IEnumerable<Movie>), 200)]
        public IEnumerable<Movie> GetAllMovies()
        {
            if (!ModelState.IsValid) return (IEnumerable<Movie>)BadRequest(ModelState);
            return _context.Movies;
        }
    }
}
