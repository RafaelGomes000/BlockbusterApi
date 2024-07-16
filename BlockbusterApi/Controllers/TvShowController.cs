using AutoMapper;
using BlockbusterApi.Data;
using BlockbusterApi.Data.Dtos;
using BlockbusterApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlockbusterApi.Controllers
{
    [ApiController]
    [Route("Controller")]
    public class TvShowController : ControllerBase
    {
        BlockbusterContext _context;
        IMapper _mapper;

        public TvShowController(IMapper mapper, BlockbusterContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("CreateTvShow")]
        [ProducesResponseType(typeof(IEnumerable<TvShow>), 200)]
        public IActionResult CreateTvShow(CreateTvShowDto tvShowDto)
        {
            var tvShow = _mapper.Map<TvShow>(tvShowDto);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _context.Add(tvShow);
            _context.SaveChanges();
            return Ok(tvShow);
        }

        [HttpGet("GetAllTvShows")]
        [ProducesResponseType(typeof(IEnumerable<TvShow>), 200)]
        public IEnumerable<TvShow> GetAllTvShows()
        {
            if (!ModelState.IsValid) return (IEnumerable<TvShow>)BadRequest(ModelState);
            return _context.TvShows;
        }

        [HttpGet("GetTvShowById {id}")]
        [ProducesResponseType(typeof(IEnumerable<TvShow>), 200)]
        [ProducesResponseType(400)]
        public IActionResult GetTvShowById(int id)
        {
            var tvShow = _context.TvShows.FirstOrDefault(x => x.Id == id);
            if (tvShow == null) return NotFound();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(tvShow);
        }

        [HttpPut("UpdateTvShow")]
        [ProducesResponseType(typeof(IEnumerable<TvShow>), 200)]
        [ProducesResponseType(400)]
        public IActionResult UpdateTvShow(int id, CreateTvShowDto tvShowDto)
        {
            var oldTvShow = _context.TvShows.FirstOrDefault(tvShow => tvShow.Id == id);
            if (oldTvShow == null) return NotFound();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _mapper.Map(tvShowDto, oldTvShow);
            _context.SaveChanges();
            return Ok(tvShowDto);
        }
    }
}
