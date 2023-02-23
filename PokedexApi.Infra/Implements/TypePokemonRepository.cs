using PokedexApi.Domain.Interfaces;

namespace PokedexApi.Infra.Implements;

public class TypePokemonRepository : ITypePokemonRepository
{
    private readonly DataContext _context;

    public TypePokemonRepository(DataContext context)
    {
        _context = context;
    }
}

