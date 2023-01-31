using PokedexApi.Core.Enums;
using PokedexApi.Domain.Dtos;
using PokedexApi.Domain.Entities;
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

        public async Task<Weakness> AddAsync(WeaknessAddDTO dto)
        {
            var id = Guid.NewGuid();

            var weakness = new Weakness()
            {
                Id = id,
                PokemonId = dto.PokemonId,
                SpecialStageId = dto.SpecialStageId,
                TypeName = ((int)dto.TypeName)
            };

            _context.Weakness.Add(weakness);
            _context.SaveChanges();

            return await Task.FromResult(weakness);
        }
    }
}