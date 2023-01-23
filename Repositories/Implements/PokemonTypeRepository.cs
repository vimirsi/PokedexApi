using pokedexapi.Data;
using pokedexapi.Repositories.Interfaces;
using PokedexApi.Entities;
using PokedexApi.Enums;

namespace pokedexapi.Repositories.Implements
{
    public class PokemonTypeRepository : IPokemonTypeRepository
    {
        private readonly DataContext _context;

        public PokemonTypeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<PokemonType> Add(Guid? pokemonId, Guid? specialStageId, TypeEnum typeName)
        {
            var id = Guid.NewGuid();

            if(pokemonId != null && specialStageId != null)
            {
                throw new InvalidDataException("Mona, com todo o respeito... você é maluca?");
            }

            var pokemonType = new PokemonType()
            {
                Id = id,
                PokemonId = pokemonId,
                SpecialStageId = specialStageId,
                TypeName = ((int)typeName)
            };

            _context.PokemonType.Add(pokemonType);
            _context.SaveChanges();

            return await Task.FromResult(pokemonType);
        }

        public async Task<PokemonType> GetBy(Guid? pokemonId, Guid? specialStageId)
        {            
            if(pokemonId is null)
            {
                PokemonType pokemonType = _context.PokemonType.Where(x => x.SpecialStageId == specialStageId).FirstOrDefault();

                return await Task.FromResult(pokemonType);
            }
            else
            {
                PokemonType pokemonType = _context.PokemonType.Where(x => x.PokemonId == pokemonId).FirstOrDefault();

                return await Task.FromResult(pokemonType);
            }
        }

        public async Task<PokemonType> Update(Guid Id, TypeEnum typeName)
        {
            PokemonType pokemonType = await _context.PokemonType.FindAsync(Id);

            pokemonType.TypeName = ((int)typeName);

            _context.PokemonType.Update(pokemonType);
            _context.SaveChanges();

            return await Task.FromResult(pokemonType);
        }

        public async Task<object> Delete(Guid id)
        {
            PokemonType pokemonType = await _context.PokemonType.FindAsync(id);

            _context.PokemonType.Remove(pokemonType);
            _context.SaveChanges();

            throw new NotImplementedException();
        }
    }
}
