using AutoMapper;
using PokedexApi.Core.utils;
using PokedexApi.Domain.Entities;
using PokedexApi.Domain.Responses;
using PokedexApi.Web.Models;

namespace PokedexApi.Web.Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Pokemon, PokemonModel>()
            .ForMember(
                dest => dest.Gender,
                opt => opt.MapFrom(src => src.Gender.DecodeToStringGenderEnum())
            )
            .ForMember(
                dest => dest.Rarity,
                opt => opt.MapFrom(src => src.Rarity.DecodeToStringRarityEnum())
            );
            
            CreateMap<EvolutionResponse, EvolutionModel>(MemberList.Destination);
        }
    }
}