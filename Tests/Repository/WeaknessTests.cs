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
    public class WeaknessTests
    {
        private DataContext context;
        private IWeaknessRepository repository;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "pokedexdatabase")
            .Options;

            context = new DataContext(options);
            repository = new WeaknessRepository(context);
        }
    }
}
