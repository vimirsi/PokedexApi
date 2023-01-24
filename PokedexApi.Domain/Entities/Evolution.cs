using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokedexApi.Domain.Entities
{
    [Table("Evolution")]
    public class Evolution
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Pokemon")]
        public Guid? PokemonId { get; set; }
        public Pokemon Pokemon { get; set; }

        [ForeignKey("SpecialStage")]
        public Guid? SpecialStageId { get; set; }
        public SpecialStage SpecialStage { get; set; }

        public Guid? Stage2 { get; set; }

        public Guid? Stage3 { get; set; }

        public Guid? Stage4 { get; set; }
    }
}