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
        public IActionResult CreateGame(CreateGameDto gameDto)
        {
            var game = _mapper.Map<Game>(gameDto);
            _context.Add(game);
            _context.SaveChanges();
            return Ok(game);
        }

        [HttpGet("GetAllGames")]
        public IEnumerable<Game> GetAllGames()
        {
            return _context.Games;
        }

        [HttpGet("GetGameById {id}")]
        public IActionResult GetGameById(int id)
        {
            var game = _context.Games.FirstOrDefault(x => x.Id == id);
            if (game == null) return NotFound();
            return Ok(game);
        }

        [HttpPut("UpdateGame")]
        public IActionResult UpdateGame(int id, CreateGameDto gameDto)
        {
            var oldGame = _context.TvShows.FirstOrDefault(game => game.Id == id);
            if (oldGame == null) return NotFound();
            _mapper.Map(gameDto, oldGame);
            _context.SaveChanges();
            return Ok(gameDto);
        }
    }
}
