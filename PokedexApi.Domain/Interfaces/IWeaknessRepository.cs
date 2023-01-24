using System;
using System.Threading.Tasks;
using PokedexApi.Core.Enums;
using PokedexApi.Domain.Entities;

namespace PokedexApi.Domain.Interfaces
{
    public interface IWeaknessRepository
    {
        Task<Weakness> Add (Guid? pokemonId, Guid? specialStageId, TypeEnum typeName);
    }
}