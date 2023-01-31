namespace PokedexApi.Domain.Dtos
{
    public class EvolutionGetByParamsDTO
    {
        public Guid PokemonId { get; set; }
        public Guid PreEvolution { get; set; }
        public Guid EvolutionForm { get; set; }
    }
}
