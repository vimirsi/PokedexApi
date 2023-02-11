using Microsoft.EntityFrameworkCore;
using PokedexApi.Domain.Interfaces;
using PokedexApi.Infra;
using PokedexApi.Infra.Implements;

namespace Tests.Repository
{
    public class EvolutionRepositoryTests
    {
        private DataContext context;
        private IEvolutionRepository repository;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "pokedexdatabase")
            .Options;

            context = new DataContext(options);
            repository = new EvolutionRepository(context);
        }

        [TestMethod]
        public void CreateEvolution_WhenCalled_ReturnSuccess()
        {  
        }
    }
}