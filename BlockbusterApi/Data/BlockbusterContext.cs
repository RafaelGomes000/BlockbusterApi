using BlockbusterApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BlockbusterApi.Data
{
    public class BlockbusterContext : DbContext
    {
        public BlockbusterContext(DbContextOptions<BlockbusterContext> opts) : base(opts) { }

        public DbSet<Game> Games { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<TvShow> TvShows { get; set; }
    }
}
