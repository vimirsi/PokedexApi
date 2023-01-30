using PokedexApi.Domain.Dtos;
using PokedexApi.Domain.Entities;
using PokedexApi.Domain.Interfaces;

namespace PokedexApi.Infra.Implements
{
    public class SpecialStageRepository : ISpecialStageRepository
    {
        private readonly DataContext _context;

        public SpecialStageRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<SpecialStage> AddAsync(SpecialStageAddDTO dto)
        {
            var id = Guid.NewGuid();

            var specialStage = new SpecialStage()
            {
                Id = id,
                PokemonId = dto.PokemonId,
                DexNumber = dto.DexNumber,
                Category = dto.Category,
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

        public async Task<object> DeleteAsync(Guid id)
        {
            SpecialStage specialStage = await _context.SpecialStage.FindAsync(id);

            if(specialStage is null)
            {
                throw new Exception($"Not found pokemon with id {id}");
            }

            _context.SpecialStage.Remove(specialStage);
            _context.SaveChanges();

            return await Task.FromResult(new object(){});
        }

        public async Task<IEnumerable<SpecialStage>> AllAsync(SpecialStageListAllDTO dto)
        {
            IEnumerable<SpecialStage> specialStage = _context.SpecialStage
                .Skip((dto.Page - 1) * dto.PageSize)
                .Take(dto.PageSize)
                .ToList();

            return await Task.FromResult(specialStage);
        }

        public async Task<SpecialStage> GetByIdAsync(int dexNumber)
        {
            SpecialStage specialStage = _context.SpecialStage
                .Where(x => x.DexNumber == dexNumber)
                .FirstOrDefault();

            if(specialStage is null)
            {
                throw new Exception($"Not found pokemon with id {dexNumber}");
            }

            return await Task.FromResult(specialStage);
        }
    }
}