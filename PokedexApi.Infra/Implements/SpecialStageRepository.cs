using PokedexApi.Domain.Dtos;
using PokedexApi.Domain.Entities;
using PokedexApi.Domain.Interfaces;

namespace PokedexApi.Infra.Implements;

public class SpecialStageRepository : ISpecialStageRepository
{
    private readonly DataContext _context;

    public SpecialStageRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<object> AddAsync(SpecialStageAddDTO dto)
    {
        var specialStage = new SpecialStage()
        {
            Id = Guid.NewGuid(),
            PokemonId = dto.DexNumber,
            Name = dto.Name,
            Image = dto.Image,
            Description = dto.Description,
            Height = dto.Height,
            Weight = dto.Weight,
            Gender = ((int)dto.Gender),
            Rarity = ((int)dto.Rarity),
            Region = dto.Region,
        };

        _context.Add(specialStage);
        _context.SaveChanges();

        return await Task.FromResult(specialStage);
    }

    public async Task<IEnumerable<SpecialStage>> ListByPokemonIdAsync(int dexNumber)
    {
        IEnumerable<SpecialStage> specialStages = _context.SpecialStage
            .Where(s => s.PokemonId == dexNumber);

        return await Task.FromResult(specialStages);
    }
}
