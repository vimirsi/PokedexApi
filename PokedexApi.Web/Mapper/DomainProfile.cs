using AutoMapper;
using PokedexApi.Domain.Entities;
using PokedexApi.Domain.Responses;
using PokedexApi.Web.Resources;

namespace PokedexApi.Web.Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Pokemon, PokemonListAllResource>(MemberList.Destination);
            CreateMap<Pokemon, PokemonGetWithParamsResource>(MemberList.Destination);
            CreateMap<Pokemon, PokemonEvolutionResource>(MemberList.Destination);
            CreateMap<EvolutionResponse, EvolutionResource>(MemberList.Destination);
        }
    }
}