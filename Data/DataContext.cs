using Microsoft.EntityFrameworkCore;
using PokedexApi.Entities;

namespace pokedexapi.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Evolution> Evolution { get; set; }

        public DbSet<Pokemon> Pokemon { get; set; }

        public DbSet<SpecialStage> SpecialStage { get; set; }

        public DbSet<Stats> Stats { get; set; }
    }
}
