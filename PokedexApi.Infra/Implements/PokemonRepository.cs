using PokedexApi.Domain.Dtos;
using PokedexApi.Domain.Entities;
using PokedexApi.Domain.Interfaces;

namespace PokedexApi.Infra.Implements
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly DataContext _context;
        private static int _PageSize = 3;

        public PokemonRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<object> AddAsync(PokemonAddDTO dto)
        {
            Pokemon validation = _context.Pokemon
                .Where(x => x.DexNumber == dto.DexNumber)
                .FirstOrDefault();

            if(validation != null)
            {
                throw new Exception($"there is already a pokemon with the dex number: {dto.DexNumber}");
            }

            var pokemon = new Pokemon()
            {
                DexNumber = dto.DexNumber,
                RelationshipPage = dto.RelationshipPage,
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

            return await Task.FromResult(new object{});
        }

        public async Task<object> DeleteAsync(int dexNumber)
        {
            Pokemon pokemon = await _context.Pokemon.FindAsync(dexNumber);

            if(pokemon is null)
            {
                throw new Exception($"Not found pokemon with id {dexNumber}");
            }

            _context.Pokemon.Remove(pokemon);
            _context.SaveChanges();

            return await Task.FromResult(new object(){});
        }

        public async Task<Pokemon> GetByDexNumberAsync(int dexNumber)
        {
            Pokemon pokemon = _context.Pokemon
                .Where(x => x.DexNumber == dexNumber)
                .Select(x => new Pokemon{
                    DexNumber = x.DexNumber,
                    Name = x.Name,
                    Image = x.Image,
                    Description = x.Description,
                    Height = x.Height,
                    Weight = x.Weight,
                    Rarity = x.Rarity,
                    Region = x.Region,
                    Weakness = x.Weakness,
                    
                })
                .FirstOrDefault();

            if(pokemon is null)
            {
                throw new Exception($"Not found pokemon with id {dexNumber}");
            }

            return await Task.FromResult(pokemon);
        }

        public async Task<IEnumerable<Pokemon>> ListAllAsync(int page)
        {
            if (page == 0)
            {
                page = 1;
            }

            IEnumerable<Pokemon> pokemons = _context.Pokemon
                .Select(x => new Pokemon
                {
                    DexNumber = x.DexNumber,
                    RelationshipPage = x.RelationshipPage,
                    Name = x.Name,
                    Image = x.Image,
                    Description = x.Description,
                    Height = x.Height,
                    Weight = x.Weight,
                    Gender = x.Gender,
                    Rarity = x.Rarity,
                    Region = x.Region,
                })
                .Where(x => x.RelationshipPage == page)
                .OrderBy(x => x.DexNumber)
                .ToList();

            return await Task.FromResult(pokemons);
        }

        public async Task<IEnumerable<Pokemon>> ListWithParamsAsync(PokemonGetWithParamsDTO dto)
        {
            if (dto.Page == 0)
            {
                dto.Page = 1;
            }

            IEnumerable<Pokemon> pokemons = _context.Pokemon
                .Select(x => new Pokemon
                {
                    DexNumber = x.DexNumber,
                    Name = x.Name,
                    Image = x.Image,
                    Description = x.Description,
                    Height = x.Height,
                    Weight = x.Weight,
                    Gender = x.Gender,
                    Rarity = x.Rarity,
                    Region = x.Region,
                })
                .Where(x => x.Name.Contains(dto.Param) || x.Region.Contains(dto.Param))
                .OrderBy(x => x.DexNumber)
                .ToList();

            return await Task.FromResult(pokemons);
        }
    }
}