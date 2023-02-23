using PokedexApi.Domain.Dtos;
using PokedexApi.Domain.Entities;

namespace PokedexApi.Domain.Interfaces
{
    public interface ISpecialStageRepository
    {
        Task<object> AddAsync (SpecialStageAddDTO dto);
        Task<IEnumerable<SpecialStage>> ListByPokemonIdAsync (int dexNumber);
    }
}