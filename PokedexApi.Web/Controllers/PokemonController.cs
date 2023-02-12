using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokedexApi.Domain.Dtos;
using PokedexApi.Domain.Interfaces;
using PokedexApi.Web.FormRequest;
using PokedexApi.Web.Models;

namespace PokedexApi.Web.Controllers
{
    [ApiController]
    [Route("pokemon")]
    public class PokemonController : Controller
    {
        private readonly IPokemonRepository _repository;
        private readonly IMapper _mapper;

        public PokemonController(IPokemonRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("index")]
        public async Task<IActionResult> Index ([FromQuery] PokemonListAllFormRequest payload)
        {
            try
            {
                var result = await _repository.ListAllAsync(payload.Page);
                
                return View(_mapper.Map<IEnumerable<PokemonModel>>(result));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{dexNumber}")]
        public async Task<IActionResult> GetByDexNumber ([FromRoute] int dexNumber)
        {
            try
            {
                var result = await _repository.GetByDexNumberAsync(dexNumber);

                 return View(_mapper.Map<PokemonModel>(result));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("options")]
        public async Task<IActionResult> ListWithParams ([FromQuery] PokemonGetWithParamsFormRequest payload)
        {
            try
            {
                var result = await _repository.ListWithParamsAsync(new PokemonGetWithParamsDTO
                {
                    Name = payload.Name,
                    Region = payload.Region,
                    Page = payload.Page,
                });

                return View(_mapper.Map<IEnumerable<PokemonModel>>(result));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add ([FromBody] PokemonCreateFormRequest payload)
        {
            try
            {
                var result = await _repository.AddAsync(new PokemonAddDTO
                {
                    DexNumber = payload.DexNumber,
                    RelationshipPage = payload.RelationshipPage,
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