using PokedexApi.Domain.Dtos;
using PokedexApi.Domain.Entities;

namespace PokedexApi.Domain.Interfaces
{
    public interface IPokemonRepository
    {
        Task<object> AddAsync (PokemonAddDTO dto);
        Task<object> DeleteAsync (Guid id);
        Task<Pokemon> GetByDexNumberAsync (int dexNumber);
        Task<IEnumerable<Pokemon>> ListAllAsync (int page);
        Task<IEnumerable<Pokemon>> ListWithParamsAsync (PokemonGetWithParamsDTO dto);
    }
}