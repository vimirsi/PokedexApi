using System;
using System.Threading.Tasks;
using PokedexApi.Core.Enums;
using PokedexApi.Domain.Dtos;
using PokedexApi.Domain.Entities;

namespace PokedexApi.Domain.Interfaces
{
    public interface IPokemonTypeRepository
    {
        Task<PokemonType> Add (PokemonTypeAddDTO dto);

        Task<PokemonType> GetBy(PokemonTypeGetByDTO dto);

        Task<PokemonType> Update(PokemonTypeUpdateDTO dto);

        Task<object> Delete(PokemonTypeDeleteDTO dto);
    }
}
