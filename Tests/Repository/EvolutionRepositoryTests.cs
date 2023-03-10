using Microsoft.EntityFrameworkCore;
using PokedexApi.Domain.Dtos;
using PokedexApi.Domain.Entities;
using PokedexApi.Domain.Interfaces;
using PokedexApi.Domain.Responses;
using PokedexApi.Infra;
using PokedexApi.Infra.Implements;

namespace Tests.Repository
{
    [TestClass]
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
            //arrange
            DropDatabase();

            //Act
            repository.AddAsync(new EvolutionAddDTO(){
                PokemonId = 1,
                PreEvolution = 0,
                EvolutionForm = 2
            });

            //Assert
            var actual = context.Evolution.Count();
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void GetEvolution_WhenCalled_ReturnSuccess()
        {
            //arrange
            DropDatabase();
            Evolution assert = SetupEvolution();

            //Act
            Task<EvolutionResponse> response = repository.GetByIdAsync(1);

            //Assert
            Assert.AreEqual(assert.PokemonId, response.Result.ActualStage.DexNumber);
        }

        [TestMethod]
        public void DeleteEvolution_WhenCalled_ReturnSuccess()
        {
            //arrange
            DropDatabase();
            Evolution assert = SetupEvolution();

            //Act
            repository.DeleteAsync(assert.PokemonId);

            //Assert
            var actual = context.Evolution.Where(x => x.PokemonId == assert.PokemonId).FirstOrDefault();
            Assert.IsNull(actual);
        }

        public Evolution SetupEvolution()
        {
            
            var pokemons = new List<Pokemon>();

            for(int i=1; i<3; i++)
            { 
                pokemons.Add(new Pokemon()
                {
                    DexNumber = i,
                    RelationshipPage = 1,
                    Name = "Bulbassaur",
                    Image = "url.jpg",
                    Description = "lorem ipsum",
                    Height = 5,
                    Weight = 5,
                    Gender = 1,
                    Rarity = 1,
                    Region = "kanto"
                });
            }

            context.AddRange(pokemons);
            context.SaveChanges();

            var evolution = new Evolution()
            {
                PokemonId = 1,
                PreEvolution = 0,
                EvolutionForm = 2
            };

            context.Add(evolution);
            context.SaveChanges();

            return evolution;
        }

        public void DropDatabase()
        {
            context.Database.EnsureDeleted();

            context.Database.EnsureCreated();
        }
    }
}