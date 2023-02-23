namespace PokedexApi.Domain.Dtos
{
    public class TypePokemonAddDTO
    {
        public int? PokemonId { get; set; }

        public Guid? SpecialStageId { get; set; }

        public int TypeName { get; set; }
    }
}
