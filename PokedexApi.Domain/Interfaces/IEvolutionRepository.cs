using PokedexApi.Domain.Dtos;
using PokedexApi.Domain.Entities;

namespace PokedexApi.Domain.Interfaces
{
    public interface IEvolutionRepository
    {
        Task<Evolution> GetBy(EvolutionAddDTO dto);
    }
}