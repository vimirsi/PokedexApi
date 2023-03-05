using PokedexApi.Domain.Interfaces;

namespace PokedexApi.Infra.Implements
{
    public class StatsRepository : IStatsRepository
    {
        private readonly DataContext _context;

        public StatsRepository(DataContext context)
        {
            _context = context;
        }
    }
}