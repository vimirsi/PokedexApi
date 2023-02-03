using PokedexApi.Domain.Dtos;
using PokedexApi.Domain.Entities;
using PokedexApi.Domain.Responses;

namespace PokedexApi.Domain.Interfaces
{
    public interface IEvolutionRepository
    {
        Task<Evolution> AddAsync(EvolutionAddDTO dto);
        Task<EvolutionResponse> GetByIdAsync(EvolutionGetByIdDTO dto);
        Task<object> DeleteAsync(Guid id);
    }
}