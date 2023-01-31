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

        public async Task<Evolution> AddAsync(EvolutionAddDTO dto)
        {
            var id = Guid.NewGuid();

            var evolution = new Evolution()
            {
                Id = id,
                PokemonId = dto.PokemonId,
                PreEvolution = dto.PreEvolution,
                EvolutionForm = dto.EvolutionForm
            };

            _context.Evolution.Add(evolution);
            _context.SaveChanges();

            return await Task.FromResult(evolution);
        }

        // public async Task<Evolution> GetByParamsAsync(EvolutionGetByParamsDTO dto)
        // {
        //     if (dto.PreEvolution != Guid.Empty && dto.PokemonStage != 0)
        //     {
        //         throw new Exception("Route not able to search for both 'PreEvolution' and 'Pokemon Stage' at the same time. Please use only one of the filters.");
        //     }
            
        //     if(dto.PokemonStage == 0)
        //     {
        //         Evolution evolution = _context.Evolution.Where(x => x.PreEvolution == dto.PreEvolution).FirstOrDefault();

        //         return await Task.FromResult(evolution);
        //     }
        //     else
        //     {
        //         Evolution evolution = _context.Evolution.Where(x => x.PokemonStage == dto.PokemonStage).FirstOrDefault();

        //         return await Task.FromResult(evolution);
        //     }
        // }

        public async Task<object> DeleteAsync(Guid id)
        {
            Evolution evolution = await _context.Evolution.FindAsync(id);

            if(evolution is null)
            {
                throw new Exception($"Not found evolution with id {id}");
            }

            _context.Evolution.Remove(evolution);
            _context.SaveChanges();

            return await Task.FromResult(new object() { });
        }
    }
}