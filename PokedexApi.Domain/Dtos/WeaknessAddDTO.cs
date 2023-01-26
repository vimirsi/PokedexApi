using PokedexApi.Core.Enums;
using PokedexApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexApi.Domain.Dtos
{
    public class WeaknessAddDTO
    {        
        public Guid? PokemonId { get; set; }
        public Guid? SpecialStageId { get; set; }
        public int TypeName { get; set; }
    }
}
