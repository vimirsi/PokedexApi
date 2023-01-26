using PokedexApi.Domain.Dtos;
using PokedexApi.Domain.Entities;

namespace PokedexApi.Domain.Interfaces
{
    public interface IPokemonRepository
    {
        Task<Pokemon> Add (PokemonAddDTO dto);
        Task<IEnumerable<Pokemon>> All (PokemonListAllDTO dto);
        Task<IEnumerable<Pokemon>> GetWithParams (PokemonGetWithParamsDTO dto);
    }
}