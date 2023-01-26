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

        public async Task<IEnumerable<Pokemon>> All(PokemonListAllDTO dto)
        {
            IEnumerable<Pokemon> pokemons = _context.Pokemon
                .Skip((dto.Page - 1) * dto.PageSize)
                .Take(dto.PageSize)
                .ToList();

            return await Task.FromResult(pokemons);
        }

        public async Task<IEnumerable<Pokemon>> GetWithParams(PokemonGetWithParamsDTO dto)
        {
            IEnumerable<Pokemon> pokemons = _context.Pokemon
                .Skip((dto.Page - 1) * dto.PageSize)
                .Take(dto.PageSize)
                .ToList();
            
            pokemons = pokemons
                .Where(x => dto.Category != null ? (x.Category.Contains(dto.Category)) : true)
                .Where(x => dto.Name != null ? (x.Name.Contains(dto.Name)) : true)
                .Where(x => dto.Region != null ? (x.Region.Contains(dto.Region)) : true)
                .Where(x => dto.Category != null ? (x.Category.Contains(dto.Category)) : true);

            return await Task.FromResult(pokemons);
        }
    }
}