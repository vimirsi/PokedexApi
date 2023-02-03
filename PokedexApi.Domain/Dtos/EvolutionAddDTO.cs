namespace PokedexApi.Domain.Dtos
{
    public class EvolutionAddDTO
    {
        public int PokemonId { get; set; }
        public int? PreEvolution { get; set; }
        public int? EvolutionForm { get; set; }
    }
}
