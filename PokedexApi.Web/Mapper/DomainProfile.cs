using AutoMapper;
using PokedexApi.Domain.Entities;
using PokedexApi.Web.Models;

namespace PokedexApi.Web.Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Pokemon, PokemonModel>(MemberList.Destination);
        }
    }
}