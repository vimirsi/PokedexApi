using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PokedexApi.Core.Enums;

namespace PokedexApi.Domain.Entities
{
    [Table("Weakness")]
    public class Weakness
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Pokemon")]
        public int? PokemonId { get; set; }
        public Pokemon Pokemon { get; set; }

        [ForeignKey("SpecialStage")]
        public Guid? SpecialStageId { get; set; }
        public SpecialStage SpecialStage { get; set; }

        [Required]
        [EnumDataType(typeof(TypeEnum))]
        public int TypeName { get; set; }
    }
}