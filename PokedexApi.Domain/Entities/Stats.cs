using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokedexApi.Domain.Entities
{

    [Table("Stats")]
    public class Stats
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Pokemon")]
        public Guid? PokemonId { get; set; }
        public Pokemon Pokemon { get; set; }

        [ForeignKey("SpecialStage")]
        public Guid? SpecialStageId { get; set; }
        public SpecialStage SpecialStage { get; set; }

        [Required]
        public int HealthPoints { get; set; }

        [Required]
        public int Attack { get; set; }

        [Required]
        public int Defense { get; set; }

        [Required]
        public int Sp_Attack { get; set; }

        [Required]
        public int Sp_Defense { get; set; }

        [Required]
        public int Speed { get; set; }
    }
}