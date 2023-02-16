using PokedexApi.Core.Enums;

namespace PokedexApi.Web.FormRequest
{
    public class SpecialStageCreateFormRequest
    {
        public int PokemonId { get; set; }
        public int DexNumber { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string Region { get; set; }
    }
}