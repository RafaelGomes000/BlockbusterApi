using AutoMapper;
using BlockbusterApi.Data;
using BlockbusterApi.Data.Dtos;
using BlockbusterApi.Models;
using Microsoft.AspNetCore.Mvc;

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

        //create method to show all items in the DB
    }
}
