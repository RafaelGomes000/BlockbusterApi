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
    }
}
