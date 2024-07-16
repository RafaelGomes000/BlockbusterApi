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
        public IEnumerable<TvShow> GetAllTvShows()
        {
            return _context.TvShows;
        }

        [HttpGet("GameCatalogue")]
        public IEnumerable<Game> GetAllGames()
        {
            return _context.Games;
        }

        [HttpGet("MovieCatalogue")]
        public IEnumerable<Movie> GetAllMovies()
        {
            return _context.Movies;
        }
    }
}
