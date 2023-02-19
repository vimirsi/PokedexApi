using PokedexApi.Core.Enums;
namespace PokedexApi.Web.Models;

public class PokemonModel
{
    public int DexNumber { get; set; }
    public string Name { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }
    public double Height { get; set; }
    public double Weight { get; set; }
    public string Gender { get; set; }
    public string Rarity { get; set; }
    public string Region { get; set; }
}
