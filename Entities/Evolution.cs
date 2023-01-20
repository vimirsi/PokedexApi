using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokedexApi.Entities
{
    [Table("Evolution")]
    public class Evolution
    {

        [Key]
        public Guid Id { get; set; }

        public Guid Stage1 { get; set; }

        public Guid Stage2 { get; set; }

        public Guid Stage3 { get; set; }

        public Guid Stage4 { get; set; }
    }
}