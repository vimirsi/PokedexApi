using AutoMapper;
using PokedexApi.Domain.Entities;
using PokedexApi.Web.Resources;

namespace PokedexApi.Web.Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Pokemon, PokemonListAllResource>(MemberList.Destination);
            CreateMap<Pokemon, PokemonGetWithParamsResource>(MemberList.Destination);
        }
    }
}