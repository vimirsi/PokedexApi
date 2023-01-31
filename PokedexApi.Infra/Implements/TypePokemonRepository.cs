using PokedexApi.Core.Enums;
using PokedexApi.Domain.Dtos;
using PokedexApi.Domain.Entities;
using PokedexApi.Domain.Interfaces;

namespace PokedexApi.Infra.Implements
{
    public class TypePokemonRepository : ITypePokemonRepository
    {
        private readonly DataContext _context;

        public TypePokemonRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<TypePokemon> AddAsync(TypePokemonAddDTO dto)
        {
            var id = Guid.NewGuid();

            if(dto.PokemonId != null && dto.SpecialStageId != null)
            {
                throw new InvalidDataException();
            }

            var typePokemon = new TypePokemon()
            {
                Id = id,
                PokemonId = dto.PokemonId,
                SpecialStageId = dto.SpecialStageId,
                TypeName = ((int)dto.TypeName)
            };

            _context.TypePokemon.Add(typePokemon);
            _context.SaveChanges();

            return await Task.FromResult(typePokemon);
        }

        public async Task<Domain.Entities.TypePokemon> GetBy(TypePokemonGetByDTO dto)
        {
            if (dto.PokemonId is null)
            {
                TypePokemon pokemonType = _context.TypePokemon.Where(x => x.SpecialStageId == dto.SpecialStageId).FirstOrDefault();

                return await Task.FromResult(pokemonType);
            }
            else
            {
                TypePokemon pokemonType = _context.TypePokemon.Where(x => x.PokemonId == dto.PokemonId).FirstOrDefault();

                return await Task.FromResult(pokemonType);
            }
        }

        public async Task<Domain.Entities.TypePokemon> Update(TypePokemonUpdateDTO dto)
        {
            Domain.Entities.TypePokemon pokemonType = await _context.TypePokemon.FindAsync(dto.Id);

            pokemonType.TypeName = ((int)dto.TypeName);

            _context.TypePokemon.Update(pokemonType);
            _context.SaveChanges();

            return await Task.FromResult(pokemonType);
        }

        public async Task<object> Delete(TypePokemonDeleteDTO dto)
        {
            Domain.Entities.TypePokemon pokemonType = await _context.TypePokemon.FindAsync(dto.Id);

            _context.TypePokemon.Remove(pokemonType);
            _context.SaveChanges();

            throw new NotImplementedException();
        }
    }
}
