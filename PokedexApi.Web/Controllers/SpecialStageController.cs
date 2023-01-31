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
        private readonly IMapper _mapper;

        public SpecialStageController(ISpecialStageRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add ([FromBody] SpecialStageCreateFormRequest payload)
        {
            try
            {
                var result = await _repository.AddAsync(new SpecialStageAddDTO
                {
                    PokemonId = payload.PokemonId,
                    DexNumber = payload.DexNumber,
                    Image = payload.Image,
                    Description = payload.Description,
                    Height = payload.Height,
                    Weight = payload.Weight,
                    Region = payload.Region
                });

                return Created("Special Stage has been registered", result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById ([FromRoute] int id)
        {
            try
            {
                var result = await _repository.GetByIdAsync(id);

                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("all")]
        public async Task<IActionResult> All ([FromQuery] PokemonListAllFormRequest payload)
        {
            try
            {
                var result = await _repository.AllAsync(new SpecialStageListAllDTO
                {
                    Page = payload.Page,
                });

                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}/remove")]
        public async Task<IActionResult> Remove ([FromRoute] Guid id)
        {
            try
            {
                await _repository.DeleteAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}