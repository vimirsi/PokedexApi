namespace PokedexApi.Web.FormRequest
{
    public class EvolutionAddFormRequest
    {
        public Guid? PreEvolution { get; set; }
        public int PokemonStage { get; set; }
    }
}
