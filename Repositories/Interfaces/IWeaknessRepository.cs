using PokedexApi.Entities;
using PokedexApi.Enums;

namespace PokedexApi.Repositories.Interfaces
{
    public interface IWeaknessRepository
    {
        Task<Weakness> Add (Guid? pokemonId, Guid? specialStageId, TypeEnum typeName);
    }
}