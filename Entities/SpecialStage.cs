using PokedexApi.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokedexApi.Entities
{
    [Table("SpecialStage")]
    public class SpecialStage
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public int DexNumber { get; set; }

        [Required]
        [ForeignKey("FK_Pokemon")]
        public Pokemon Pokemon { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The length of the field must be up to 50 characters long")]
        public string Category { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The length of the field must be up to 50 characters long")]
        public string Name { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "The length of the field must be up to 50 characters long")]
        public string Description { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "The length of the field must be up to 50 characters long")]
        public string Image { get; set; }

        [Required]
        public double Height { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The length of the field must be up to 50 characters long")]
        public string Gender { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The length of the field must be up to 50 characters long")]
        public string Region { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The length of the field must be up to 50 characters long")]
        public string Rarity { get; set; }

        [Required]
        public List<string> Type { get; set; }

        [Required]
        public List<string> Weakness { get; set; }

    }
}