namespace PokedexApi.Web.FormRequest
{
    public class EvolutionAddFormRequest
    {
        public Guid PokemonId { get; set; }
        public Guid PreEvolution { get; set; }
        public Guid EvolutionForm { get; set; }
    }
}
