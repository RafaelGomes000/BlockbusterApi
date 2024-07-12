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
        public IActionResult CreateMovie(CreateMovieDto movieDto)
        {
            var movie = _mapper.Map<Movie>(movieDto);
            _context.Add(movie);
            _context.SaveChanges();
            return Ok(movie);
        }

        [HttpGet("GetAllMovies")]
        public IEnumerable<Movie> GetAllMovies()
        {
            return _context.Movies;
        }

        [HttpGet("GetMovieById {id}")]
        public IActionResult GetMovieById(int id)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == id);
            if (movie == null) return NotFound();
            return Ok(movie);
        }

        [HttpPut("UpdateMovie")]
        public IActionResult UpdateMovie(int id, CreateMovieDto movieDto)
        {
            var oldMovie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
            if (oldMovie == null) return NotFound();
            _mapper.Map(movieDto, oldMovie);
            _context.SaveChanges();
            return Ok(movieDto);
        }
    }
}
