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
        public IActionResult CreateTvShow(CreateTvShowDto tvShowDto)
        {
            var tvShow = _mapper.Map<TvShow>(tvShowDto);
            _context.Add(tvShow);
            _context.SaveChanges();
            return Ok(tvShow);
        }
    }
}
