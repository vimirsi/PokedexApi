using PokedexApi.Domain.Dtos;
using PokedexApi.Domain.Entities;

namespace PokedexApi.Domain.Interfaces
{
    public interface ISpecialStageRepository
    {
        Task<SpecialStage> AddAsync (SpecialStageAddDTO dto);
        Task<object> DeleteAsync (int dexNumber);
        Task<SpecialStage> GetByIdAsync (int dexNumber);
        Task<IEnumerable<SpecialStage>> AllAsync (int page);
    }
}