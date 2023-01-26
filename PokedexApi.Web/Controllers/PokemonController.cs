using Microsoft.AspNetCore.Mvc;
using PokedexApi.Domain.Dtos;
using PokedexApi.Domain.Interfaces;
using PokedexApi.Web.FormRequest;

namespace PokedexApi.Web.Controllers
{
    [ApiController]
    [Route("pokemon")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonRepository _repository;

        public PokemonController(IPokemonRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add ([FromBody] PokemonCreateFormRequest payload)
        {
            try
            {
                var result = await _repository.Add(new PokemonAddDTO
                {
                    DexNumber = payload.DexNumber,
                    Category = payload.Category,
                    Name = payload.Name,
                    Image = payload.Image,
                    Description = payload.Description,
                    Height = payload.Height,
                    Weight = payload.Weight,
                    Gender = payload.Gender,
                    Rarity = payload.Rarity,
                    Region = payload.Region
                });

                return Created("Pokemon has been registered", result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}