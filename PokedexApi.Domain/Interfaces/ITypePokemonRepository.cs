using System;
using System.Threading.Tasks;
using PokedexApi.Core.Enums;
using PokedexApi.Domain.Dtos;
using PokedexApi.Domain.Entities;

namespace PokedexApi.Domain.Interfaces
{
    public interface ITypePokemonRepository
    {
        Task<Entities.TypePokemon> AddAsync (TypePokemonAddDTO dto);

        Task<Entities.TypePokemon> GetBy (TypePokemonGetByDTO dto);

        Task<Entities.TypePokemon> Update (TypePokemonUpdateDTO dto);

        Task<object> Delete(TypePokemonDeleteDTO dto);
    }
}
