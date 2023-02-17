using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokedexApi.Domain.Entities
{
    [Table("Evolution")]
    public class Evolution
    {
        [Key]
        [ForeignKey("Pokemon")]
        public int PokemonId { get; set; }
        public Pokemon Pokemon { get; set; }
        
        public int? PreEvolution { get; set; }
        public int? EvolutionForm { get; set; }
    }
}