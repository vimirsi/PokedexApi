using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokedexApi.Domain.Dtos;
using PokedexApi.Domain.Interfaces;
using PokedexApi.Web.FormRequest;
using PokedexApi.Web.Models;

namespace PokedexApi.Web.Controllers
{
    [ApiController]
    [Route("evolution")]
    public class EvolutionController : Controller
    {
        private readonly IEvolutionRepository _repository;
        private readonly IMapper _mapper;

        public EvolutionController(IEvolutionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync([FromBody] EvolutionAddFormRequest payload)
        {
            try
            {
                var result = await _repository.AddAsync(new EvolutionAddDTO
                {
                    PokemonId = payload.PokemonId,
                    PreEvolution = payload.PreEvolution,
                    EvolutionForm = payload.EvolutionForm
                });

                return Created("Evolution has been registered", result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{dexNumber}")]
        public async Task<IActionResult> GetByPokemonId([FromRoute] int dexNumber)
        {
            try
            {
                var result = await _repository.GetByIdAsync(dexNumber);

                return View(_mapper.Map<EvolutionModel>(result));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{dexNumber}/remove")]
        public async Task<IActionResult> RemoveByPokemonId([FromRoute] int dexNumber)
        {
            try
            {
                await _repository.DeleteAsync(dexNumber);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
