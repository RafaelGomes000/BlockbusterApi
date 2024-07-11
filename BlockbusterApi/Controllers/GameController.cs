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
    }
}
