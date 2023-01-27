using PokedexApi.Domain.Dtos;
using PokedexApi.Domain.Entities;
using PokedexApi.Domain.Interfaces;

namespace PokedexApi.Infra.Implements
{
    public class EvolutionRepository : IEvolutionRepository
    {
        private readonly DataContext _context;

        public EvolutionRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Evolution> GetBy(EvolutionAddDTO dto)
        {
            if(dto.PokemonStage == ' ')
            {
                Evolution evolution = _context.Evolution.Where(x => x.PokemonStage == dto.PokemonStage).FirstOrDefault();

                return await Task.FromResult(evolution);
            }
            else
            {
                Evolution evolution = _context.Evolution.Where(x => x.PokemonStage == dto.PokemonStage).FirstOrDefault();

                return await Task.FromResult(evolution);
            }
        }
    }
}