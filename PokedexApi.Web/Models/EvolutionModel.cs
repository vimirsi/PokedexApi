namespace PokedexApi.Web.Models
{
    public class EvolutionModel
    {
        public PokemonModel PreEvolution { get; set; }
        public PokemonModel ActualStage { get; set; }
        public PokemonModel EvolutionForm { get; set; }
    }
}