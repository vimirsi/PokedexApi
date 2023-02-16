using Microsoft.EntityFrameworkCore;
using PokedexApi.Domain.Dtos;
using PokedexApi.Domain.Entities;
using PokedexApi.Domain.Interfaces;
using PokedexApi.Domain.Responses;

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
            var evolution = new Evolution()
            {
                PokemonId = dto.PokemonId,
                PreEvolution = dto.PreEvolution,
                EvolutionForm = dto.EvolutionForm
            };

            _context.Evolution.Add(evolution);
            _context.SaveChanges();

            return await Task.FromResult(evolution);
        }

        public async Task<EvolutionResponse> GetByIdAsync(int dexNumber)
        {
            Evolution evolution = _context.Evolution.Find(dexNumber);

            if(evolution is null)
            {
                throw new Exception($"Not found evolution with id {dexNumber}");
            }

            Pokemon preEvolution = _context.Pokemon
                .Find(evolution.PreEvolution);

            Pokemon actualStage = _context.Pokemon
                .Find(dexNumber);

            Pokemon evolutionForm = _context.Pokemon
                .Find(evolution.EvolutionForm);

            var response = new EvolutionResponse()
            {
                PreEvolution = preEvolution,
                ActualStage = actualStage,
                EvolutionForm = evolutionForm
            };

            return await Task.FromResult(response);
        }

        public async Task<object> DeleteAsync(int dexNumber)
        {
            Evolution evolution = _context.Evolution.Find(dexNumber);

            if(evolution is null)
            {
                throw new Exception($"Not found evolution with id {dexNumber}");
            }

            _context.Evolution.Remove(evolution);
            _context.SaveChanges();

            return await Task.FromResult(new object(){ });
        }
    }
}