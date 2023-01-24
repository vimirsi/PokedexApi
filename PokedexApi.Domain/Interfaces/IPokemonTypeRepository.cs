using System;
using System.Threading.Tasks;
using PokedexApi.Core.Enums;
using PokedexApi.Domain.Entities;

namespace PokedexApi.Domain.Interfaces
{
    public interface IPokemonTypeRepository
    {
        Task<PokemonType> Add (Guid? pokemonId, Guid? specialStageId, TypeEnum typeName);

        Task<PokemonType> GetBy(Guid? pokemonId, Guid? specialStageId);

        Task<PokemonType> Update(Guid id, TypeEnum typeName);

        Task<object> Delete(Guid id);
    }
}
