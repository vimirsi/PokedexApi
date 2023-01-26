using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokedexApi.Domain.Dtos;
using PokedexApi.Domain.Interfaces;
using PokedexApi.Web.FormRequest;
using PokedexApi.Web.Resources;

namespace PokedexApi.Web.Controllers
{
    [ApiController]
    [Route("pokemon")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonRepository _repository;
        private readonly IMapper _mapper;

        public PokemonController(IPokemonRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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

        [HttpGet("all")]
        public async Task<IActionResult> All ([FromQuery] PokemonListAllFormRequest payload)
        {
            try
            {
                var result = await _repository.All(new PokemonListAllDTO
                {
                    Page = payload.Page,
                    PageSize = payload.PageSize
                });

                return Ok(_mapper.Map<IEnumerable<PokemonListAllResource>>(result));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("options")]
        public async Task<IActionResult> GetWithParams ([FromQuery] PokemonGetWithParamsFormRequest payload)
        {
            try
            {
                var result = await _repository.GetWithParams(new PokemonGetWithParamsDTO
                {
                    Category = payload.Category,
                    Name = payload.Name,
                    Region = payload.Region,
                    Page = payload.Page,
                    PageSize = payload.PageSize
                });

                return Ok(_mapper.Map<IEnumerable<PokemonGetWithParamsResource>>(result));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}