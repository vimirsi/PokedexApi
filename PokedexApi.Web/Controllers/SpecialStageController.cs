using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokedexApi.Domain.Dtos;
using PokedexApi.Domain.Interfaces;
using PokedexApi.Web.FormRequest;

namespace PokedexApi.Web.Controllers
{
    [ApiController]
    [Route("special-stage")]
    public class SpecialStageController : ControllerBase
    {
        private readonly ISpecialStageRepository _repository;

        public SpecialStageController(ISpecialStageRepository repository, IMapper mapper)
        {
            _repository = repository;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add ([FromBody] SpecialStageCreateFormRequest payload)
        {
            try
            {
                var result = await _repository.AddAsync(new SpecialStageAddDTO
                {
                    DexNumber = payload.DexNumber,
                    Name = payload.Name,
                    Image = payload.Image,
                    Description = payload.Description,
                    Height = payload.Height,
                    Weight = payload.Weight,
                    Region = payload.Region,
                    Gender = payload.Gender,
                    Rarity = payload.Rarity
                });

                return Created("Special Stage has been registered", result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{dexNumber}")]
        public async Task<IActionResult> ListByPokemonId ([FromRoute] int dexNumber)
        {
            try
            {
                var result = await _repository.ListByPokemonIdAsync(dexNumber);

                return Created("Special Stage has been registered", result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}