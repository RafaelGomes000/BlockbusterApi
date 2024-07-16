using AutoMapper;
using BlockbusterApi.Data;
using BlockbusterApi.Data.Dtos;
using BlockbusterApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlockbusterApi.Controllers
{
    [ApiController]
    [Route("Controller")]
    public class MovieController : ControllerBase
    {
        BlockbusterContext _context;
        IMapper _mapper;

        public MovieController(IMapper mapper, BlockbusterContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("CreateMovie")]
        [ProducesResponseType(typeof(IEnumerable<Movie>), 200)]
        public IActionResult CreateMovie(CreateMovieDto movieDto)
        {
            var movie = _mapper.Map<Movie>(movieDto);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _context.Add(movie);
            _context.SaveChanges();
            return Ok(movie);
        }

        [HttpGet("GetAllMovies")]
        [ProducesResponseType(typeof(IEnumerable<Movie>), 200)]
        public IEnumerable<Movie> GetAllMovies()
        {
            if (_context.Movies == null) return (IEnumerable<Movie>)NotFound();
            if (!ModelState.IsValid) return (IEnumerable<Movie>)BadRequest(ModelState);
            return _context.Movies;
        }

        [HttpGet("GetMovieById {id}")]
        [ProducesResponseType(typeof(IEnumerable<Movie>), 200)]
        [ProducesResponseType(400)]
        public IActionResult GetMovieById(int id)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == id);
            if (movie == null) return NotFound();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(movie);
        }

        [HttpPut("UpdateMovie")]
        [ProducesResponseType(typeof(IEnumerable<Movie>), 200)]
        [ProducesResponseType(400)]
        public IActionResult UpdateMovie(int id, CreateMovieDto movieDto)
        {
            var oldMovie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
            if (oldMovie == null) return NotFound();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _mapper.Map(movieDto, oldMovie);
            _context.SaveChanges();
            return Ok(movieDto);
        }
    }
}
