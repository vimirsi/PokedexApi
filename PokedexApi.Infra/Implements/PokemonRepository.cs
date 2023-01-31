using PokedexApi.Domain.Dtos;
using PokedexApi.Domain.Entities;
using PokedexApi.Domain.Interfaces;

namespace PokedexApi.Infra.Implements
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly DataContext _context;
        private static int _PageSize = 10;

        public PokemonRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Pokemon> AddAsync(PokemonAddDTO dto)
        {
            var id = Guid.NewGuid();

            Pokemon validation = _context.Pokemon.Where(x => x.DexNumber == dto.DexNumber).FirstOrDefault();

            if(validation != null)
            {
                throw new Exception($"there is already a pokemon with the dex number: {dto.DexNumber}");
            }

            var pokemon = new Pokemon()
            {
                Id = id,
                DexNumber = dto.DexNumber,
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
                .Skip((dto.Page - 1) * _PageSize)
                .Take(_PageSize)
                .OrderBy(x => x.DexNumber)
                .ToList();

            return await Task.FromResult(pokemons);
        }

        public async Task<IEnumerable<Pokemon>> GetWithParamsAsync(PokemonGetWithParamsDTO dto)
        {
            IEnumerable<Pokemon> pokemons = _context.Pokemon
                .Skip((dto.Page - 1) * _PageSize)
                .Take(_PageSize)
                .OrderBy(x => x.DexNumber)
                .ToList();
            
            pokemons = pokemons
                .Where(x => dto.Name != null ? (x.Name.Contains(dto.Name)) : true)
                .Where(x => dto.Region != null ? (x.Region.Contains(dto.Region)) : true);

            return await Task.FromResult(pokemons);
        }
    }
}