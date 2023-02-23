using PokedexApi.Domain.Interfaces;

namespace PokedexApi.Infra.Implements
{
    public class WeaknessRepository : IWeaknessRepository
    {
        private readonly DataContext _context;

        public WeaknessRepository(DataContext context)
        {
            _context = context;
        }
    }
}