using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PokedexApi.Core.Enums;

namespace PokedexApi.Domain.Entities
{
    [Table("SpecialStage")]
    public class SpecialStage
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey("Pokemon")]
        public int PokemonId { get; set; }
        public Pokemon Pokemon { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The length of the field must be up to 50 characters long")]
        public string Name { get; set; }

        [Required]
        [StringLength(300, ErrorMessage = "The length of the field must be up to 300 characters long")]
        public string Image { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "The length of the field must be up to 200 characters long")]
        public string Description { get; set; }

        [Required]
        public double Height { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        [EnumDataType(typeof(GenderEnum))]
        public int Gender { get; set; }

        [Required]
        [EnumDataType(typeof(RarityEnum))]
        public int Rarity { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The length of the field must be up to 50 characters long")]
        public string Region { get; set; }


        #region prop navigates
        public virtual List<TypePokemon> TypePokemon { get; set; }
        public virtual List<Weakness> Weakness { get; set; }
        public virtual Evolution Evolution { get; set; }
        public virtual Stats Stats { get; set; }
        #endregion
    }
}