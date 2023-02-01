using PokedexApi.Core.Enums;

namespace PokedexApi.Web.Resources
{
    public class EvolutionResource
    {
        public PokemonEvolutionResource PreEvolution { get; set; }
        public PokemonEvolutionResource ActualStage { get; set; }
        public PokemonEvolutionResource EvolutionForm { get; set; }
    }

    public class PokemonEvolutionResource
    {
        public int DexNumber { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public GenderEnum Gender { get; set; }
        public RarityEnum Rarity { get; set; }
        public string Region { get; set; }
    }
}