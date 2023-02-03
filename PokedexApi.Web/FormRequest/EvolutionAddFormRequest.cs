namespace PokedexApi.Web.FormRequest
{
    public class EvolutionAddFormRequest
    {
        public int PokemonId { get; set; }
        public int? PreEvolution { get; set; }
        public int? EvolutionForm { get; set; }
    }
}
