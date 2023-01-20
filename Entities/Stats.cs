using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokedexApi.Entities
{

    [Table("Stats")]
    public class Stats
    {

        [Key]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey("FK_Pokemon")]
        public Pokemon Pokemon { get; set; }

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