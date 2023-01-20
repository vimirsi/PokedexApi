using pokedexapi.Data;
using PokedexApi.Entities;
using PokedexApi.Enums;
using PokedexApi.Repositories.Interfaces;

namespace PokedexApi.Repositories.Implements
{
    public class WeaknessRepository : IWeaknessRepository
    {
        private readonly DataContext _context;

        public WeaknessRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Weakness> Add(Guid? pokemonId, Guid? specialStageId, TypeEnum typeName)
        {
            var id = Guid.NewGuid();

            var weakness = new Weakness()
            {
                Id = id,
                PokemonId = pokemonId,
                SpecialStageId = specialStageId,
                TypeName = ((int)typeName)
            };

            _context.Weakness.Add(weakness);
            _context.SaveChanges();

            return await Task.FromResult(weakness);
        }
    }
}