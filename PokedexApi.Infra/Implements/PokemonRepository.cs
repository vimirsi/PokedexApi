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

        public async Task<Pokemon> AddAsync(PokemonAddDTO dto)
        {
            var id = Guid.NewGuid();

            var pokemon = new Pokemon()
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

            _context.Add(pokemon);
            _context.SaveChanges();

            return await Task.FromResult(pokemon);
        }

        public async Task<object> DeleteAsync(Guid id)
        {
            Pokemon pokemon = await _context.Pokemon.FindAsync(id);

            if(pokemon is null)
            {
                throw new Exception($"Not found pokemon with id {id}");
            }

            _context.Pokemon.Remove(pokemon);
            _context.SaveChanges();

            return await Task.FromResult(new object(){});
        }

        public async Task<Pokemon> GetByIdAsync(int dexNumber)
        {
            Pokemon pokemon = _context.Pokemon
                .Where(x => x.DexNumber == dexNumber)
                .FirstOrDefault();

            if(pokemon is null)
            {
                throw new Exception($"Not found pokemon with id {dexNumber}");
            }

            return await Task.FromResult(pokemon);
        }

        public async Task<IEnumerable<Pokemon>> AllAsync(PokemonListAllDTO dto)
        {
            IEnumerable<Pokemon> pokemons = _context.Pokemon
                .Skip((dto.Page - 1) * dto.PageSize)
                .Take(dto.PageSize)
                .ToList();

            return await Task.FromResult(pokemons);
        }

        public async Task<IEnumerable<Pokemon>> GetWithParamsAsync(PokemonGetWithParamsDTO dto)
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