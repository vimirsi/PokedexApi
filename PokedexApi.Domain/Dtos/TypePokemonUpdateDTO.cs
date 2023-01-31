using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexApi.Domain.Dtos
{
    public class TypePokemonUpdateDTO
    {
        public Guid Id { get; set; }
        public int TypeName { get; set; }
    }
}
