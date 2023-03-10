using Microsoft.EntityFrameworkCore;
using PokedexApi.Domain.Interfaces;
using PokedexApi.Infra.Implements;
using PokedexApi.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Repository
{
    [TestClass]
    public class StatsTests
    {
        private DataContext context;
        private IStatsRepository repository;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "pokedexdatabase")
                .Options;

            context = new DataContext(options);
            repository = new StatsRepository(context);
        }
    }
}
