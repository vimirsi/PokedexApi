namespace PokedexApi.Web.FormRequest
{
    public class PokemonGetWithParamsFormRequest
    {
        public string Name { get; set; }
        public string Region { get; set; }
        public int Page { get; set; }
    }
}