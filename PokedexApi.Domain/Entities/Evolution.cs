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
        public Guid? PreEvolution { get; set; }
        public Pokemon Pokemon { get; set; }

        public int PokemonStage { get; set; }
    }
}