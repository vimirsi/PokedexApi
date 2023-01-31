using PokedexApi.Domain.Dtos;
using PokedexApi.Domain.Entities;

namespace PokedexApi.Domain.Interfaces
{
    public interface IEvolutionRepository
    {
        Task<Evolution> AddAsync(EvolutionAddDTO dto);
        // Task<Evolution> GetByParamsAsync(EvolutionGetByParamsDTO dto);
        Task<object> DeleteAsync(Guid id);
    }
}