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

        public async Task<EvolutionResponse> GetByIdAsync(EvolutionGetByIdDTO dto)
        {
            Evolution evolution = _context.Evolution
                .Include(x => x.Pokemon)
                .Where(x => x.PokemonId == dto.PokemonId)
                .Select(x => new Evolution
                {
                    Pokemon = new Pokemon
                    {
                        DexNumber = x.Pokemon.DexNumber,
                        Name = x.Pokemon.Name,
                        Image = x.Pokemon.Image,
                        Description =x.Pokemon.Description,
                        Height = x.Pokemon.Height,
                        Weight = x.Pokemon.Weight,
                        Gender = x.Pokemon.Gender,
                        Rarity = x.Pokemon.Rarity,
                        Region = x.Pokemon.Region
                    },
                    PreEvolution = x.PreEvolution,
                    EvolutionForm = x.EvolutionForm,
                })
                .FirstOrDefault();

            if(evolution is null)
            {
                throw new Exception($"Not Found evolution with pokemon id: {dto.PokemonId}");
            }

            Pokemon preEvolution = _context.Pokemon
                .Where(x => x.Id == evolution.PreEvolution)
                .Select(x => new Pokemon{
                    Id = x.Id,
                    DexNumber = x.DexNumber,
                    Name = x.Name,
                    Image = x.Image,
                    Description = x.Description,
                    Height = x.Height,
                    Weight = x.Weight,
                    Gender = x.Gender,
                    Rarity = x.Rarity,
                    Region = x.Region
                })
                .FirstOrDefault();
                
            Pokemon evolutionForm = _context.Pokemon
                .Where(x => x.Id == evolution.EvolutionForm)
                .Select(x => new Pokemon{
                    Id = x.Id,
                    DexNumber = x.DexNumber,
                    Name = x.Name,
                    Image = x.Image,
                    Description = x.Description,
                    Height = x.Height,
                    Weight = x.Weight,
                    Gender = x.Gender,
                    Rarity = x.Rarity,
                    Region = x.Region
                })
                .FirstOrDefault();

            var response = new EvolutionResponse()
            {
                PreEvolution = preEvolution,
                ActualStage = evolution.Pokemon,
                EvolutionForm = evolutionForm
            };

            return await Task.FromResult(response);
        }

        public async Task<object> DeleteAsync(Guid pokemonId)
        {
            Evolution evolution = _context.Evolution.Where(x => x.PokemonId == pokemonId).FirstOrDefault();

            if(evolution is null)
            {
                throw new Exception($"Not found evolution with id {pokemonId}");
            }

            _context.Evolution.Remove(evolution);
            _context.SaveChanges();

            return await Task.FromResult(new object(){ });
        }

        public Task<IEnumerable<Evolution>> ListAll()
        {
            IEnumerable<Evolution> evolutions  = _context.Evolution.ToList();

            return Task.FromResult(evolutions);
        }
    }
}