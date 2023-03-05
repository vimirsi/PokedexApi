using Microsoft.EntityFrameworkCore;
using PokedexApi.Domain.Interfaces;
using PokedexApi.Infra;
using PokedexApi.Infra.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Repository
{
    [TestClass]
    public class SpecialStageTests
    {
        private DataContext context;
        private ISpecialStageRepository repository;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "pokedexdatabase")
            .Options;

            context = new DataContext(options);
            repository = new SpecialStageRepository(context);
        }

        [TestMethod]
        public void AddAsync_WhenCalled_ReturnSuccess()
        {
            //Arrange

            //Action

            //Assert
        }

        [TestMethod]
        public void ListByPokemonIdAsync_WhenCalled_ReturnSuccess()
        {
            //Arrange

            //Action

            //Assert
        }
    }
}
