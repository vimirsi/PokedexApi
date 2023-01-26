using PokedexApi.Domain.Dtos;
using PokedexApi.Domain.Entities;
using PokedexApi.Domain.Interfaces;

namespace PokedexApi.Infra.Implements
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly DataContext _context;

        public PokemonRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Pokemon> Add(PokemonAddDTO dto)
        {
            var id = Guid.NewGuid();

            var Pokemon = new Pokemon()
            {
                Id = id,
                DexNumber = dto.DexNumber,
                Category = dto.Category,
                Name = dto.Name,
                Image = dto.Image,
                Description = dto.Description,
                Height = dto.Height,
                Weight = dto.Weight,
                Gender = ((int)dto.Gender),
                Rarity = ((int)dto.Rarity),
                Region = dto.Region,
            };

            _context.Add(Pokemon);
            _context.SaveChanges();

            return await Task.FromResult(Pokemon);
        }
    }
}