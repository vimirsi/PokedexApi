using pokedexapi.Repositories.Implements;
using PokedexApi.Entities;
using PokedexApi.Enums;

namespace pokedexapi.Repositories.Interfaces
{
    public interface IPokemonTypeRepository
    {
        Task<PokemonType> Add (Guid? pokemonId, Guid? specialStageId, TypeEnum typeName);

        Task<PokemonType> GetBy(Guid? pokemonId, Guid? specialStageId);

        Task<PokemonType> Update(Guid id, TypeEnum typeName);

        Task<object> Delete(Guid id);
    }
}
