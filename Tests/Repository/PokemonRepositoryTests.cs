using Microsoft.EntityFrameworkCore;
using PokedexApi.Core.Enums;
using PokedexApi.Domain.Dtos;
using PokedexApi.Domain.Entities;
using PokedexApi.Domain.Interfaces;
using PokedexApi.Domain.Responses;
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
        public void CreatePokemon_WhenCalled_ReturnSuccess()
        {
            // Arrange

            // Action
            repository.AddAsync(new PokemonAddDTO()
            {
                DexNumber = 1,
                RelationshipPage = 1,
                Name = "Bulbasaur",
                Image = "img.png",
                Description = "teste",
                Height = 0.5,
                Weight = 0.5,
                Gender = GenderEnum.Fluid,
                Rarity = RarityEnum.Rare,
                Region = "Kanto"
            });
            // Assert
            var actual = context.Pokemon.Count();
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void GetPokemon_WhenCalled_ReturnSuccess()
        {
            //Arrange
            List<Pokemon> assert = SetupPokemon();

            //Action
            Task<Pokemon> response = repository.GetByDexNumberAsync(1);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(1, response.Result.DexNumber);
        }

        [TestMethod]
        public void DeletePokemon_WhenCalled_ReturnSuccess()
        {
            //Arrange
            List<Pokemon> assert = SetupPokemon();

            //Action
            repository.DeleteAsync(assert[0].DexNumber);

            //Assert
            var actual = context.Pokemon.Where(x => x.DexNumber == assert[0].DexNumber).FirstOrDefault();
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void ListByEvolution_WhenCalled_ReturnSuccess()
        {
            //Arrange


            //Action


            //Assert


        }

        [TestMethod]
        public void ListWithParams_WhenCalled_ReturnSuccess()
        {
            //Arrange


            //Action


            //Assert


        }

        public List<Pokemon> SetupPokemon()
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

            return pokemons;
        }
    }
}