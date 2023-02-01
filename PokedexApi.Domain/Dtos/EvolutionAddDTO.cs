namespace PokedexApi.Domain.Dtos
{
    public class EvolutionAddDTO
    {
        public Guid PokemonId { get; set; }
        public Guid? PreEvolution { get; set; }
        public Guid? EvolutionForm { get; set; }
    }
}
