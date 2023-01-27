using PokedexApi.Domain.Dtos;
using PokedexApi.Domain.Entities;

namespace PokedexApi.Domain.Interfaces
{
    public interface IPokemonRepository
    {
        Task<Pokemon> AddAsync (PokemonAddDTO dto);
        Task<object> DeleteAsync (Guid id);
        Task<Pokemon> GetByIdAsync (int dexNumber);
        Task<IEnumerable<Pokemon>> AllAsync (PokemonListAllDTO dto);
        Task<IEnumerable<Pokemon>> GetWithParamsAsync (PokemonGetWithParamsDTO dto);
    }
}