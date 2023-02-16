using Microsoft.EntityFrameworkCore;
using PokedexApi.Domain.Interfaces;
using PokedexApi.Infra;
using PokedexApi.Infra.Implements;

namespace Tests.Repository
{
    [TestClass]
    public class PokemonRepositoryTests
    {
        private DataContext context;
        private IPokemonRepository repository;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "pokedexdatabase")
            .Options;

            context = new DataContext(options);
            repository = new PokemonRepository(context);
        }

        [TestMethod]
        public void TestName()
        {
            // Given
        
            // When
        
            // Then
        }
    }
}