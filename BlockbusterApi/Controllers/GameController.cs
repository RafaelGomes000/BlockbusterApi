using AutoMapper;
using BlockbusterApi.Data;
using BlockbusterApi.Data.Dtos;
using BlockbusterApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlockbusterApi.Controllers
{
    [ApiController]
    [Route("Controller")]
    public class GameController : ControllerBase
    {
        BlockbusterContext _context;
        IMapper _mapper;

        public GameController(IMapper mapper, BlockbusterContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("CreateGame")]
        [ProducesResponseType(typeof(IEnumerable<Game>), 200)]
        public IActionResult CreateGame(CreateGameDto gameDto)
        {
            var game = _mapper.Map<Game>(gameDto);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _context.Add(game);
            _context.SaveChanges();
            return Ok(game);
        }

        [HttpGet("GetAllGames")]
        [ProducesResponseType(typeof(IEnumerable<Game>), 200)]
        public IEnumerable<Game> GetAllGames()
        {
            if (_context.Games == null) return (IEnumerable<Game>)NotFound();
            if (!ModelState.IsValid) return (IEnumerable<Game>)BadRequest(ModelState);
            return _context.Games;
        }

        [HttpGet("GetGameById {id}")]
        [ProducesResponseType(typeof(IEnumerable<Game>), 200)]
        [ProducesResponseType(400)]
        public IActionResult GetGameById(int id)
        {
            var game = _context.Games.FirstOrDefault(x => x.Id == id);
            if (game == null) return NotFound();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(game);
        }

        [HttpPut("UpdateGame")]
        [ProducesResponseType(typeof(IEnumerable<Game>), 200)]
        [ProducesResponseType(400)]
        public IActionResult UpdateGame(int id, CreateGameDto gameDto)
        {
            var oldGame = _context.TvShows.FirstOrDefault(game => game.Id == id);
            if (oldGame == null) return NotFound();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _mapper.Map(gameDto, oldGame);
            _context.SaveChanges();
            return Ok(gameDto);
        }
    }
}
