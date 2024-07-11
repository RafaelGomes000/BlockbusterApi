using AutoMapper;
using BlockbusterApi.Data.Dtos;
using BlockbusterApi.Models;

namespace BlockbusterApi.Profiles
{
    public class BlockbusterProfile : Profile
    {
        public BlockbusterProfile()
        {
            CreateMap<CreateGameDto, Game>();
            CreateMap<CreateMovieDto, Movie>();
            CreateMap<CreateTvShowDto, TvShow>();
        }
    }
}
