using PokedexApi.Core.Enums;
using PokedexApi.Domain.Dtos;
using PokedexApi.Domain.Entities;
using PokedexApi.Domain.Interfaces;

namespace PokedexApi.Infra.Implements
{
    public class PokemonTypeRepository : IPokemonTypeRepository
    {
        private readonly DataContext _context;

        public PokemonTypeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<PokemonType> Add(PokemonTypeAddDTO dto)
        {
            var id = Guid.NewGuid();

            if(dto.PokemonId != null && dto.SpecialStageId != null)
            {
                throw new InvalidDataException();
            }

            var pokemonType = new PokemonType()
            {
                Id = id,
                PokemonId = dto.PokemonId,
                SpecialStageId = dto.SpecialStageId,
                TypeName = ((int)dto.TypeName)
            };

            _context.PokemonType.Add(pokemonType);
            _context.SaveChanges();

            return await Task.FromResult(pokemonType);
        }

        public async Task<PokemonType> GetBy(PokemonTypeGetByDTO dto)
        {
            if (dto.PokemonId is null)
            {
                PokemonType pokemonType = _context.PokemonType.Where(x => x.SpecialStageId == dto.SpecialStageId).FirstOrDefault();

                return await Task.FromResult(pokemonType);
            }
            else
            {
                PokemonType pokemonType = _context.PokemonType.Where(x => x.PokemonId == dto.PokemonId).FirstOrDefault();

                return await Task.FromResult(pokemonType);
            }
        }

        public async Task<PokemonType> Update(PokemonTypeUpdateDTO dto)
        {
            PokemonType pokemonType = await _context.PokemonType.FindAsync(dto.Id);

            pokemonType.TypeName = ((int)dto.TypeName);

            _context.PokemonType.Update(pokemonType);
            _context.SaveChanges();

            return await Task.FromResult(pokemonType);
        }

        public async Task<object> Delete(PokemonTypeDeleteDTO dto)
        {
            PokemonType pokemonType = await _context.PokemonType.FindAsync(dto.Id);

            _context.PokemonType.Remove(pokemonType);
            _context.SaveChanges();

            throw new NotImplementedException();
        }
    }
}
