using PokedexApi.Domain.Dtos;
using PokedexApi.Domain.Responses;

namespace PokedexApi.Domain.Interfaces
{
    public interface IEvolutionRepository
    {
        Task<object> AddAsync(EvolutionAddDTO dto);
        Task<object> DeleteAsync(int dexNumber);
        Task<EvolutionResponse> GetByIdAsync(int dexNumber);
    }
}